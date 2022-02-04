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
    public class EditLocationModel : PageModel
    {
        private ILocationRepo _location;
        private int _locationId;
        [BindProperty]
        public Location Location { get; set; }

        public EditLocationModel(ILocationRepo location)
        {
            _location = location;
        }

        public void OnGet(int id)
        {
            Location = _location.GetLocation(id);
            _locationId = Location.Id;
        }

        public IActionResult OnPost(int id)
        {
            Location.Id = id;
            _location.UpdateLocation(Location);
            return Redirect("/locations/");
        }
    }
}
