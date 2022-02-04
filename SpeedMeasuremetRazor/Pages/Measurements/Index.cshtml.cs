using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedMeasuremetRazor.Interfaces;

namespace SpeedMeasuremetRazor.Pages.Measurements
{
    public class IndexModel : PageModel
    {
        private ISpeedMeasurementRepo _measurement;

        public IndexModel(ISpeedMeasurementRepo measurement)
        {
            _measurement = measurement;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPostDelete(int id)
        {
            _measurement.DeleteSpeedMeasurement(id);
            return RedirectToPage();
        }
    }
}
