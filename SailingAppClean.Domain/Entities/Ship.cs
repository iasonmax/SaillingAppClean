using System.ComponentModel.DataAnnotations;

namespace SailingAppClean.Domain.Entities
{
    public class Ship
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        [Display(Name = "Daily Rate")]
        public double BaseDailyRate { get; set; }
        public int Capacity { get; set; }
        [Display(Name = "Home Port")]
        public required string HomePort { get; set; }
        public string? Damages { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime PurchasedDate { get; set; }

        public DateTime LastMaintenanceDate { get; set; }

    }
}
