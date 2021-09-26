using LocateRoamler.Services.Models;

namespace LocateRoamler.Test
{
    public static class Constants
    {
        public static class Locations
        {
            public static Location ValidLocation
            {
                get { return new Location { Latitude = 34.0675918, Longitude = -118.3977091 }; }
            }

            public static Location ValidDestinationLocation
            {
                get { return new Location { Latitude = 35.076234, Longitude = -118.9078687 }; }
            }

            public static Location LatitudeBelowMinimum
            {
                get { return new Location { Latitude = -91.0675918, Longitude = -118.3977091 }; }
            }

            public static Location LatitudeAboveMaximum
            {
                get { return new Location { Latitude = 97.0675918, Longitude = -118.3977091 }; }
            }

            public static Location LongitudeBelowMinumum
            {
                get { return new Location { Latitude = 34.0675918, Longitude = -197.3977091 }; }
            }

            public static Location LongitudeAboveMaximum
            {
                get { return new Location { Latitude = 34.0675918, Longitude = -187.3977091 }; }
            }

            public static Location LatitudeEqualToMinimum
            {
                get { return new Location { Latitude = -90.000, Longitude = -118.3977091 }; }
            }

            public static Location LatitudeEqualToMaximum
            {
                get { return new Location { Latitude = 90.0000, Longitude = -118.3977091 }; }
            }

            public static Location LongitudeEqualToMinimum
            {
                get { return new Location { Latitude = 34.0675918, Longitude = -180.0000 }; }
            }

            public static Location LongitudeEqualToMaximum
            {
                get { return new Location { Latitude = 34.0675918, Longitude = 180.0000 }; }
            }
        }
    }
}
