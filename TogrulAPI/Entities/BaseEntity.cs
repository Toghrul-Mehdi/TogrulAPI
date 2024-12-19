namespace TogrulAPI.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; } 
        public DateTime DateTime { get; set; }= DateTime.Now;
        public bool IsDeleted { get; set; }
    }
}
