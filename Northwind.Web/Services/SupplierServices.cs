using Northwind.Web.Models;
using Northwind.Web.Result.SuppliersResult;
using Northwind.Web.Result;
using Newtonsoft.Json;
using Northwind.Web.IServices;

public class SupplierServices : ISuppliersServices
{
    private readonly HttpClient _httpClient;

    public SupplierServices(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
    }

    public async Task<SuppliersGetListResult> GetSuppliersAsync()
    {
        var response = await _httpClient.GetAsync("http://localhost:5182/api/Suppliers/GetSuppliers");
        response.EnsureSuccessStatusCode();
        var apiResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<SuppliersGetListResult>(apiResponse);
    }

    public async Task<SupplierGetResult> GetSupplierByIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"http://localhost:5182/api/Suppliers/GetSupplierById?id={id}");
        response.EnsureSuccessStatusCode();
        var apiResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<SupplierGetResult>(apiResponse);
    }

    public async Task<BaseResult> CreateSupplierAsync(SuppliersBaseModel supplier)
    {
        var jsonContent = JsonConvert.SerializeObject(supplier);
        var contentString = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("http://localhost:5182/api/Suppliers/SaveSuppliers", contentString);
        response.EnsureSuccessStatusCode();
        var apiResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<BaseResult>(apiResponse);
    }

    public async Task<BaseResult> UpdateSupplierAsync(int id, SuppliersBaseModel supplier)
    {
        var jsonContent = JsonConvert.SerializeObject(supplier);
        var contentString = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
        var response = await _httpClient.PutAsync($"http://localhost:5182/api/Suppliers/UpdateSupplier?id={id}", contentString);
        response.EnsureSuccessStatusCode();
        var apiResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<BaseResult>(apiResponse);
    }

    public async Task<BaseResult> DeleteSupplierAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"http://localhost:5182/api/Suppliers/DeleteSupplier?id={id}");
        response.EnsureSuccessStatusCode();
        var apiResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<BaseResult>(apiResponse);
    }
}
