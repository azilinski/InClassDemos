using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using eResturauntSystem.Entities;
using eResturauntSystem.DAL;
using System.ComponentModel; // use for ODS access

#endregion

namespace eResturauntSystem.BLL
{
    [DataObject]
    public class AdminController
    {
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<SpecialEvent> SpecialEvent_List()
        {
            using (var context = new eRestaurantContext())
            {
                //Retrive the data from the special events table on sql
                //to do so we will use the DbSet in eResturantContext called SpecialEvents

                //method syntax
                return context.SpecialEvents.OrderBy(x => x.Description).ToList();

            }
        }
    }
}
