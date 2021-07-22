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
        public string Name { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string Odometer { get; set; }

        public Motorcycle(string name, string model, string year, int odometer)
        {
            throw new NotImplementedException();
        }
    }
}
