namespace Fleet.Models;

using Fleet.Models.Enums;


public class Vehicle{
	//This is not the primary key from database, it is a user entered id.
	public string VehicleId {get; private set;}
	public string Vin {get;} 
	public string Title {get; set;}
	public string Make {get; set;}
	public string Model {get; set;}
	public int ModelYear {get; set;} 
 	public int Mileage {get; set;}
	public VehicleStatus Status {get; set;} = VehicleStatus.Active;
	public int PrimaryKey {get;}

	public bool NeedsService {get; set;} = false;
	public bool NeedsMaintenance {get; set;} = false;
	public bool IsSevere {get; set;} = false;
	

	//For creating an entierly new vehicle.	
	public Vehicle(string id, string vin, string title, string make, string model, int modelYear, int mileage, VehicleStatus status){
		VehicleId = id;
		Vin = vin;
		Title = title;
		Make = make;
		Model = model;
		ModelYear = modelYear;
		Mileage = mileage;
		Status = status;
		
		ProtectStatus();
		CheckSetSevereIssue();
	}
	//For creating a vehicle from the database
	public Vehicle(int primaryKey, string id, string vin, string title, string make, string model, int modelYear, int mileage, VehicleStatus status){
		PrimaryKey = primaryKey; 
		VehicleId = id;
		Vin = vin;
		Title = title;
		Make = make;
		Model = model;
		ModelYear = modelYear;
		Mileage = mileage;
		Status = status;
		
		SetBools();	
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

	private void SetBools(){
		if (Status == VehicleStatus.Down){
			IsSevere = true;
		}
		else if (Status == VehicleStatus.MaintenanceNeeded){
			NeedsMaintenance = true;
		}
		else if (Status == VehicleStatus.ServiceNeeded){
			NeedsService = true;
		}
		else
		{
			IsSevere = false;
			NeedsMaintenance = false;
			NeedsService = false;
		}
	}



}
