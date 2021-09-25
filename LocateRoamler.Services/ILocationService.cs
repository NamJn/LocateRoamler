using LocateRoamler.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocateRoamler.Services
{
    public interface ILocationService
    {
        public Task<IEnumerable<LocationResultModel>> GetLocations(Location originLocation, double radius, int maxResults);
    }
}
