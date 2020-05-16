namespace Data.Entity
{
    public class Car : BaseEntity
    {
        public Detail Motor { get; set; }

        public Detail Rim { get; set; }

        public Detail Battery { get; set; }

        public int Distance { get; set; }

        public bool CarRide { get; set; }
    }
}