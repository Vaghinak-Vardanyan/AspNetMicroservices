using Shopping.Aggregator.Models;

namespace Shopping.Aggregator.Services;

public class CatalogService : ICatalogService
{
    private readonly HttpClient _client;

    public CatalogService(HttpClient client)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
    }

    public Task<ProductModel> GetProduct(string id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ProductModel>> GetProductByCategory(string category)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ProductModel>> GetProducts()
    {
        throw new NotImplementedException();
    }
}

