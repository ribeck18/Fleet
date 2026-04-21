using Fleet.Models;
using Fleet.Models.Enums;
using Fleet.Services;
using Fleet.Data;

public static class VehicleRoutes{

	private static VehicleData GetVehiclesTable(){
		DatabaseConnection db = new DatabaseConnection();
		VehicleData vehicleTable = new VehicleData(db);
		return vehicleTable;
	}

	public static void MapVehicleRoutes(this WebApplication app){

		app.MapPost("/createVehicle", async(
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
				VehicleData Table = GetVehiclesTable();
				await Table.CreateVehicle(vehicle);
				
				//This is temporary (maybe) it adds it to a list in the working memory.
				VehicleService.AddVehicle(vehicle);
	
				return vehicle;
			} 
		);

		// app.MapGet("/vehicleList",() => VehicleService.GetVehicles());
		
		//Get from the database
		app.MapGet("/vehicle{id}", async(int id) => {
				VehicleData table = GetVehiclesTable();
				await table.GetVehicle(id);
				});
		app.MapGet("/vehicleList", async() => {
				VehicleData table = GetVehiclesTable();
				await table.GetVehicles();
				});
	}
}
