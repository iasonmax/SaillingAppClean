using Microsoft.AspNetCore.Mvc.Rendering;
using SailingAppClean.Domain.Entities;

namespace SaillingAppClean.Web.ViewModels
{
    public class ShipVm
    {
        public Ship Ship { get; set; }

        public IEnumerable<SelectListItem>? CategoryList { get; set; }
    }
}
