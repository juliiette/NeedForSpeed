using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity
{
    public class Car : BaseEntity<int>
    {
        [ForeignKey("MotorId")]
        public Detail Motor { get; set; }
        public int? MotorId { get; set; }

        [ForeignKey("RimId")]
        public Detail Rim { get; set; }
        public int? RimId { get; set; }

        [ForeignKey("BatteryId")]
        public Detail Battery { get; set; }
        public int? BatteryId { get; set; }

        public int Distance { get; set; }

        public bool CarRide { get; set; }
    }
}