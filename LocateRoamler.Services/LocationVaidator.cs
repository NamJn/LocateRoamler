namespace LocateRoamler.Services
{
    /// <summary>
    /// Utility for validating the location.
    /// </summary>
    public class LocationVaidator
    {
        /// <summary>
        /// Validates the location.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <returns>True, if the location is valid, false otherwise.</returns>
        public static bool Validate(double latitude, double longitude)
        {
            if (latitude < -90 || latitude > 90) return false;
            if (longitude < -180 || longitude > 180) return false;

            return true;

        }
    }
}
