namespace Fleet.Data;
using Npgsql;


class VehicleData{
	string connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING")
		?? throw new Exception("Missing CONNECTION_STRING");
	
	//Task basically means do this in the background. If you use await, the method must return a Task.
	public async Task VehicleDatabase(){
		await using var dataSource = NpgsqlDataSource.Create(connectionString); 
	}


}

