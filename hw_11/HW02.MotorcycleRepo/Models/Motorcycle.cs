using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW02.MotorcycleRepo.Models
{
    /// <summary>
    /// Motorcycle item representation
    /// </summary>
    class Motorcycle
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Odometer { get; set; }

        public Motorcycle(Guid id, string name, string model, int year, int odometer)
        {
            Id = id;
            Name = name;
            Model = model;
            Year = year;
            Odometer = odometer;
            Log.Information("New Motorcycle with property");
        }

        public Motorcycle()
        {
            Log.Information("New Motorcycle without property");
        }
    }
}
