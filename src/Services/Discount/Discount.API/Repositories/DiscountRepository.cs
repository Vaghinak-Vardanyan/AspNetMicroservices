using Dapper;
using Discount.API.Entities;
using Npgsql;

namespace Discount.API.Repositories;

public class DiscountRepository : IDiscountRepository
{
    private readonly IConfiguration _configuration;

    public DiscountRepository(IConfiguration configuration)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    public async Task<Coupon> GetDiscount(string productName)
    {
        using var connection = new NpgsqlConnection
            (_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

        var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>
            ("select * from Coupon where ProductName = @ProductName", new { ProductName = productName });
        
        if (coupon == null)
        {
            return new Coupon 
            { 
                ProductName = "No Discount", 
                Description = "No Discount Description",
                Amount = 0 
            };
        }

        return coupon;
    }

    public async Task<bool> CreateDiscount(Coupon coupon)
    {
        using var connection = new NpgsqlConnection
            (_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

        var affected = await connection.ExecuteAsync
            ("insert into Coupon (ProductName, Description, Amount) values (@ProductName, @Description, @Amount)",
             new { ProductName = coupon.ProductName, Description = coupon.Description, Amount = coupon.Amount });

        return affected > 0;
    }

    public async Task<bool> UpdateDiscount(Coupon coupon)
    {
        using var connection = new NpgsqlConnection
            (_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

        var affected = await connection.ExecuteAsync
            ("update Coupon set ProductName = @ProductName, Description = @Description, Amount = @Amount where Id = @Id",
             new { Id = coupon.Id, ProductName = coupon.ProductName, Description = coupon.Description, Amount = coupon.Amount });

        return affected > 0;
    }

    public async Task<bool> DeleteDiscount(string productName)
    {
        using var connection = new NpgsqlConnection
            (_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

        var affected = await connection.ExecuteAsync
            ("delete from Coupon where ProductName = @ProductName",
             new { ProductName = productName });

        return affected > 0;
    }
}

