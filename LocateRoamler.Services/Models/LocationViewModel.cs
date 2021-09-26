using System.Collections.Generic;

namespace LocateRoamler.Services.Models
{
    public class LocationViewModel
    {
        public LocationViewModel()
        {
            SearchResults = new List<LocationResultModel>();
        }

        /// <summary>
        /// Origin longitude.
        /// </summary>
        public double OriginLongitude { get; set; }

        /// <summary>
        /// Origin latitude.
        /// </summary>
        public double OriginLatitude { get; set; }

        /// <summary>
        /// Maximum distance in meters.
        /// </summary>
        public double SelectedMaxDistance { get; set; }

        /// <summary>
        /// Maximum no. of result.
        /// </summary>
        public int SelectedMaxResult { get; set; }

        /// <summary>
        /// List of location of roamlers ordered by distance.
        /// </summary>
        public IEnumerable<LocationResultModel> SearchResults { get; set; }
    }
}
