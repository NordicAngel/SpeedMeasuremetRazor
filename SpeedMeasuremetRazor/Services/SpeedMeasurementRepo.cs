using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpeedMeasuremetRazor.Helpers;
using SpeedMeasuremetRazor.Interfaces;
using SpeedMeasuremetRazor.Models;

namespace SpeedMeasuremetRazor.Services
{
    public class SpeedMeasurementRepo : ISpeedMeasurementRepo
    {
        private List<SpeedMeasurement> _repo;

        public SpeedMeasurementRepo()
        {
            _repo = MockData.Measurements;
        }

        public List<SpeedMeasurement> GetAllSpeedMeasurements()
        {
            return _repo;
        }

        public void AddSpeedMeasurement(int speed, Location location, string imageName)
        {
            _repo.Add(new SpeedMeasurement()
            {
                Id = _repo.Count == 0 ? 1 : _repo.Max(x => x.Id) + 1,
                Speed = speed,
                Location = location,
                ImageName = imageName,
                Timestamp = DateTime.Now
            });
        }

        public double AvarageSpeed()
        {
            return _repo.Average(x => x.Speed);
        }

        public int NoOfOverSpeedLimit()
        {
            return _repo.Count(x => x.Speed > x.Location.SpeedLimit);
        }

        public int NoOfCutInLicense()
        {
            return _repo.Count(x => x.Speed > x.Location.SpeedLimit * 1.3);
        }

        public int NoOfCutInLicenseForeach()
        {
            throw new NotImplementedException();
        }

        public int NoOfConditionalRevocation()
        {
            return _repo.Count(x => x.Location.Zone == Zone.Motorvej && x.Location.SpeedLimit >= 130?
                x.Speed > x.Location.SpeedLimit * 1.3 :
                x.Speed > x.Location.SpeedLimit * 1.6);
        }

        public void DeleteSpeedMeasurement(int id)
        {
            _repo.RemoveAt(_repo.FindIndex(x => x.Id == id));
        }
    }
}
