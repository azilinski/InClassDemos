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
    public class Reservation
    {
        [Key]
        public int ReservationID { get; set; }
        [Required]
        [StringLength(40)]
        public string CustomerName { get; set; }
        public DateTime ReservationDate { get; set; }
        [Range(1,16,ErrorMessage="Party size is limmeted to 1-16")]
        public int NumberInParty { get; set; }
        [StringLength(15)]
        public string ContactPhone { get; set; }
        [Required, StringLength(1, MinimumLength=1)]
        public string ReservationStatus { get; set; }
        [StringLength(1)]
        public string EventCode { get; set; }

        //Navigation
        public virtual SpecialEvent Event { get; set; }
        //public virtual ICollection<Bills> Bills { get; set; }
        // the Reservations table is a many to many relationship with Tables table
        // the sql resolves this problem however reservationTables table holds only
        // a compound primary key. We will no create this table, but will handle it 
        // via navigation mapping. Therefore we will use a ICollection in this entity
        // refering to the Tables table
        public virtual ICollection<Table> Tables { get; set; }
    }
}
