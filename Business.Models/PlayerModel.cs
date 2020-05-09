namespace Business.Models
{
    public class PlayerModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public CarModel Car { get; set; }

        public int Cash { get; set; }
    }
}