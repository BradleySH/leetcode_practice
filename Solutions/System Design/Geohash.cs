using System.Text;

namespace SystemDesign;

public class Geohash
{
    // The Base32 characters used for Geohashing
    private static readonly char[] Base32 = "0123456789bcdefghjkmnpqrstuvwxyz".ToCharArray();

    // Bit mask values used to build each 5-bit chunk.
    private static readonly int[] Bits = { 16, 8, 4, 2, 1 };

    /// <summary>
    /// Encodes a latitude and longitude into a Geohash string.
    /// </summary>
    /// <param name="latitude">The latitude coordinate.</param>
    /// <param name="longitude">The longitude coordinate.</param>
    /// <param name="precision">The precision of the Geohash (number of characters).</param>
    /// <returns>The Geohash string.</returns>
    public static string Encode(double latitude, double longitude, int precision = 12)
    {
        bool isEven = true; // Flag to alternate between longitude and latitude
        int bit = 0;       // Current bit index within a 5-bit chunk.
        int ch = 0;        // Accumulated bits to form one geohash character
        StringBuilder geohash = new StringBuilder();

        // Initial boundaries for latitude and longitude
        double[] lat = { -90.0, 90.0 };
        double[] lon = { -180.0, 180.0 };

        Console.WriteLine("Starting Geohash encoding.");
        Console.WriteLine($"Initial Latitude Range: [{lat[0]}, {lat[1]}]");
        Console.WriteLine($"Initial Longitude Range: [{lon[0]}, {lon[1]}]");

        // Loop until the geohash has reached the desired precision.
        while (geohash.Length < precision)
        {
            double mid = 0;
            if (isEven)
            {
                // Process longitude: find midpoint and update interval.
                mid = (lon[0] + lon[1]) / 2;
                Console.WriteLine($"\nProcessing Longitude:");
                Console.WriteLine($"  Current Longitude Range: [{lon[0]}, {lon[1]}] - Midpoint: {mid}");
                if (longitude > mid)
                {
                    ch |= Bits[bit];  // Set the current bit.
                    lon[0] = mid;     // Update lower bound.
                    Console.WriteLine($"  Longitude {longitude} is > {mid}. Setting bit {Bits[bit]} (bit index {bit}).");
                    Console.WriteLine($"  New Longitude Range: [{lon[0]}, {lon[1]}]");
                }
                else
                {
                    lon[1] = mid;     // Update upper bound.
                    Console.WriteLine($"  Longitude {longitude} is <= {mid}. Not setting bit (bit index {bit}).");
                    Console.WriteLine($"  New Longitude Range: [{lon[0]}, {lon[1]}]");
                }
            }
            else
            {
                // Process latitude: find midpoint and update interval.
                mid = (lat[0] + lat[1]) / 2;
                Console.WriteLine($"\nProcessing Latitude:");
                Console.WriteLine($"  Current Latitude Range: [{lat[0]}, {lat[1]}] - Midpoint: {mid}");
                if (latitude > mid)
                {
                    ch |= Bits[bit];  // Set the current bit.
                    lat[0] = mid;     // Update lower bound.
                    Console.WriteLine($"  Latitude {latitude} is > {mid}. Setting bit {Bits[bit]} (bit index {bit}).");
                    Console.WriteLine($"  New Latitude Range: [{lat[0]}, {lat[1]}]");
                }
                else
                {
                    lat[1] = mid;     // Update upper bound.
                    Console.WriteLine($"  Latitude {latitude} is <= {mid}. Not setting bit (bit index {bit}).");
                    Console.WriteLine($"  New Latitude Range: [{lat[0]}, {lat[1]}]");
                }
            }

            // Alternate between longitude and latitude.
            isEven = !isEven;

            // Move to the next bit within a 5-bit chunk.
            if (bit < 4)
            {
                bit++;
            }
            else
            {
                // We have accumulated 5 bits, convert them to a Base32 character.
                Console.WriteLine($"\n5 bits accumulated: {Convert.ToString(ch, 2).PadLeft(5, '0')} which maps to '{Base32[ch]}'");
                geohash.Append(Base32[ch]);
                // Reset for the next character.
                bit = 0;
                ch = 0;
            }
        }

        Console.WriteLine($"\nFinal Geohash: {geohash.ToString()}");
        return geohash.ToString();
    }
}