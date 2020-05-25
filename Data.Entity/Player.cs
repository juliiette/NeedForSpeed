namespace Data.Entity
{
    public class Player : BaseEntity<int>
    {
        public string Name { get; set; }

        public Car Car { get; set; }

        public int Cash { get; set; }
    }
}