
using LocateRoamler.Data;
using LocateRoamler.Services.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace LocateRoamler.Services.Implementation
{
    public class LocationService : ILocationService
    {
        private readonly LocationDbContext _dbContext;

        public LocationService(LocationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Get loaction of all the roamlers from a particular origin location and within specified distance.
        /// </summary>
        /// <param name="originLocation">Origin location coordinates.</param>
        /// <param name="radius">Distance.</param>
        /// <param name="maxResults">Maximum result.</param>
        /// <returns></returns>
        public async Task<IEnumerable<LocationResultModel>> GetLocations(Location originLocation, double radius, int maxResults)
        {
            // Get the boundaries (min and max) latitude and longitude values. This forms a "square" around the origin coordinate
            // with each leg of the square exactly "X" miles from the origin, where X is the selected radius.
            LocationBoundaries boundaries = new LocationBoundaries(originLocation.Latitude, originLocation.Longitude, radius);

            return await Task.FromResult(_dbContext.Locations
                .Where(x => x.Latitude >= boundaries.MinLatitude && x.Latitude <= boundaries.MaxLatitude)
                .Where(x => x.Longitude >= boundaries.MinLongitude && x.Longitude <= boundaries.MaxLongitude)
                .Select(result => new LocationResultModel
                {
                    Name = result.Name,
                    Distance = boundaries.CalculateDistance(new Location(result.Latitude, result.Longitude))
                })
                .Where(x => x.Distance <= radius)
                .OrderBy(x => x.Distance)
                .Take(maxResults).ToList());
        }
    }
}
