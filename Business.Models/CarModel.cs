namespace Business.Models
{
    public class CarModel
    {
        public int Id { get; set; }

        public DetailModel Motor { get; set; }

        public DetailModel Rim { get; set; }

        public DetailModel Battery { get; set; }

        public int Distance { get; set; }

        public bool CanRide { get; set; }
    }
}