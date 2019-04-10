using System;
using System.Collections.Generic;

namespace RestaurantManagerApp.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Reservations = new HashSet<Reservations>();
        }

        public int CNum { get; set; }
        public string CLname { get; set; }
        public string CFname { get; set; }
        public string CAddy { get; set; }
        public string CEmail { get; set; }
        public int CCcnum { get; set; }

        public ICollection<Reservations> Reservations { get; set; }
    }
}
