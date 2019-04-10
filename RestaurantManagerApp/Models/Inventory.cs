using System;
using System.Collections.Generic;

namespace RestaurantManagerApp.Models
{
    public partial class Inventory
    {
        public Inventory()
        {
            Orders = new HashSet<Orders>();
            RecipeLines = new HashSet<RecipeLines>();
        }

        public int InvNum { get; set; }
        public string InvDesc { get; set; }
        public int InvQoh { get; set; }
        public int InvPar { get; set; }

        public ICollection<Orders> Orders { get; set; }
        public ICollection<RecipeLines> RecipeLines { get; set; }
    }
}
