using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eResturauntSystem.Entities.DTO
{
    public class ReservationByDate
    {
        public string Description { get; set; }
        //the rest of the daata will be a colection of POCO rows
        //the actaul POCO will be defined in the link query
        public IEnumerable Reservations { get; set; }
    }
}
