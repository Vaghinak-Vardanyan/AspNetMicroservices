using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AspnetRunBasics.Services;

public class CatalogService : ICatalogService
{
    private readonly HttpClient _client;

    public CatalogService(HttpClient client)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
    }

    public Task<ProductModel> CreateProduct(ProductModel model)
    {
        throw new System.NotImplementedException();
    }

    public Task<ProductModel> GetProduct(string id)
    {
        throw new System.NotImplementedException();
    }

    public Task<IEnumerable<ProductModel>> GetProductByCategory(string category)
    {
        throw new System.NotImplementedException();
    }

    public Task<IEnumerable<ProductModel>> GetProducts()
    {
        throw new System.NotImplementedException();
    }
}
