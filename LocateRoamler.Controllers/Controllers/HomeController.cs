using LocateRoamler.Services;
using LocateRoamler.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
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

        /// <summary>
        /// Provide error view on production environment.
        /// </summary>
        /// <returns></returns>
        [Route("Home/Error")]
        [AllowAnonymous]
        public IActionResult Error()
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ViewBag.ExceptionMessage = exceptionDetails.Error.Message;
            return View("Error");
        }
    }
}

