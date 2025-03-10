using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SailingAppClean.Domain.Entities
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        [Required]
        public int ShipId { get; set; }
        [ForeignKey("ShipId")]
        public Ship Ship { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }

        [Required]
        public double TotalCost { get; set; }
        public string? Status { get; set; }

        [Required]
        public DateTime BookingTime { get; set; }
        [Required]
        public DateOnly CheckInDate { get; set; }
        [Required]
        public DateOnly CheckOutDate { get; set; }
        [NotMapped]
        public int Nights { get; set; }

        public bool IsPaymentSuccessfull { get; set; }
        public DateTime PaymentDate { get; set; }

        public string? StripeSessionId { get; set; }
        public string? StripePaymentIntentId { get; set; }

        public DateTime ActualCheckInDate { get; set; }
        public DateTime ActualCheckOutDate { get; set; }




    }
}
