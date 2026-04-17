namespace Fleet.Data;

using Fleet.Models;
using Npgsql;

class VehicleData{
	private readonly DatabaseConnection _db;

	public VehicleData(DatabaseConnection db){
		_db = db;
	}

	public async Task CreateVehicle(Dictionary<string, string> VehicleDict){

		await _db.Database(async (connectionPoint) =>
			{
				await using var cmd = new NpgsqlCommand("INSERT INTO ")
			});
	}
}

