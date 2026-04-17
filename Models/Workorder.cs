using Fleet.Models.Enums;

class WorkOrder{
	int Id {get; set;}
	string Name {get; set;} = "";
	string Description {get; set;} = "";
	WorkorderSeverity Severity {get;}
	string Creator {get; set;} = "";
	DateTime CreatedDate {get;} = DateTime.Now;
	DateTime ResolvedDate {get; set;}
	string ResolvedDescription {get; set;} = "";
	int EquipmentId {get; set;}


}
