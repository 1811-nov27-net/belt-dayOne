using System;
using System.Collections.Generic;

namespace EFDBFirstDemo.DataAccess
{
    public partial class Pizza
    {
        public int PizzaId { get; set; }
        public string Name { get; set; }
        public int CrustId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string CreatorName { get; set; }
        public string InternalName { get; set; }

        public virtual Crust Crust { get; set; }
    }
}
