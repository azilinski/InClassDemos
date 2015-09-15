<Query Kind="Statements">
  <Connection>
    <ID>ead8a9c1-928c-4535-866f-e70bef14340c</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

// step 1 connect to the desired database
//click on add connection
//take defaults, press next
//change server to . select exsiting database from dropdown list
// test the conection then press OK
//remeber to make sure that the database is the active connection

//result should show database tables in conection object area
//expanding the table reveal atributes and relationships

//view Waiter data
Waiters

//query syntax to view waiter data
from item in Waiters
select item
//method syntax to view waiter data
Waiters.Select (item => item)

//from query syntax to C#
var results = from item in Waiters
				select item;
	results.Dump();
	
//once the query is create, tested, you will be able to
//transfer the query with minor modifications into your
//BLL methods
	//public List<pocoObject> SomeBLLMetodName()
	//{
	//	//content to your DAL object : var contexvariable
	//	//do you query
	//var results = from item in contectvariableWaiters
	//			select item;
	//return results.ToList();
	//}
