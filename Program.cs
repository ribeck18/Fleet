using dotenv.net;

DotEnv.Load();

string connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING")
	?? throw new Exception("Missing CONNECTION_STRING");

 
