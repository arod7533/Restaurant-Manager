using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Orders
    {
        public int ONum { get; set; }
        public int OInvNum { get; set; }
        public int OQuant { get; set; }

        public Inventory OInvNumNavigation { get; set; }
    }
}
