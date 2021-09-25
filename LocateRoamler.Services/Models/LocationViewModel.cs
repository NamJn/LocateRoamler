using System.Collections.Generic;

namespace LocateRoamler.Services.Models
{
    public class LocationViewModel
    {
        public LocationViewModel()
        {
            SearchResults = new List<LocationResultModel>();
        }
        public double OriginLongitude { get; set; }
        public double OriginLatitude { get; set; }
        public double SelectedMaxDistance { get; set; }
        public int SelectedMaxResult { get; set; }
        public IEnumerable<LocationResultModel> SearchResults { get; set; }
    }
}
