using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace První_cvičení___Generické_listy__NET._9_
{
    public static class VehiclesDemo
    {
        public static void Run()
        {
            var car = new Car
            {
                Name = "Octavia",
                Year = 2020,
                MaxSpeedKmh = 210f,    // float => f
                WeightKg = 1350.0,     // double
                Doors = 5,
                EngineLiters = 1.5,
                OdometerKm = 52300     // nastavujeme přes vlastnost (private pole je zapouzdřené)
            };
            car.Tags.Add("rodinné");
            car.Tags.Add("benzín");

            var bike = new Bicycle
            {
                Name = "Rockrider",
                Year = 2023,
                MaxSpeedKmh = 45f,
                WeightKg = 14.2,
                Gears = 18,
                HasBell = true,
                OdometerKm = 420
            };
            bike.Tags.Add("MTB");
            bike.Tags.Add("město");

            // Polymorfismus – kolekce společného typu rodiče
            var garage = new List<Vehicle> { car, bike };

            foreach (var v in garage)
            {
                Console.WriteLine(v.GetInfo());   // společná metoda rodiče
                Console.WriteLine(v.Start());     // volá správnou přepsanou verzi podle skutečného typu
                Console.WriteLine($"Najeto: {v.OdometerKm} km");
                Console.WriteLine("Tagy: " + string.Join(", ", v.Tags));
                Console.WriteLine();
            }
        }
    }
}
