namespace Data.Entity
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public Car Car { get; set; }

        public int Cash { get; set; }
    }
}