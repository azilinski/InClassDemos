using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eResturauntSystem.Entities.POCOs
{
    public class ReservationDetail
    {
        //Note NO validation in POCO classes
        public string CustomerName{get; set;}
        public DateTime ReservationDate { get; set; }
        public int NumberInParty { get; set; }
        public string ContactPhone { get; set; }
        public string ReservationStatus { get; set; }
    }
}
