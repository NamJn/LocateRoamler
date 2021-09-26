using LocateRoamler.Services;
using LocateRoamler.Services.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocateRoamler.Test.Mocks
{
    public class MockLocationService : ILocationService
    {
        public async Task<IEnumerable<LocationResultModel>> GetLocations(Location originLocation, double radius, int maxResults)
        {
            var locations = new List<LocationResultModel>
            {
                new LocationResultModel{ Name = "Tesco: Cheltenham Rd 62, WR11, Evesham, United Kingdom", Distance = 2913.97},
                new LocationResultModel{ Name = "Tesco: Worcester Rd, WR11, Evesham, United Kingdom", Distance = 3224.35},
                new LocationResultModel{ Name = "Boots: 19-21 Bridge St Evesham Worcestershire WR11 4SQ GB	", Distance = 3236.58},
                new LocationResultModel{ Name = "Boots: Worcester Rd Evesham Worcestershire WR11 4AB GB", Distance = 3329.2},
            };
            return await Task.FromResult(locations.Take(maxResults));
        }
    }
}
