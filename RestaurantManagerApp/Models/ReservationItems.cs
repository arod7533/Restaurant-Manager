using System;
using System.Collections.Generic;

namespace RestaurantManagerApp.Models
{
    public partial class ReservationItems
    {
        public int RiNum { get; set; }
        public int RiItemNum { get; set; }
        public int RiResNum { get; set; }
        public int? RiStatus { get; set; }

        public Items RiItemNumNavigation { get; set; }
        public Reservations RiResNumNavigation { get; set; }
        public EmployeeInfo RiStatusNavigation { get; set; }
    }
}
