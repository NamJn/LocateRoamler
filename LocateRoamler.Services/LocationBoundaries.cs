using LocateRoamler.Services.Models;
using System;

namespace LocateRoamler.Services
{
    /// <summary>
    /// Calculates the upper, lower, left and right location boundaries based on origin point and distance.
    /// </summary>
    public class LocationBoundaries
    {
        private int _latitudeDistanceInMeters = 111045;

        /// <summary>
        /// Creates a new  object LocationBoundaries object.
        /// </summary>
        public LocationBoundaries()
        {
        }

        /// <summary>
        /// The lower boundary latitude point.
        /// </summary>
        public double MaxLatitude { get; private set; }

        /// <summary>
        /// The upper boundary latitude point.
        /// </summary>
        public double MinLatitude { get; private set; }

        /// <summary>
        /// The right boundary longitude point.
        /// </summary>
        public double MaxLongitude { get; private set; }

        /// <summary>
        /// The left boundary longitude point.
        /// </summary>
        public double MinLongitude { get; private set; }

        private double _latitude;

        /// <summary>
        /// The origin point latitude.
        /// </summary>
        public double Latitude
        {
            get { return _latitude; }

            set
            {
                _latitude = value;
                Calculate();
            }
        }

        private double _longitude;

        /// <summary>
        /// The origin point longitude.
        /// </summary>
        public double Longitude
        {
            get { return _longitude; }
            set
            {
                _longitude = value;
                Calculate();
            }
        }

        private double _distance;

        /// <summary>
        /// The distance from the origin point.
        /// </summary>
        public double Distance
        {
            get { return _distance; }
            set
            {
                _distance = value;
            }
        }

        /// <summary>
        /// Creates a new LocationBoundaries object.
        /// </summary>
        /// <param name="latitude">The origin point latitude in decimal notation</param>
        /// <param name="longitude">The origin point longitude in decimal notation</param>
        /// <param name="distance">The distance from the origin point in statute miles</param>
        public LocationBoundaries(double latitude, double longitude, double distance)
        {
            if (!LocationVaidator.Validate(latitude, longitude))
                throw new ArgumentException("Invalid coordinates supplied.");

            _latitude = latitude;
            _longitude = longitude;
            _distance = distance;

            Calculate();
        }

        /// <summary>
        /// Calculates the distance between this location and another one, in meters.
        /// </summary>
        public double CalculateDistance(Location location)
        {
            var rlat1 = Math.PI * Latitude / 180;
            var rlat2 = Math.PI * location.Latitude / 180;
            var rlon1 = Math.PI * Longitude / 180;
            var rlon2 = Math.PI * location.Longitude / 180;
            var theta = Longitude - location.Longitude;
            var rtheta = Math.PI * theta / 180;
            var dist = Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) * Math.Cos(rlat2) * Math.Cos(rtheta);
            dist = Math.Acos(dist);
            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;

            return Math.Round((dist * 1609.344), 2);
        }

        private void Calculate()
        {
            if (!LocationVaidator.Validate(Latitude, Longitude))
                throw new ArgumentException("Invalid coordinates supplied.");

            double divisor = _latitudeDistanceInMeters;

            double latitudeConversionFactor = Distance / divisor;
            //can create extension method if this formula is used again
            double longitudeConversionFactor = Distance / divisor / Math.Abs(Math.Cos(Latitude * (Math.PI / 180)));

            MinLatitude = Latitude - latitudeConversionFactor;
            MaxLatitude = Latitude + latitudeConversionFactor;

            MinLongitude = Longitude - longitudeConversionFactor;
            MaxLongitude = Longitude + longitudeConversionFactor;

            // Adjust for passing over coordinate boundaries
            if (MinLatitude < -90) MinLatitude = 90 - (-90 - MinLatitude);
            if (MaxLatitude > 90) MaxLatitude = -90 + (MaxLatitude - 90);

            if (MinLongitude < -180) MinLongitude = 180 - (-180 - MinLongitude);
            if (MaxLongitude > 180) MaxLongitude = -180 + (MaxLongitude - 180);
        }
    }
}
