using Fleet.Models.Enums;

class WorkOrder{
	public int Id {get; set;}
	public string Name {get; private set;}
	public string Description {get; private set;}
	public WorkorderSeverity Severity {get; private set;}
	public string Creator {get; private set;}
	public DateTime CreatedDate {get;}
	public DateTime? ResolvedDate {get; private set;}
	public string? ResolvedDescription {get; set;}
	public int EquipmentId {get; set;}


	public WorkOrder(string name, string description, WorkorderSeverity severity, string creator, DateTime createdDate, int equipmentId){
		Name = name;
		Description = description;
		Severity = severity;
		Creator = creator;
		CreatedDate = createdDate;
		EquipmentId = equipmentId;
		ResolvedDate = null;
		ResolvedDescription = null;
	}


	public void ResolveWorkorder(string description){
		ResolvedDate = DateTime.Now;
		ResolvedDescription = description;
	}


}
