using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpeedMeasuremetRazor.Helpers;
using SpeedMeasuremetRazor.Interfaces;
using SpeedMeasuremetRazor.Models;

namespace SpeedMeasuremetRazor.Services
{
    public class JsonSpeedMeasurementRepo : ISpeedMeasurementRepo
    {
        private const string FilePath =
            @"C:\Users\User\OneDrive\Zealand\SWC\MyApps 2\SpeedMeasuremetRazor\SpeedMeasuremetRazor\Data\SpeedMeasurementData.json";
        public List<SpeedMeasurement> GetAllSpeedMeasurements()
        {
            return JsonFileReader.ReadJson<SpeedMeasurement>(FilePath);
        }

        public void AddSpeedMeasurement(int speed, Location location, string imageName)
        {
            if (speed > 300 || speed <= 0)
                throw new Exceptions.CalibrationException($"Speed must be between 0 and 300, {speed} does not fulfill this");
            
            List<SpeedMeasurement> repo = GetAllSpeedMeasurements();
            
            repo.Add(new SpeedMeasurement()
            {
                Id = repo.Count == 0 ? 1 : repo.Max(x => x.Id) + 1,
                Speed = speed,
                Location = location,
                ImageName = imageName,
                Timestamp = DateTime.Now
            });

            JsonFileWriter.WriteJson(repo, FilePath);
        }

        public double AvarageSpeed()
        {
            return JsonFileReader.ReadJson<SpeedMeasurement>(FilePath).Average(s => s.Speed);
        }

        public int NoOfOverSpeedLimit()
        {
            return JsonFileReader.ReadJson<SpeedMeasurement>(FilePath).Count(x => x.Speed > x.Location.SpeedLimit);
        }

        public int NoOfCutInLicense()
        {
            return JsonFileReader.ReadJson<SpeedMeasurement>(FilePath)
                .Count(x => x.Speed > x.Location.SpeedLimit * 1.3);
        }

        public int NoOfCutInLicenseForeach()
        {
            throw new NotImplementedException();
        }

        public int NoOfConditionalRevocation()
        {
            return JsonFileReader.ReadJson<SpeedMeasurement>(FilePath)
                .Count(x => x.Location.Zone == Zone.Motorvej && x.Location.SpeedLimit >= 130 ?
                x.Speed > x.Location.SpeedLimit * 1.3 :
                x.Speed > x.Location.SpeedLimit * 1.6);
        }

        public void DeleteSpeedMeasurement(int id)
        {
            List<SpeedMeasurement> repo = JsonFileReader.ReadJson<SpeedMeasurement>(FilePath);
            repo.RemoveAll(s => s.Id == id);
            JsonFileWriter.WriteJson(repo, FilePath);
        }
    }
}
