<Query Kind="Statements">
  <Connection>
    <ID>0903a671-bc28-4a68-b2c8-35fdc40c6427</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WorkSchedule</Database>
  </Connection>
</Query>

var EmployeeYOECollection = from eachEmployee in Employees
							select new 
							{
								name = eachEmployee.LastName + " " + eachEmployee.FirstName,
								YOE = eachEmployee.EmployeeSkills.Sum(x => x.YearsOfExperience)
							};
							EmployeeYOECollection.Dump();
							
var MaxYOE = EmployeeYOECollection.Max(x => x.YOE);
MaxYOE.Dump();

var finalList = from final in EmployeeYOECollection
				where final.YOE == MaxYOE
				select final.name;
finalList.Dump();