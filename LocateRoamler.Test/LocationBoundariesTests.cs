using LocateRoamler.Services;
using NUnit.Framework;
using System;

namespace LocateRoamler.Test
{
    [TestFixture]
    public class LocationBoundariesTests
    {
        [Test]
        public void ConstructorThrowsArgumentExceptionWithInvalidLocationParameters()
        {
            Location origin = Constants.Locations.LatitudeBelowMinimum;
            int radius = 25;

            var ex = Assert.Throws<ArgumentException>(() => new LocationBoundaries(origin.Latitude, origin.Longitude, radius));
            Assert.AreEqual(ex.Message, "Invalid Locations supplied.");
        }

        [Test]
        public void CalculateThrowsArgumentExceptionWithInvalidLatitudeProperty()
        {
            LocationBoundaries boundaries = new LocationBoundaries();

            var ex = Assert.Throws<ArgumentException>(() => boundaries.Latitude = Constants.Locations.LatitudeBelowMinimum.Latitude);

            Assert.AreEqual(ex.Message, "Invalid Locations supplied.");
        }

        [Test]
        public void CalculateThrowsArgumentExceptionWithInvalidLongitudeProperty()
        {
            LocationBoundaries boundaries = new LocationBoundaries();

            var ex = Assert.Throws<ArgumentException>(() => boundaries.Longitude = Constants.Locations.LongitudeBelowMinumum.Longitude);

            Assert.AreEqual(ex.Message, "Invalid Locations supplied.");
        }

        [Test]
        public void CalculateReturnsCorrectMinimumLatitude()
        {
            Location origin = Constants.Locations.ValidLocation;
            int radius = 25;

            LocationBoundaries boundaries = new LocationBoundaries(origin.Latitude, origin.Longitude, radius);

            double expectedResult = 33.705272959420292;

            Assert.AreEqual(boundaries.MinLatitude, expectedResult);
        }

        [Test]
        public void CalculateReturnsCorrectMaximumLatitude()
        {
            Location origin = Constants.Locations.ValidLocation;
            int radius = 25;

            LocationBoundaries boundaries = new LocationBoundaries(origin.Latitude, origin.Longitude, radius);

            double expectedResult = 34.429910640579713;

            Assert.AreEqual(boundaries.MaxLatitude, expectedResult);
        }

        [Test]
        public void CalculateReturnsCorrectMinimumLongitude()
        {
            Location origin = Constants.Locations.ValidLocation;
            int radius = 25;

            LocationBoundaries boundaries = new LocationBoundaries(origin.Latitude, origin.Longitude, radius);

            double expectedResult = -118.83509292675051;

            Assert.AreEqual(boundaries.MinLongitude, expectedResult);
        }

        [Test]
        public void CalculateReturnsCorrectMaximumLongitude()
        {
            Location origin = Constants.Locations.ValidLocation;
            int radius = 25;

            LocationBoundaries boundaries = new LocationBoundaries(origin.Latitude, origin.Longitude, radius);

            double expectedResult = -117.9603252732495;

            Assert.AreEqual(boundaries.MaxLongitude, expectedResult);
        }
    }
}
