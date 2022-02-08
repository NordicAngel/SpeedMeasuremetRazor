using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SpeedMeasuremetRazor.Helpers;
using SpeedMeasuremetRazor.Interfaces;
using SpeedMeasuremetRazor.Models;

namespace SpeedMeasuremetRazor.Services
{
    

    public class LocationRepo : ILocationRepo
    {
        private List<Location> _locations;

        public LocationRepo()
        {
            _locations = MockData.Locations;
        }

        public List<Location> GetAllLocations()
        {
            return _locations;
        }

        public void AddLocation(Location location)
        {
            if (_locations.Exists(x => x.Id == location.Id))
                throw new Exceptions.UniqIdException("A Location with this id already exits");
            _locations.Add(location);
        }

        public void UpdateLocation(Location location)
        {
            int i = _locations.FindIndex(x => x.Id == location.Id);
            if (i >= 0)
            {
                _locations[i] = location; 
            }
        }

        public Location GetLocation(int id)
        {
            return _locations.Find(x => x.Id == id);
        }

        public void DeleteLocation(int id)
        {
            _locations.RemoveAll(x => x.Id == id);
        }
    }
}
