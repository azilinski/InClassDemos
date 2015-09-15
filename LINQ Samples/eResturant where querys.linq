<Query Kind="Expression">
  <Connection>
    <ID>ead8a9c1-928c-4535-866f-e70bef14340c</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

// simple where clause

//list all tables that hold more than 3 peolple
from row in Tables
where row.Capacity > 3
select row

//list all items with more than 500 Cal
from row in Items
where row.Calories > 500
select row

//list all food items with more than 500 cal and sells for more than 10.00
from row in Items
where row.Calories > 500 && row.CurrentPrice > 10
select row

//list all food items with more than 500 cal and are entres on the menu
from row in Items
where row.Calories > 500 && row.MenuCategoryID == 5
select row

//list all food items with more than 500 cal and are entres on the menu
from row in Items
where row.Calories > 500 && row.MenuCategory.Description.Equals("Entree")
select row