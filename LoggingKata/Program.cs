using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;
using System.Runtime.ExceptionServices;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // Using csv file, parse the information to find the 2 tacoBells that are furthest apart

            logger.LogInfo("Log initialized");


            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");

            var parser = new TacoParser();


            var locations = lines.Select(parser.Parse).ToArray();


            ITrackable tBell1 = null;
            ITrackable tBell2 = null;
            double tbellDistance = 0;


            for (int i = 0; i < locations.Length; i++)
            {
                var locA = locations[i];
                var corA = new GeoCoordinate();
                corA.Latitude = locA.Location.Latitude;
                corA.Longitude = locA.Location.Longitude;

                for (int j = 0; j < locations.Length; j++)
                {
                    var locB = locations[j];
                    var corB = new GeoCoordinate();
                    corB.Latitude = locB.Location.Latitude;
                    corB.Longitude = locB.Location.Longitude;

                    if (corA.GetDistanceTo(corB) > tbellDistance)
                    {
                        tbellDistance = corA.GetDistanceTo(corB);
                        tBell1 = locA;
                        tBell2 = locB;
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine();
            Console.WriteLine();
            var miles = Math.Round(tbellDistance * .00062);
            Console.WriteLine($"WIth a distance of {miles} miles, {tBell1.Name} and {tBell2.Name} are the farthest apart!!");
            Console.ResetColor();
        }
    }
}
