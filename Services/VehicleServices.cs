namespace Fleet.Services;
using Fleet.Models;


public static class VehicleService {
	private static List<Vehicle> VehicleList = [];


	public static void AddVehicle(Vehicle vehicle){
		VehicleList.Add(vehicle);
	} 

	public static List<Vehicle> GetVehicles(){
		return VehicleList;
	}
}
