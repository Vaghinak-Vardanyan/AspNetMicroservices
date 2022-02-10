using System.Net.Http.Headers;
using System.Text.Json;

namespace AspnetRunBasics.Extensions;

public static class HttpClientExtensions
{
    public static async Task<T> ReadContentAs<T>(this HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
            throw new ApplicationException($"Something went wrong calling the API: {response.ReasonPhrase}");

        var dataAsBytes = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);

        return JsonSerializer.Deserialize<T>(dataAsBytes, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }

    public static async Task<HttpResponseMessage> PostAsJson<T>(this HttpClient httpClient, string url, T data)
    {
        var dataAsBytes = JsonSerializer.SerializeToUtf8Bytes(data);
        var content = new ByteArrayContent(dataAsBytes);
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        return await httpClient.PostAsync(url, content);
    }

    public static async Task<HttpResponseMessage> PutAsJson<T>(this HttpClient httpClient, string url, T data)
    {
        var dataAsBytes = JsonSerializer.SerializeToUtf8Bytes(data);
        var content = new ByteArrayContent(dataAsBytes);
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        return await httpClient.PutAsync(url, content);
    }
}

