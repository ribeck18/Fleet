using dotenv.net;
using Microsoft.AspNe 


DotEnv.Load();

string connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING")
	?? throw new Exception("Missing CONNECTION_STRING");


var builder = WebApplication.CreateBuilder(args);

 
