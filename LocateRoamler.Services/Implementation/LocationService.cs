
using LocateRoamler.Data;
using LocateRoamler.Services.Models;
using System.Collections.Generic;
using System.Data;
using System.IO;
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

        public async Task<IEnumerable<LocationResultModel>> GetLocations(Location originLocation, double radius, int maxResults)
        {
            // Get the boundaries (min and max) latitude and longitude values. This forms a "square" around the origin coordinate
            // with each leg of the square exactly "X" miles from the origin, where X is the selected radius.
            LocationBoundaries boundaries = new LocationBoundaries(originLocation.Latitude, originLocation.Longitude, radius);

            // Select from all of the locations
            return await Task.FromResult(_dbContext.Locations
                // Where the location's latitude is between the min and max latitude boundaries
                .Where(x => x.Latitude >= boundaries.MinLatitude && x.Latitude <= boundaries.MaxLatitude)
                // And where the location's longitude is between the min and max longitude boundaries
                .Where(x => x.Longitude >= boundaries.MinLongitude && x.Longitude <= boundaries.MaxLongitude)
                // Populate an instance of the Result class with the desired data, including distance/direction calculation
                .Select(result => new LocationResultModel
                {
                    Name = result.Name,
                    Distance = boundaries.CalculateDistance(new Location(result.Latitude, result.Longitude))
                })
                // Filter by distance. This is necessary because a radius is a circle, yet we've defined a square around the origin coordinate.
                // This filter removes any extraneous results that would appear in the square's "corners" (imagine placing a circle inside a square of the
                // same size for visualization).
                .Where(x => x.Distance <= radius)
                // Sort by distance
                .OrderBy(x => x.Distance)
                .Take(maxResults).ToList());
        }
    }
}
