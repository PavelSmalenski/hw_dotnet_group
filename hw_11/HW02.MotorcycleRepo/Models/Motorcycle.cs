using System;
using System.Collections.Generic;
using System.Text;
using Serilog;
using Serilog;
using HW02.MotorcycleRepo.Models;


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

        public Motorcycle(string name, string model, int year, int odometer)
        {
            Log.Information($"Motorcycle constructor");
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(model))
            {
                throw new Exception("Empty name or model");
            }
            Id = Guid.NewGuid();
            Name = name;
            Model = model;
            Year = year;
            Odometer = odometer;
        }
        public override string ToString()
        {
            Log.Information($"Motorcycle.ToString()");
            return ($"{Name} {Model}, {Year}yr, run: {Odometer}, vin: {Id}");
        }
    }
}
