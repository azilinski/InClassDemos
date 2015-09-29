using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using eResturauntSystem.Entities;
using System.Data.Entity;

#endregion

namespace eResturauntSystem.DAL
{
    //this class should be restricted to access by only the BLL methods
    //this class should not be accessable outside of the componet library
    //this class inherts DbContext
    internal class eRestaurantContext : DbContext
    {
        public eRestaurantContext() : base ("name=EatIn")
        {
            //constructor is used to pass in web config string name
        }
        //setup the DbSet Mappings
        public DbSet<SpecialEvent> SpecialEvents { get; set;}
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Table> Tables { get; set; }
        
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillItem> BillItems { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<MenuCategory> MenuCategories { get; set; }
        public DbSet<Waiter> Waiters { get; set; }

        //When overridding OnModleCreating it is important to remember to call the base methods implementation before you exit the method
        //The ManyTOManyNavigationPropertyCOnfiguration.Map method allows you to configure the tables and colums used for many-to-many
        // relationship. It takes a ManytoManyNavigationPropertyConfiguration instance in which you specify the collom names by calling 
        // the MapLeftKey,MApRightKey, and ToTable Methods.
        //The "left" key is the one specified in the HasMany Method
        //The "right" key is the one specified in the WithMany Method

        //We have a many to many relationship between reservation and tables a reservation may need many tables. a table can have many reservations over time

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Reservation>().HasMany(r => r.Tables)
                .WithMany(x => x.Reservations)
                .Map(mapping =>
                {
                    mapping.ToTable("ReservationTables");
                    mapping.MapLeftKey("TableID");
                    mapping.MapRightKey("ReservationID");
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}
