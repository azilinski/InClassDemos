<Query Kind="Expression">
  <Connection>
    <ID>ead8a9c1-928c-4535-866f-e70bef14340c</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

//anonymous
from food in Items
where food.MenuCategory.Description.Equals("Entree") &&
		food.Active
orderby food.CurrentPrice descending
select new
	{
		Description = food.Description,
		Price = food.CurrentPrice,
		Cost = food.CurrentCost,
		Profit = food.CurrentPrice - food.CurrentCost
	}