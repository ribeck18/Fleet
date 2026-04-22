namespace Fleet.Data;

using Fleet.Models;
using Fleet.Models.Enums;
using Npgsql;

class VehicleData{
	//attributes 
	private readonly DatabaseConnection _db;

	//Constructor
	public VehicleData(DatabaseConnection db){
		_db = db;
	}


	//Methods 
	public async Task CreateVehicle(Vehicle vehicle){
		await _db.Database(async (connectionPoint) =>
			{
				await using var cmd = new NpgsqlCommand("INSERT INTO vehicles (vehicleid, title, make, model, modelyear, mileage, status, needsservice, needsmaintenance, issevere) VALUES ($1, $2, $3, $4, $5, $6, $7, $8, $9, $10);", connectionPoint){
					Parameters = 
					{
						new() {Value = vehicle.VehicleId},
						new() {Value = vehicle.Title},
						new() {Value = vehicle.Make},
						new() {Value = vehicle.Model},
						new() {Value = vehicle.ModelYear},
						new() {Value = vehicle.Mileage},
						new() {Value = vehicle.Status.ToString()},
						new() {Value = vehicle.NeedsService},
						new() {Value = vehicle.NeedsMaintenance},
						new() {Value = vehicle.IsSevere}
					}
				};
				await cmd.ExecuteNonQueryAsync();
			});
	}

	public async Task<Vehicle?> GetVehicle(int PrimaryKey){
		return await _db.Database(async (connectionPoint) => {
			await using var cmd = new NpgsqlCommand($"SELECT * FROM vehicles WHERE id = $1;", connectionPoint){
				Parameters = {
					new () {Value = PrimaryKey}
				}
			};
			await using var reader = await cmd.ExecuteReaderAsync();

			await reader.ReadAsync();
			Vehicle vehicle = new Vehicle(
					reader.GetInt32(reader.GetOrdinal("id")), //Primary key
					reader.GetString(reader.GetOrdinal("vehicleid")), //Vehicle id 
					reader.GetString(reader.GetOrdinal("vin")),
					reader.GetString(reader.GetOrdinal("title")), //title 
					reader.GetString(reader.GetOrdinal("make")), //make
					reader.GetString(reader.GetOrdinal("model")), //model
					reader.GetInt32(reader.GetOrdinal("modelyear")), //modelyear
					reader.GetInt32(reader.GetOrdinal("mileage")), // mileage
					Enum.Parse<VehicleStatus>(reader.GetString(reader.GetOrdinal("status")))// status
					);
			return vehicle;
		});
			
	} 

	public async Task GetVehicles(){
		await _db.Database(async (connectionPoint) => {
				await using var cmd = new NpgsqlCommand("SELECT make ||' '|| model FROM vehicles;", connectionPoint);
				await using var reader =  await cmd.ExecuteReaderAsync();
				});
	}
}

