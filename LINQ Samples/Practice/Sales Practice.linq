<Query Kind="Statements">
  <Connection>
    <ID>9250782d-312b-4922-8f64-fcac259d07c3</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eTools</Database>
  </Connection>
</Query>

var Query1 = from item in StockItems
group item by item.CategoryID into g
select g;

var end = from list in Query1
select new{
	Category = from thingy in Categories
				where  thingy.CategoryID == list.Key
				select thingy.Description,	
	
	Description = from thing in list
	 				select thing.Description
};

end.Dump();