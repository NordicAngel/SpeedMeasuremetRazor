using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedMeasuremetRazor.Interfaces;
using SpeedMeasuremetRazor.Models;

namespace SpeedMeasuremetRazor.Pages.Locations
{
    public class CreateLocationModel : PageModel
    {
        private ILocationRepo _location;
        [BindProperty] public Location Location { get; set; }

        public CreateLocationModel(ILocationRepo location)
        {
            _location = location;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            Location.Id = _location.GetAllLocations().Count == 0 ? 1 : _location.GetAllLocations().Max(x => x.Id) + 1;
            _location.AddLocation(Location);
            return Redirect("/locations/");
        }
    }
}
