using System.Collections.Generic;

namespace MVCDemo.DataAccess
{
    public class CastMember
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<MovieCastMemberJunction> MovieJunctions { get; set; }
    }
}