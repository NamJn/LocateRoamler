using LocateRoamler.Controllers.Controllers;
using LocateRoamler.Services.Models;
using LocateRoamler.Test.Mocks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Xunit;


namespace LocateRoamler.Test.Controllers
{
    public class HomeControllerTest
    {
        [Fact]

        public async Task IndexShouldReturnViewResultWithCorrecctLocationModel()
        {
            //Arrange
            var homeController = new HomeController(new MockLocationService());
            var locationModel = new LocationViewModel
            {
                OriginLatitude = 52.087709,
                OriginLongitude = 52.087709,
                SelectedMaxDistance = 5000,
                SelectedMaxResult = 2
            };

            //Act
            var result = await homeController.Index(locationModel);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<LocationViewModel>(viewResult.Model);
            Assert.Equal(2, model.SearchResults.Count());
        }

    }
}
