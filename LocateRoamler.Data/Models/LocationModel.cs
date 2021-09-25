using System;
using System.ComponentModel.DataAnnotations;

namespace LocateRoamler.Data.Models
{
    public class LocationModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
