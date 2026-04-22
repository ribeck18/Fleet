using dotenv.net;
using System.Text.Json.Serialization;

//Load in the Environment
DotEnv.Load();

//Set up the app for the routes.
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureHttpJsonOptions(options =>
	{

    	options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());

	});


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapVehicleRoutes();

app.Run();

 
//Testing the database insert. Delete later.
//
