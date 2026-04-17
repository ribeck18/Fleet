namespace Fleet.Data;

using Npgsql;

class DatabaseConnection{
	private readonly string _connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING")
		?? throw new Exception("Missing CONNECTION_STRING");

	
	//Task basically means do this in the background. If you use await, the method must return a Task.
	public async Task Database(Func<NpgsqlConnection, Task> action){
		//Essentially this connects to the database, makes a connection point, then awaits an action.
		await using var dataSource = NpgsqlDataSource.Create(_connectionString); 
		await using var connectionPoint = await dataSource.OpenConnectionAsync();
		await action(connectionPoint);
	}
}
