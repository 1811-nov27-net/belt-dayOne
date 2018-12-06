using System;
using System.Collections.Generic;

namespace EFDBFirstDemo.DataAccess
{
    public partial class Department
    {
        public Department()
        {
            Employee = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
