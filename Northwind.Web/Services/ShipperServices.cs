using Newtonsoft.Json;
using Northwind.Web.IServices;
using Northwind.Web.Models;
using Northwind.Web.Result;
using Northwind.Web.Result.ShippersResult;
using System.Net.Http;
using System.Threading.Tasks;

public class ShipperServices : IShippersServices
{
    private readonly HttpClient _httpClient;

    public ShipperServices(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
    }

    public async Task<ShippersGetListResult> GetShippersAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("http://localhost:5296/api/Shippers/GetShippers");
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ShippersGetListResult>(apiResponse);
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

    public async Task<ShipperGetResult> GetShipperByIdAsync(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"http://localhost:5296/api/Shippers/GetShipperById?id={id}");
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ShipperGetResult>(apiResponse);
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

    public async Task<BaseResult> CreateShipperAsync(ShippersBaseModel shipper)
    {
        try
        {
            var jsonContent = JsonConvert.SerializeObject(shipper);
            var contentString = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("http://localhost:5296/api/Shippers/SaveShippers", contentString);
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

    public async Task<BaseResult> UpdateShipperAsync(int id, ShippersBaseModel shipper)
    {
        try
        {
            var jsonContent = JsonConvert.SerializeObject(shipper);
            var contentString = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"http://localhost:5296/api/Shippers/UpdateShipper?id={id}", contentString);
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

    public async Task<BaseResult> DeleteShipperAsync(int id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"http://localhost:5296/api/Shippers/DeleteShipper?id={id}");
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
