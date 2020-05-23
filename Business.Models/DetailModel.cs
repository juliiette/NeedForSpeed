namespace Business.Models
{
    public class DetailModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public DetailTypeModel DetailType { get; set; }
        
        public int RetailCost { get; set; }

        public int RepairCost { get; set; }

        public double Stability { get; set; }

        public bool CanFunction { get; set; }
        
    }

    public enum DetailTypeModel
    {
        Motor,
        Rim,
        Battery
    }
}