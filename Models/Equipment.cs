class Equipment{
	//attributes 
	public string Name {get; set;}
	public string Status {get; set;}
	public string Type {get; set;}
	public int Year {get; set;}
	public Guid ID {get;}

	//constructors
	public Equipment(string name, string status, string type, int year){
		Name = name;
		Status = status;
		Type = type;
		Year = year;
		ID = Guid.NewGuid();
	}

	//methods
	
	
	
}

