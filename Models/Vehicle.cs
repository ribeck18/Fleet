namespace Fleet.Models;

using Fleet.Models.Enums;


class Vehicle{
	//This id is not the primary key it is a id that users can set on equipment
	public int EquipId {get; private set;}
	public string Vin {get;} 
	public string Name {get; set;}
	public string Make {get; set;}
	public string Model {get; set;}
	public int Year {get; set;} 
 	public int Mileage {get; set;}
	public VehicleStatus Status {get; set;} = VehicleStatus.Active;

	public bool NeedsService {get; set;} = false;
	public bool NeedsMaintenance {get; set;} = false;
	public bool IsSevere {get; set;} = false;

	
	public Vehicle(int id, string vin, string name, string make, string model, int year, int mileage, VehicleStatus status){
		EquipId = id;
		Vin = vin;
		Name = name;
		Make = make;
		Model = model;
		Year = year;
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
