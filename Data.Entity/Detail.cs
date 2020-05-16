namespace Data.Entity
{
    public class Detail : BaseEntity
    {
        public DetailType DetailType { get; set; }
        
        public int RetailCost { get; set; }

        public int RepairCost { get; set; }

        public double Stability { get; set; }

        public bool CanFunction { get; set; }
    }
    
    public enum DetailType
    {
        Motor, Rim, Battery
    }
}