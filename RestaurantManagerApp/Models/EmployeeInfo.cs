using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class EmployeeInfo
    {
        public EmployeeInfo()
        {
            ReservationItems = new HashSet<ReservationItems>();
        }

        public int ENum { get; set; }
        public string EName { get; set; }
        public int ELevel { get; set; }

        public ICollection<ReservationItems> ReservationItems { get; set; }
    }
}
