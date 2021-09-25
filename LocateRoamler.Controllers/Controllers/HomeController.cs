using LocateRoamler.Services;
using LocateRoamler.Services.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LocateRoamler.Controllers.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILocationService _locationService;

        public HomeController(ILocationService locationService)
        {
            _locationService = locationService;
        }
        public async Task<IActionResult> Index(LocationViewModel model)
        {
            double radius = Convert.ToDouble(model.SelectedMaxDistance);
            Location originLocation = new Location(Convert.ToDouble(model.OriginLatitude), Convert.ToDouble(model.OriginLongitude));
            model.SearchResults = await _locationService.GetLocations(originLocation, radius, model.SelectedMaxResult);
            return View(model);
        }
    }
}

