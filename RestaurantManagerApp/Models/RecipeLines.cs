using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class RecipeLines
    {
        public int RlNum { get; set; }
        public int RlItemNum { get; set; }
        public int RlInvNum { get; set; }
        public int RlQty { get; set; }

        public Inventory RlInvNumNavigation { get; set; }
        public Items RlItemNumNavigation { get; set; }
    }
}
