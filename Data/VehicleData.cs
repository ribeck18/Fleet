namespace Fleet.Data;

using Fleet.Models;
using Npgsql;

class VehicleData{
	private readonly DatabaseConnection _db;

	public VehicleData(DatabaseConnection db){
		_db = db;
	}

	public async Task CreateVehicle(Vehicle vehicle){
		await _db.Database(async (connectionPoint) =>
			{
				await using var cmd = new NpgsqlCommand("INSERT INTO vehicles (vehicleid, title, make, model, modelyear, mileage, status, needsservice, needsmaintenance, issevere) VALUES ($1, $2, $3, $4, $5, $6, $7, $8, $9, $10);", connectionPoint){
					Parameters = 
					{
						new() {Value = vehicle.VehicleId},
						new() {Value = vehicle.Name},
						new() {Value = vehicle.Make},
						new() {Value = vehicle.Model},
						new() {Value = vehicle.Year},
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
	public async Task GetVehicle(int PrimaryKey){
		await _db.Database(async (connectionPoint) => {
				await using var cmd = new NpgsqlCommand($"SELECT * FROM vehicles WHERE id = {PrimaryKey};", connectionPoint);
				} );
	}
	public async Task GetVehicles(){
		await _db.Database(async (connectionPoint) => {
				await using var cmd = new NpgsqlCommand("SELECT make ||' '|| model FROM vehicles;", connectionPoint);
				});
	}
}

