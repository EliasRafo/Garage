namespace Garage
{
    public interface IGarageHandler
    {
        bool IsFull { get; }
        bool CheckOut(string regNo);
        List<Vehicle>? FindVehicles(string type, string color, int wheelsNumber);
        List<Vehicle> GetAllParkedVehicles();
        List<VehicleTypesDto> GetVehicleTypes();
        void ParkVehicle(Vehicle vehicle);
        bool SearchByRegNo(string regNo);
        Vehicle? SearchOnRegNo(string regNo);
    }
}