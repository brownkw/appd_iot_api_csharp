using System;
namespace AppDynamics.IoT
{
    public static class AppDUtils
    {
        private static readonly DateTime EPOCH = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// Converts the <paramref name="dateTime"/> to timestamp.
        /// </summary>
        /// <returns>The timestamp.</returns>
        /// <param name="dateTime">DateTime object.</param>
        public static long ConvertToTimestamp(this DateTime dateTime)
        {
            return (long)((dateTime.ToUniversalTime() - EPOCH).TotalMilliseconds);
        }

    }
}
