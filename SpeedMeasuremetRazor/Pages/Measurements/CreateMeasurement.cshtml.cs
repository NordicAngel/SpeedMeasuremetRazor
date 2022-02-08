using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedMeasuremetRazor.Helpers;
using SpeedMeasuremetRazor.Interfaces;
using SpeedMeasuremetRazor.Models;

namespace SpeedMeasuremetRazor.Pages.Measurements
{
    public class CreateMeasurementModel : PageModel
    {
        private ISpeedMeasurementRepo _measurement;
        [BindProperty] public Location Location { get; set; }
        public string Error { get; set; }

        public CreateMeasurementModel(ISpeedMeasurementRepo measurement)
        {
            _measurement = measurement;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            SpeedMeasurement m = new SpeedMeasurement();
            m.Speed = new Random().Next(-20, 375);
            m.Location = Location;
            m.ImageName = MockData.RandomImage; 
            try
            {
                _measurement.AddSpeedMeasurement(m.Speed, m.Location, m.ImageName);
            }
            catch (Exceptions.CalibrationException e)
            {
                Error = $"{e.Message}";
                return null;
            }
            return Redirect("/Measurements/");
        }
    }
}
