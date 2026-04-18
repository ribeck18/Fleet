using Fleet.Models;
using Fleet.Models.Enums;

public static class VehicleRoutes{

	public static void MapVehicleRoutes(this WebApplication app){

		app.MapPost("/createVehicle", (
			int id, 
			string vin, 
			string name, 
			string make, 
			string model, 
			int year, 
			int mileage, 
			VehicleStatus status,
			bool needsService,
			bool needsMaintenance, 
			bool isSevere) => {
				Vehicle vehicle = new Vehicle(id, vin, name, make, model, year, mileage, status);
				//Also need to add it to the database.
	
				return vehicle;
			} 
		);
	}
}
