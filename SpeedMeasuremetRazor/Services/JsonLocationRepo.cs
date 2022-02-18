using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SpeedMeasuremetRazor.Helpers;
using SpeedMeasuremetRazor.Interfaces;
using SpeedMeasuremetRazor.Models;

namespace SpeedMeasuremetRazor.Services
{
    public class JsonLocationRepo : ILocationRepo
    {
        private const string FilePath =
            @"C:\Users\User\OneDrive\Zealand\SWC\MyApps 2\SpeedMeasuremetRazor\SpeedMeasuremetRazor\Data\LocationData.json";
        public List<Location> GetAllLocations()
        {
            return JsonFileReader.ReadJson<Location>(FilePath);
        }

        public void AddLocation(Location location)
        {
            List<Location> repo = GetAllLocations();
            repo.Add(location);
            JsonFileWriter.WriteJson(repo, FilePath);
        }

        public void UpdateLocation(Location location)
        {
            List<Location> repo = GetAllLocations();
            int i = repo.FindIndex(l => l.Id == location.Id);
            if (i >=0)
            {
                repo[i] = location;
                JsonFileWriter.WriteJson(repo,FilePath);
            }
        }

        public Location GetLocation(int id)
        {
            return GetAllLocations().Find(l => l.Id == id);
        }

        public void DeleteLocation(int id)
        {
            List<Location> repo = GetAllLocations();
            repo.RemoveAll(l => l.Id == id);
            JsonFileWriter.WriteJson(repo, FilePath);
        }
    }
}
