namespace Fleet.Models;

using Fleet.Models.Enums;


public class Vehicle{
	//This is not the primary key from database, it is a user entered id.
	public int VehicleId {get; private set;}
	public string Vin {get;} 
	public string Name {get; set;}
	public string Make {get; set;}
	public string Model {get; set;}
	public int Year {get; set;} 
 	public int Mileage {get; set;}
	public VehicleStatus Status {get; set;} = VehicleStatus.Active;
	public int PrimaryKey {get;}

	public bool NeedsService {get; set;} = false;
	public bool NeedsMaintenance {get; set;} = false;
	public bool IsSevere {get; set;} = false;
	

	//For creating an entierly new vehicle.	
	public Vehicle(int id, string vin, string name, string make, string model, int year, int mileage, VehicleStatus status){
		VehicleId = id;
		Vin = vin;
		Name = name;
		Make = make;
		Model = model;
		Year = year;
		Mileage = mileage;
		Status = status;
		
		ProtectStatus();
		CheckSetSevereIssue();
	}
	//For creating a vehicle from the database
	public Vehicle(int id, string vin, string name, string make, string model, int year, int mileage, VehicleStatus status, int primaryKey){
		VehicleId = id;
		Vin = vin;
		Name = name;
		Make = make;
		Model = model;
		Year = year;
		Mileage = mileage;
		Status = status;
		PrimaryKey = primaryKey; 
		
		ProtectStatus();
		CheckSetSevereIssue();
	}

	private void ProtectStatus(){
		if (NeedsService == true && Status == VehicleStatus.Active){
			Status = VehicleStatus.ServiceNeeded;
			CheckSetSevereIssue();
		}
		if (NeedsMaintenance == true && Status ==VehicleStatus.Active){
			Status = VehicleStatus.MaintenanceNeeded;
			CheckSetSevereIssue();
		}
	}
	private void CheckSetSevereIssue(){
		if (IsSevere == true){
			Status = VehicleStatus.Down;
		}
	}



}
