using SailingAppClean.Domain.Entities;

namespace SaillingAppClean.Web.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Ship> ShipList { get; set; }
        public DateOnly EmbarkationDate { get; set; }
        public DateOnly DisembarkationDate { get; set; }
    }
}
