using Northwind.Web.Models;
using Northwind.Web.Result.SuppliersResult;
using Northwind.Web.Result;
using Newtonsoft.Json;
using Northwind.Web.IServices;
using System.Net.Http;
using System.Threading.Tasks;
using System;

public class SupplierServices : ISuppliersServices
{
    private readonly HttpClient _httpClient;

    public SupplierServices(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
    }

    public async Task<SuppliersGetListResult> GetSuppliersAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("http://localhost:5182/api/Suppliers/GetSuppliers");
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<SuppliersGetListResult>(apiResponse);
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Request Exception: {e.Message}");
            throw;
        }
        catch (JsonSerializationException e)
        {
            Console.WriteLine($"Serialization Exception: {e.Message}");
            throw;
        }
    }

    public async Task<SupplierGetResult> GetSupplierByIdAsync(int SupplierID)
    {
        try
        {
            var response = await _httpClient.GetAsync($"http://localhost:5182/api/Suppliers/GetSupplierById?id={SupplierID}");
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<SupplierGetResult>(apiResponse);
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Request Exception: {e.Message}");
            throw;
        }
        catch (JsonSerializationException e)
        {
            Console.WriteLine($"Serialization Exception: {e.Message}");
            throw;
        }
    }

    public async Task<BaseResult> CreateSupplierAsync(SuppliersBaseModel supplier)
    {
        try
        {
            var jsonContent = JsonConvert.SerializeObject(supplier);
            var contentString = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("http://localhost:5182/api/Suppliers/SaveSuppliers", contentString);
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<BaseResult>(apiResponse);
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Request Exception: {e.Message}");
            throw;
        }
        catch (JsonSerializationException e)
        {
            Console.WriteLine($"Serialization Exception: {e.Message}");
            throw;
        }
    }

    public async Task<BaseResult> UpdateSupplierAsync(int id, SuppliersBaseModel supplier)
    {
        try
        {
            var jsonContent = JsonConvert.SerializeObject(supplier);
            var contentString = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"http://localhost:5182/api/Suppliers/UpdateSupplier?id={id}", contentString);
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<BaseResult>(apiResponse);
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Request Exception: {e.Message}");
            throw;
        }
        catch (JsonSerializationException e)
        {
            Console.WriteLine($"Serialization Exception: {e.Message}");
            throw;
        }
    }

    public async Task<BaseResult> DeleteSupplierAsync(int SupplierID)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"http://localhost:5182/api/Suppliers/DeleteSupplier?id={SupplierID}");
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<BaseResult>(apiResponse);
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Request Exception: {e.Message}");
            throw;
        }
        catch (JsonSerializationException e)
        {
            Console.WriteLine($"Serialization Exception: {e.Message}");
            throw;
        }
    }
}
