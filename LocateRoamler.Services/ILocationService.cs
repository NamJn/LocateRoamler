using LocateRoamler.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocateRoamler.Services
{
    public interface ILocationService
    {
        /// <summary>
        /// Get loaction of all the roamlers from a particular origin location and within specified distance.
        /// </summary>
        /// <param name="originLocation">Origin location coordinates.</param>
        /// <param name="radius">Distance.</param>
        /// <param name="maxResults">Maximum result.</param>
        /// <returns></returns>
        public Task<IEnumerable<LocationResultModel>> GetLocations(Location originLocation, double radius, int maxResults);
    }
}
