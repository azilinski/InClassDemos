using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using eResturauntSystem.Entities;
using eResturauntSystem;
using eResturauntSystem.DAL;
using System.ComponentModel;
using eResturauntSystem.Entities.DTO;
using eResturauntSystem.Entities.POCOs; // use for ODS access

#endregion

namespace eResturauntSystem.BLL
{
    [DataObject]
    public class AdminController
    {
        #region Query Samples
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<SpecialEvent> SpecialEvent_List()
        {
            using (var context = new eRestaurantContext())
            {
                //Retrive the data from the special events table on sql
                //to do so we will use the DbSet in eResturantContext called SpecialEvents

                //method syntax
                //return context.SpecialEvents.OrderBy(x => x.Description).ToList();

                //query syntax
                var results = from item in context.SpecialEvents
                              orderby item.Description
                              select item;
                return results.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Reservation> GetReservationsByEventCode(string eventcode)
        {
            using (var context = new eRestaurantContext())
            {
               
                var results = from item in context.Reservations
                              where item.EventCode.Equals(eventcode)
                              orderby item.CustomerName, item.ReservationDate
                              select item;
                return results.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<ReservationByDate> GetReservationsByDate(string reservationdate)
        {
            using (var context = new eRestaurantContext())
            {
                //remember Linq does not like using DateTime casting
                int theYear = (DateTime.Parse(reservationdate)).Year;
                int theMonth = (DateTime.Parse(reservationdate)).Month;
                int theDay = (DateTime.Parse(reservationdate)).Day;

                //query syntax
                var results = from item in context.SpecialEvents
                              orderby item.Description
                              select new ReservationByDate()
                              {
                                  Description = item.Description,
                                  //colletion of navigated rows of ICollection
                                  Reservations = from row in item.Reservations
                                                 where row.ReservationDate.Year == theYear
                                                 && row.ReservationDate.Month == theMonth
                                                 && row.ReservationDate.Day == theDay
                                                 select new ReservationDetail()
                                                 {
                                                     CustomerName = row.CustomerName,
                                                     ReservationDate = row.ReservationDate,
                                                     NumberInParty = row.NumberInParty,
                                                     ContactPhone = row.ContactPhone,
                                                     ReservationStatus = row.ReservationStatus
                                                 }
                              };
                return results.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<eResturauntSystem.Entities.DTO.CategoryMenuItems> CategoryMenuItems_List()
        {
            using (var context = new eRestaurantContext())
            {

                //query syntax
                var results = from category in context.MenuCategories
                              orderby category.Description
                              select new eResturauntSystem.Entities.DTO.CategoryMenuItems()
                              {
                                  Description = category.Description,
                                  //colletion of navigated rows of ICollection
                                  MenuItems = from row in category.MenuItems
                                                 select new MenuItem()
                                                 {
                                                     Description = row.Description,
                                                     Price = row.CurrentPrice,
                                                     Calories = row.Calories,
                                                     Comment = row.Comment
                                                 }
                              };
                return results.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Waiter> Waiter_List()
        {
            using (var context = new eRestaurantContext())
            {
                var results = from item in context.Waiters
                              orderby item.LastName, item.FirstName
                              select item;
                return results.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public Waiter GetWaiterByID(int waiterID)
        {
            using (var context = new eRestaurantContext())
            {
                var results = from item in context.Waiters
                              where item.WaiterID == waiterID
                              select item;
                return results.FirstOrDefault();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<eResturauntSystem.Entities.POCOs.CategoryMenuItems> GetReportCategoryMenuItems()
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                var results = from cat in context.Items
                              orderby cat.Category.Description, cat.Description
                              select new eResturauntSystem.Entities.POCOs.CategoryMenuItems
                              {
                                  CategoryDescription = cat.Category.Description,
                                  ItemDescription = cat.Description,
                                  Price = cat.CurrentPrice,
                                  Calories = cat.Calories,
                                  Comment = cat.Comment
                              };

                return results.ToList(); // this was .Dump() in Linqpad
            }
        }

#endregion
        #region CRUD Insert Update Delete
        [DataObjectMethod(DataObjectMethodType.Insert,false)]
        public void SpecialEvents_Add(SpecialEvent item)
        {
            //input into this method is at the instance level
            using (eRestaurantContext context = new eRestaurantContext())
            {
                //create a pointer variable for the instance type
                //set this pointer to null
                SpecialEvent added = null;

                //set up the add request for the dbcontext
                added = context.SpecialEvents.Add(item);

                //saving the changes will cause the .Add to execute
                //commits the add to the database
                //evaluates the Annotation
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update,false)]
        public void SpecialEvents_Update(SpecialEvent item)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                context.Entry<SpecialEvent>(context.SpecialEvents.Attach(item)).State 
                    = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public void SpecialEvents_Delete(SpecialEvent item)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                //lookup the instance on the database to check if it exsists
                SpecialEvent exisiting = context.SpecialEvents.Find(item.EventCode);
                //set up the delete requset command
                context.SpecialEvents.Remove(exisiting);
                //commit the action to happen
                context.SaveChanges();
            }
        }
        #endregion
        #region CRUD Insert Update Delete Waiter
        [DataObjectMethod(DataObjectMethodType.Insert, false)]
        public void Waiter_Add(Waiter item)
        {
            //input into this method is at the instance level
            using (eRestaurantContext context = new eRestaurantContext())
            {
                //create a pointer variable for the instance type
                //set this pointer to null
                Waiter added = null;

                //set up the add request for the dbcontext
                added = context.Waiters.Add(item);

                //saving the changes will cause the .Add to execute
                //commits the add to the database
                //evaluates the Annotation
                context.SaveChanges();
            }
        }
        public int Waiter_Add_r_WaiterID(Waiter item)
        {
            //input into this method is at the instance level
            using (eRestaurantContext context = new eRestaurantContext())
            {
                //create a pointer variable for the instance type
                //set this pointer to null
                Waiter added = null;

                //set up the add request for the dbcontext
                added = context.Waiters.Add(item);

                //saving the changes will cause the .Add to execute
                //commits the add to the database
                //evaluates the Annotation
                context.SaveChanges();
                //added contains the data of the newly added waiter including the pkey value.
                return added.WaiterID; 

            }
        }


        [DataObjectMethod(DataObjectMethodType.Update, false)]
        public void Waiter_Update(Waiter item)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                context.Entry<Waiter>(context.Waiters.Attach(item)).State
                    = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public void Waiter_Delete(Waiter item)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                //lookup the instance on the database to check if it exsists
                Waiter exisiting = context.Waiters.Find(item.WaiterID);
                //set up the delete requset command
                context.Waiters.Remove(exisiting);
                //commit the action to happen
                context.SaveChanges();
            }
        }
        #endregion

        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<WaiterBilling> GetWaiterBillingReport()
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                var results = from abillrow in context.Bills
                              where abillrow.BillDate.Month == 5
                              orderby abillrow.BillDate, abillrow.Waiter.LastName, abillrow.Waiter.FirstName
                              select new WaiterBilling
                              {
                                  BillDate = new DateTime(
                                      //abillrow.BillDate.Year, abillrow.BillDate.Month, abillrow.BillDate.Day
                                      ),
                                  Name = abillrow.Waiter.LastName + ", " + abillrow.Waiter.FirstName,
                                  BillID = abillrow.BillID,
                                  BillTotal = abillrow.Items.Sum(bitem => bitem.Quantity * bitem.SalePrice),
                                  PartySize = abillrow.NumberInParty,
                                  Contact = abillrow.Reservation.CustomerName
                              };
                return results.ToList();
            }
        }
    }//class
}//namespace
