using LocateRoamler.Services;
using LocateRoamler.Services.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocateRoamler.Tests.Mocks
{
    public class MockLocationService : ILocationService
    {
        public async Task<IEnumerable<LocationResultModel>> GetLocations(Location originLocation, double radius, int maxResults)
        {
            var locations = new List<LocationResultModel>
            {
                new LocationResultModel{ Name = "", Distance = 60},
                new LocationResultModel{ Name = "", Distance = 60},
                new LocationResultModel{ Name = "", Distance = 60},
                new LocationResultModel{ Name = "", Distance = 60},
            };
            return await Task.FromResult(locations.Take(maxResults));
        }
    }
}
