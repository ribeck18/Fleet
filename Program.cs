using dotenv.net;
using Fleet.Models;

//Load in the Environment
DotEnv.Load();

//Set up the app for the routes.
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

 
//Testing the database insert. Delete later.
//
Vehicle vehicle = new Vehicle("name")
