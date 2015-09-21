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
    public class SpecialEvent
    {
        [Key]
        [Required(ErrorMessage="an Event Code is Required (only one character)")]
        [StringLength(1,ErrorMessage="Event code can only use a single character code")]
        public string EventCode { get; set; }
        [Required(ErrorMessage = "Description is Required(5-30 Characters")]
        [StringLength(30, MinimumLength=5, ErrorMessage="Description must be 5-30 characters in length")]
        public string Description { get; set; }
        public bool Active { get; set; }

        //Navigation virtual property(s)
        public virtual ICollection<Reservation> Reservations { get; set; }

        // all classes can have there own constructor
        //constructors can contain initization values

        public SpecialEvent()
        {
            Active = true;
        }

    }
}
