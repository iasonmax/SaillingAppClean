using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

    }
}
