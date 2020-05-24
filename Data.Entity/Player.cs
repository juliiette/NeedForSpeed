namespace Data.Entity
{
    public class Player : BaseEntity
    {
        public string Name { get; set; }

        public Car Car { get; set; }

        public int Cash { get; set; }
    }
}