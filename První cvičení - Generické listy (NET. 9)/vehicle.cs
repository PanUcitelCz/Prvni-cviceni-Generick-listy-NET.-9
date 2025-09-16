using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace První_cvičení___Generické_listy__NET._9_
{
    // ===== RODIČ (děditelný) =====
    public class Vehicle
    {
        // Jedna PRIVATE proměnná v rodiči (nepřístupná zvenku ani z potomků přímo)
        private int _odometerKm;

        // Požadované datové typy:
        public string Name { get; set; } = string.Empty; // string
        public int Year { get; set; }                    // int
        public float MaxSpeedKmh { get; set; }           // float
        public double WeightKg { get; set; }             // double

        // List (seznam řetězců) – štítky/tagy
        public List<string> Tags { get; set; } = new List<string>();

        // Veřejná vlastnost, která "pracuje" s private proměnnou _odometerKm
        // (zapouzdření a jednoduchá validace)
        public int OdometerKm
        {
            get => _odometerKm;
            set => _odometerKm = value < 0 ? 0 : value;
        }

        // ===== Polymorfní VLASTNOST (potomci ji přepíší) =====
        public virtual string Kind => "Vozidlo";

        // ===== Dvě hlavní metody =====
        // (1) Polymorfní metoda – potomci ji mohou přepsat (override)
        public virtual string Start()
        {
            return $"{Kind} {Name} startuje.";
        }

        // (2) Společná metoda – nepřepisujeme ji v potomcích
        public string GetInfo()
        {
            return $"{Kind}: {Name} ({Year}), max {MaxSpeedKmh} km/h, {WeightKg} kg";
        }
    }

    // ===== POTOMEK 1 =====
    public class Car : Vehicle
    {
        // Vlastní (nové) vlastnosti potomka
        public int Doors { get; set; }
        public double EngineLiters { get; set; }

        // Přepis polymorfní VLASTNOSTI z rodiče
        public override string Kind => "Auto";

        // Přepis polymorfní METODY z rodiče
        public override string Start()
        {
            return $"{Kind} {Name} nastartovalo motor ({EngineLiters} l).";
        }
    }

    // ===== POTOMEK 2 =====
    public class Bicycle : Vehicle
    {
        // Vlastní (nové) vlastnosti potomka
        public int Gears { get; set; }
        public bool HasBell { get; set; }

        // Přepis polymorfní VLASTNOSTI z rodiče
        public override string Kind => "Kolo";

        // Přepis polymorfní METODY z rodiče
        public override string Start()
        {
            return $"{Kind} {Name} se rozjíždí šlápnutím do pedálů.";
        }
    }
}
