<Query Kind="Expression">
  <Connection>
    <ID>ead8a9c1-928c-4535-866f-e70bef14340c</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

//orderby

//default ascending
from food in Items
orderby food.Description
select food

//default decending
from food in Items
orderby food.Description descending
select food

//both
from food in Items
orderby food.Description descending, food.Calories ascending
select food

//both
from food in Items
where food.MenuCategory.Description.Equals("Entree")
orderby food.Description descending, food.Calories ascending
select food
