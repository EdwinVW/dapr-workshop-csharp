namespace TrafficControlService.Repositories;

public class InMemoryVehicleStateRepository : IVehicleStateRepository
{
    private readonly ConcurrentDictionary<string, VehicleState> _state;

    public InMemoryVehicleStateRepository()
    {
        _state = new ConcurrentDictionary<string, VehicleState>();
    }
    public Task<VehicleState?> GetVehicleStateAsync(string licenseNumber)
    {
        VehicleState state;
        if (!_state.TryGetValue(licenseNumber, out state))
        {
            return Task.FromResult<VehicleState?>(null);
        }
        return Task.FromResult<VehicleState?>(state);
    }

    public Task SaveVehicleStateAsync(VehicleState vehicleState)
    {
        _state.AddOrUpdate(vehicleState.LicenseNumber, vehicleState,
            (k, s) => vehicleState);
        return Task.CompletedTask;
    }
}
