using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpeedMeasuremetRazor.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public int SpeedLimit { get; set; }
        public Zone Zone { get; set; }

        public Location(int id, string address, int speedLimit, Zone zone)
        {
            Id = id;
            Address = address;
            SpeedLimit = speedLimit;
            Zone = zone;
        }

        public Location()
        {
            
        }
    }
}
