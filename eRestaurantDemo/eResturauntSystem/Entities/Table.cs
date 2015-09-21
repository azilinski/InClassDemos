using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
#endregion

namespace eResturauntSystem.Entities
{
    public class Table
    {
        [Key]
        public int TableID { get; set; }
        [Required, Range(1,25)]
        public byte TableNumber { get; set; }
        public bool Smoking { get; set; }
        public int Capacity { get; set; }
        public bool Available { get; set; }

        //Navigation
        //public virtual ICollection<Bills> Bills { get; set; }
        // the Reservations table is a many to many relationship with Tables table
        // the sql resolves this problem however reservationTables table holds only
        // a compound primary key. We will no create this table, but will handle it 
        // via navigation mapping. Therefore we will use a ICollection in this entity
        // refering to the Reservation table
        public virtual ICollection<Reservation> Reservations { get; set; }

        public Table()
        {
            Available = true;
        }
    }
}
