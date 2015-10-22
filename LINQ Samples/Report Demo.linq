<Query Kind="Expression">
  <Connection>
    <ID>ead8a9c1-928c-4535-866f-e70bef14340c</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

from abillrow in Bills
where abillrow.BillDate.Month == 5
orderby abillrow.BillDate, abillrow.Waiter.LastName, abillrow.Waiter.FirstName
select new
{
	BillDate = new DateTime(abillrow.BillDate.Year, abillrow.BillDate.Month, abillrow.BillDate.Day),
	Name = abillrow.Waiter.LastName + ", " + abillrow.Waiter.FirstName,
	BillID = abillrow.BillID,
	BillTotal = abillrow.BillItems.Sum(bitem=> bitem.Quantity * bitem.SalePrice),
	PartySize = abillrow.NumberInParty,
	Contact = abillrow.Reservation.CustomerName
}