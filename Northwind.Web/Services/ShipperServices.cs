using Newtonsoft.Json;
using Northwind.Web.IServices;
using Northwind.Web.Models;
using Northwind.Web.Result;
using Northwind.Web.Result.ShippersResult;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class ShipperServices : IShippersServices
{
    private readonly HttpClient _httpClient;

    public ShipperServices(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ShippersGetListResult> GetShippersAsync()
    {
        var response = await _httpClient.GetAsync("Shippers/GetShippers");

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Error fetching shippers: {response.ReasonPhrase}");
        }

        var apiResponse = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<ShippersGetListResult>(apiResponse);

        if (result == null)
        {
            throw new JsonSerializationException("Deserialization of ShippersGetListResult returned null.");
        }

        return result;
    }

    public async Task<ShipperGetResult> GetShipperByIdAsync(int shipperId)
    {
        var response = await _httpClient.GetAsync($"Shippers/GetShipperById?id={shipperId}");

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Error fetching shipper by id: {response.ReasonPhrase}");
        }

        var apiResponse = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<ShipperGetResult>(apiResponse);

        if (result == null)
        {
            throw new JsonSerializationException("Deserialization of ShipperGetResult returned null.");
        }

        return result;
    }

    public async Task<BaseResult> CreateShipperAsync(ShippersBaseModel shipper)
    {
        var jsonContent = JsonConvert.SerializeObject(shipper);
        var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("Shippers/SaveShipper", contentString);

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Error creating shipper: {response.ReasonPhrase}");
        }

        var apiResponse = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<BaseResult>(apiResponse);

        if (result == null)
        {
            throw new JsonSerializationException("Deserialization of BaseResult returned null.");
        }

        return result;
    }

    public async Task<BaseResult> UpdateShipperAsync(int id, ShippersBaseModel shipper)
    {
        var jsonContent = JsonConvert.SerializeObject(shipper);
        var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        var response = await _httpClient.PutAsync($"Shippers/UpdateShipper?id={id}", contentString);

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Error updating shipper: {response.ReasonPhrase}");
        }

        var apiResponse = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<BaseResult>(apiResponse);

        if (result == null)
        {
            throw new JsonSerializationException("Deserialization of BaseResult returned null.");
        }

        return result;
    }

    public async Task<BaseResult> DeleteShipperAsync(int shipperId)
    {
        var response = await _httpClient.DeleteAsync($"Shippers/DeleteShipper?id={shipperId}");

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Error deleting shipper: {response.ReasonPhrase}");
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
