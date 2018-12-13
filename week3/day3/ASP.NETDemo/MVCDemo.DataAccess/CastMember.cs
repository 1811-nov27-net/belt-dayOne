namespace MVCDemo.DataAccess
{
    public class CastMember
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Movie Movie { get; set; }
    }
}