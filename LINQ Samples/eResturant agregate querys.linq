<Query Kind="Expression">
  <Connection>
    <ID>ead8a9c1-928c-4535-866f-e70bef14340c</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

from category in MenuCategories
select new
{
	Category = category.Description,
	Items = category.Items.Count()
}

from category in MenuCategories
select new
{
	Category = category.Description,
	Items = (from x in category.Items select x).Count()
}

(from theBill in BillItems
	where theBill.BillID == 104
	select theBill.SalePrice * theBill.Quantity).Sum()
	
BillItems
	.Where (theBill => theBill.BillID == 104)
	.Select (theBill => theBill.SalePrice * theBill.Quantity)
	.Sum()
	
(from customer in Bills
where customer.PaidStatus == true
select customer.BillItems.Sum(theBill => theBill.SalePrice * theBill.Quantity)).Max()

(from customer in Bills
where customer.PaidStatus == true
select customer.BillItems.Sum(theBill => theBill.SalePrice * theBill.Quantity)).Min()

//(from theBill in BillItems
//	where theBill.Bill.PaidStatus == true
//	select theBill.Quantity).Average()
	
(from customer in Bills
where customer.PaidStatus == true
select customer.BillItems.Count()).Average()