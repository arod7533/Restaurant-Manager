using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Reservations
    {
        public Reservations()
        {
            ReservationItems = new HashSet<ReservationItems>();
        }

        public int RNum { get; set; }
        public DateTime RDate { get; set; }
        public TimeSpan RTime { get; set; }
        public int RCnum { get; set; }
        public decimal? RSubtotal { get; set; }
        public decimal? RPaid { get; set; }
        public int? RTable { get; set; }

        public Customers RCnumNavigation { get; set; }
        public ICollection<ReservationItems> ReservationItems { get; set; }
    }
}
