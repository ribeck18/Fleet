namespace Fleet.Models;

using Fleet.Models.Enums;


class Vehicle{
	Guid uuid {get;}
	int Id {get;}
	string Vin {get;} = "";
	string Name {get; set;} = "";
	string Make {get; set;} = "";
	string Model {get; set;} = "";
	int Year {get; set;} 
	string LicensePlate {get; set;} = "";
 	int Mileage {get; set;}
	VehicleStatus Status {get; set;} = VehicleStatus.Active;

	bool NeedsService {get; set;} = false;
	bool NeedsMaintenance {get; set;} = false;
	bool IsSevere {get; set;} = false;

	
	public Vehicle(string name, string make, string model, int year)
	{
		Name = name;
		Make = make;
		Model = model;
		Year = year;

		ProtectStatus();
	}
	public Vehicle(int id, string vin, string name, string make, string model, int year, string licensePlate, int mileage, VehicleStatus status){
		Id = id;
		Vin = vin;
		Name = name;
		Make = make;
		Model = model;
		Year = year;
		LicensePlate = licensePlate;
		Mileage = mileage;
		Status = status;
		
		ProtectStatus();
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
