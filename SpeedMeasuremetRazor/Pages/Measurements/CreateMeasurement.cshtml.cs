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
        [BindProperty] public SpeedMeasurement SpeedMeasurement { get; set; }

        public CreateMeasurementModel(ISpeedMeasurementRepo measurement)
        {
            _measurement = measurement;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            SpeedMeasurement.ImageName = MockData.RandomImage;
            _measurement.AddSpeedMeasurement(SpeedMeasurement.Speed, SpeedMeasurement.Location, SpeedMeasurement.ImageName);
            return Redirect("/Measurements/");
        }
    }
}
