using System;
using System.Collections.Generic;

namespace RestaurantManagerApp.Models
{
    public partial class Items
    {
        public Items()
        {
            RecipeLines = new HashSet<RecipeLines>();
            ReservationItems = new HashSet<ReservationItems>();
        }

        public int ItemNum { get; set; }
        public string ItemName { get; set; }
        public string ItemDesc { get; set; }
        public decimal ItemPrice { get; set; }

        public ICollection<RecipeLines> RecipeLines { get; set; }
        public ICollection<ReservationItems> ReservationItems { get; set; }
    }
}
