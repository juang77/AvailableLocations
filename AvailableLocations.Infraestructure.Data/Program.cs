using AvailableLocations.Infraestructure.Data.Context;
using System;

namespace AvailableLocations.Infraestructure.Data
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating DB if not exist...!!!");
            LocationContext db = new LocationContext();
            db.Database.EnsureCreated();

            Console.WriteLine("Ready.......!!!");
            Console.ReadKey();
        }
    }
}
