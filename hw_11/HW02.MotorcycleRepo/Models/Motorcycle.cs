using System;

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

        public Motorcycle()
        { }

        public Motorcycle(string name, string model, int year, int odometer)
        {
            Id = Guid.NewGuid();

            Name = name;
            Model = model;
            Year = year;
            Odometer = odometer;
        }
    }
}
