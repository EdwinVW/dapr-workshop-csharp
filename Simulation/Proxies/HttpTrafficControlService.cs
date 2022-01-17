namespace Simulation.Proxies;

public class HttpTrafficControlService : ITrafficControlService
{
    private HttpClient _httpClient;

    public HttpTrafficControlService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task SendVehicleEntryAsync(VehicleRegistered vehicleRegistered)
    {
        var eventJson = JsonSerializer.Serialize(vehicleRegistered);
        var message = JsonContent.Create<VehicleRegistered>(vehicleRegistered);
        await _httpClient.PostAsync("http://localhost:6000/entrycam", message);
    }

    public async Task SendVehicleExitAsync(VehicleRegistered vehicleRegistered)
    {
        var eventJson = JsonSerializer.Serialize(vehicleRegistered);
        var message = JsonContent.Create<VehicleRegistered>(vehicleRegistered);
        await _httpClient.PostAsync("http://localhost:6000/exitcam", message);
    }
}
