using LocateRoamler.Services;
using LocateRoamler.Services.Models;
using System;
using Xunit;

namespace LocateRoamler.Tests
{
    public class LocationBoundariesTests
    {
        [Fact]

        public void ConstructorThrowsArgumentExceptionWithInvalidLocationParameters()
        {
            Location origin = Constants.Locations.LatitudeBelowMinimum;
            int radius = 25;

            var ex = Assert.Throws<ArgumentException>(() => new LocationBoundaries(origin.Latitude, origin.Longitude, radius));
            Assert.Equal("Invalid locations supplied.", ex.Message);
        }

        [Fact]
        public void CalculateThrowsArgumentExceptionWithInvalidLatitudeProperty()
        {
            LocationBoundaries boundaries = new LocationBoundaries();

            var ex = Assert.Throws<ArgumentException>(() => boundaries.Latitude = Constants.Locations.LatitudeBelowMinimum.Latitude);

            Assert.Equal("Invalid locations supplied.", ex.Message);
        }

        [Fact]
        public void CalculateThrowsArgumentExceptionWithInvalidLongitudeProperty()
        {
            LocationBoundaries boundaries = new LocationBoundaries();

            var ex = Assert.Throws<ArgumentException>(() => boundaries.Longitude = Constants.Locations.LongitudeBelowMinumum.Longitude);

            Assert.Equal("Invalid locations supplied.", ex.Message);
        }

        [Fact]
        public void CalculateReturnsCorrectMinimumLatitude()
        {
            Location origin = Constants.Locations.ValidLocation;
            int radius = 25;

            LocationBoundaries boundaries = new LocationBoundaries(origin.Latitude, origin.Longitude, radius);

            double expectedResult = 33.705272959420292;

            Assert.Equal(boundaries.MinLatitude, expectedResult);
        }

        [Fact]
        public void CalculateReturnsCorrectMaximumLatitude()
        {
            Location origin = Constants.Locations.ValidLocation;
            int radius = 25;

            LocationBoundaries boundaries = new LocationBoundaries(origin.Latitude, origin.Longitude, radius);

            double expectedResult = 34.429910640579713;

            Assert.Equal(boundaries.MaxLatitude, expectedResult);
        }

        [Fact]
        public void CalculateReturnsCorrectMinimumLongitude()
        {
            Location origin = Constants.Locations.ValidLocation;
            int radius = 25;

            LocationBoundaries boundaries = new LocationBoundaries(origin.Latitude, origin.Longitude, radius);

            double expectedResult = -118.83509292675051;

            Assert.Equal(boundaries.MinLongitude, expectedResult);
        }

        [Fact]
        public void CalculateReturnsCorrectMaximumLongitude()
        {
            Location origin = Constants.Locations.ValidLocation;
            int radius = 25;

            LocationBoundaries boundaries = new LocationBoundaries(origin.Latitude, origin.Longitude, radius);

            double expectedResult = -117.9603252732495;

            Assert.Equal(boundaries.MaxLongitude, expectedResult);
        }
    }
}
