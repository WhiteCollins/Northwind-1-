using Newtonsoft.Json;
using Northwind.Web.IServices;
using Northwind.Web.Models;
using Northwind.Web.Result;
using Northwind.Web.Result.ProductResult;
using System.Text;


public class ProductServices : IProductsServices
{
    private readonly HttpClient _httpClient;

    public ProductServices(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ProductGetListResult> GetProductsAsync()
    {
        var response = await _httpClient.GetAsync("Products/GetProducts");

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Error fetching products: {response.ReasonPhrase}");
        }

        var apiResponse = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<ProductGetListResult>(apiResponse);

        if (result == null)
        {
            throw new JsonSerializationException("Deserialization of ProductsGetListResult returned null.");
        }

        return result;
    }

    public async Task<ProductGetResult> GetProductByIdAsync(int productId)
    {
        var response = await _httpClient.GetAsync($"Products/GetProductById?id={productId}");

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Error fetching product by id: {response.ReasonPhrase}");
        }

        var apiResponse = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<ProductGetResult>(apiResponse);

        if (result == null)
        {
            throw new JsonSerializationException("Deserialization of ProductGetResult returned null.");
        }

        return result;
    }

    public async Task<BaseResult> CreateProductAsync(ProductBaseModel product)
    {
        var jsonContent = JsonConvert.SerializeObject(product);
        var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("Products/SaveProduct", contentString);

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Error creating product: {response.ReasonPhrase}");
        }

        var apiResponse = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<BaseResult>(apiResponse);

        if (result == null)
        {
            throw new JsonSerializationException("Deserialization of BaseResult returned null.");
        }

        return result;
    }

    public async Task<BaseResult> UpdateProductAsync(int id, ProductBaseModel product)
    {
        var jsonContent = JsonConvert.SerializeObject(product);
        var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        var response = await _httpClient.PutAsync($"Products/UpdateProduct?id={id}", contentString);

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Error updating product: {response.ReasonPhrase}");
        }

        var apiResponse = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<BaseResult>(apiResponse);

        if (result == null)
        {
            throw new JsonSerializationException("Deserialization of BaseResult returned null.");
        }

        return result;
    }

    public async Task<BaseResult> DeleteProductAsync(int productId)
    {
        var response = await _httpClient.DeleteAsync($"Products/DeleteProduct?id={productId}");

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Error deleting product: {response.ReasonPhrase}");
        }

        var apiResponse = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<BaseResult>(apiResponse);

        if (result == null)
        {
            throw new JsonSerializationException("Deserialization of BaseResult returned null.");
        }

        return result;
    }

    Task<ProductGetListResult> IProductsServices.GetProductsAsync()
    {
        throw new NotImplementedException();
    }
}
