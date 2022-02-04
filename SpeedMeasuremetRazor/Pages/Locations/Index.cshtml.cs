using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedMeasuremetRazor.Interfaces;

namespace SpeedMeasuremetRazor.Pages.Locations
{
    public class IndexModel : PageModel
    {
        private ILocationRepo _location;

        public IndexModel(ILocationRepo location)
        {
            _location = location;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPostDelete(int id)
        {
            _location.DeleteLocation(id);
            return RedirectToPage();
        }
    }
}
