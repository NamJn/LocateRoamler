using LocateRoamler.Services;
using LocateRoamler.Services.Models;
using System;
using Xunit;

namespace LocateRoamler.Test
{
    public class LocationBoundariesTests
    {
        [Fact]

        public void ConstructorThrowsArgumentExceptionWithInvalidLocationParameters()
        {
            Location origin = Constants.Locations.LatitudeBelowMinimum;
            int radius = 25;

            var ex = Assert.Throws<ArgumentException>(() => new LocationBoundaries(origin.Latitude, origin.Longitude, radius));
            Assert.Equal("Invalid location supplied.", ex.Message);
        }

        [Fact]
        public void CalculateThrowsArgumentExceptionWithInvalidLatitudeProperty()
        {
            LocationBoundaries boundaries = new LocationBoundaries();

            var ex = Assert.Throws<ArgumentException>(() => boundaries.Latitude = Constants.Locations.LatitudeBelowMinimum.Latitude);

            Assert.Equal("Invalid location supplied.", ex.Message);
        }

        [Fact]
        public void CalculateThrowsArgumentExceptionWithInvalidLongitudeProperty()
        {
            LocationBoundaries boundaries = new LocationBoundaries();

            var ex = Assert.Throws<ArgumentException>(() => boundaries.Longitude = Constants.Locations.LongitudeBelowMinumum.Longitude);

            Assert.Equal("Invalid location supplied.", ex.Message);
        }

        [Fact]
        public void CalculateReturnsCorrectMinimumLatitude()
        {
            Location origin = Constants.Locations.ValidLocation;
            int radius = 25;

            LocationBoundaries boundaries = new LocationBoundaries(origin.Latitude, origin.Longitude, radius);

            double expectedResult = 34.07;

            Assert.Equal(expectedResult, Math.Round(boundaries.MinLatitude, 2));
        }

        [Fact]
        public void CalculateReturnsCorrectMaximumLatitude()
        {
            Location origin = Constants.Locations.ValidLocation;
            int radius = 25;

            LocationBoundaries boundaries = new LocationBoundaries(origin.Latitude, origin.Longitude, radius);

            double expectedResult = 34.07;

            Assert.Equal(expectedResult, Math.Round(boundaries.MaxLatitude, 2));
        }

        [Fact]
        public void CalculateReturnsCorrectMinimumLongitude()
        {
            Location origin = Constants.Locations.ValidLocation;
            int radius = 25;

            LocationBoundaries boundaries = new LocationBoundaries(origin.Latitude, origin.Longitude, radius);

            double expectedResult = -118.4;

            Assert.Equal(expectedResult, Math.Round(boundaries.MinLongitude, 2));
        }

        [Fact]
        public void CalculateReturnsCorrectMaximumLongitude()
        {
            Location origin = Constants.Locations.ValidLocation;
            int radius = 25;

            LocationBoundaries boundaries = new LocationBoundaries(origin.Latitude, origin.Longitude, radius);

            double expectedResult = -118.4;

            Assert.Equal(expectedResult, Math.Round(boundaries.MaxLongitude, 2));
        }
    }
}
