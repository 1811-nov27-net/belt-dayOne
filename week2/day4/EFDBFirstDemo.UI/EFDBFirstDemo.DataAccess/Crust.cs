using System;
using System.Collections.Generic;

namespace EFDBFirstDemo.DataAccess
{
    public partial class Crust
    {
        public Crust()
        {
            Pizza = new HashSet<Pizza>();
        }

        public int CrustId { get; set; }
        public string Name { get; set; }
        public bool? Active { get; set; }
        public string InternalName { get; set; }

        public virtual ICollection<Pizza> Pizza { get; set; }
    }
}
