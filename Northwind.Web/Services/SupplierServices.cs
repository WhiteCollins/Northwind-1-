using Newtonsoft.Json;
using Northwind.Web.IServices;
using Northwind.Web.Models;
using Northwind.Web.Result;
using Northwind.Web.Result.SuppliersResult;

public class SupplierServices : ISuppliersServices
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public SupplierServices(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<SuppliersGetListResult> GetSuppliersAsync()
    {
        var response = await _httpClient.GetAsync("Suppliers/GetSuppliers");

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Error fetching suppliers: {response.ReasonPhrase}");
        }

        var apiResponse = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<SuppliersGetListResult>(apiResponse);

        if (result == null)
        {
            throw new JsonSerializationException("Deserialization of SuppliersGetListResult returned null.");
        }

        return result;
    }

    public async Task<SupplierGetResult> GetSupplierByIdAsync(int SupplierID)
    {
        var response = await _httpClient.GetAsync($"Suppliers/GetSupplierById?id={SupplierID}");

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Error fetching supplier by id: {response.ReasonPhrase}");
        }

        var apiResponse = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<SupplierGetResult>(apiResponse);

        if (result == null)
        {
            throw new JsonSerializationException("Deserialization of SupplierGetResult returned null.");
        }

        return result;
    }

    public async Task<BaseResult> CreateSupplierAsync(SuppliersBaseModel supplier)
    {
        var jsonContent = JsonConvert.SerializeObject(supplier);
        var contentString = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("Suppliers/SaveSuppliers", contentString);

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Error creating supplier: {response.ReasonPhrase}");
        }

        var apiResponse = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<BaseResult>(apiResponse);

        if (result == null)
        {
            throw new JsonSerializationException("Deserialization of BaseResult returned null.");
        }

        return result;
    }

    public async Task<BaseResult> UpdateSupplierAsync(int id, SuppliersBaseModel supplier)
    {
        var jsonContent = JsonConvert.SerializeObject(supplier);
        var contentString = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
        var response = await _httpClient.PutAsync($"Suppliers/UpdateSupplier?id={id}", contentString);

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Error updating supplier: {response.ReasonPhrase}");
        }

        var apiResponse = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<BaseResult>(apiResponse);

        if (result == null)
        {
            throw new JsonSerializationException("Deserialization of BaseResult returned null.");
        }

        return result;
    }

    public async Task<BaseResult> DeleteSupplierAsync(int SupplierID)
    {
        var response = await _httpClient.DeleteAsync($"Suppliers/DeleteSupplier?id={SupplierID}");

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Error deleting supplier: {response.ReasonPhrase}");
        }

        var apiResponse = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<BaseResult>(apiResponse);

        if (result == null)
        {
            throw new JsonSerializationException("Deserialization of BaseResult returned null.");
        }

        return result;
    }
}
