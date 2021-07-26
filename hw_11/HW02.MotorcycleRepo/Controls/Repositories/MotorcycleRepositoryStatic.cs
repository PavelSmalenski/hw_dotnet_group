using HW02.MotorcycleRepo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW02.MotorcycleRepo.Controls.Repositories
{
    class MotorcycleRepositoryStatic : IMotorcycleRepository
    {
        private static List<Motorcycle> _motorcycles = new List<Motorcycle>();

        public void Add(Motorcycle motorcycle)
        {
            _motorcycles.Add(motorcycle);
        }

        public void Delete(Guid id)
        {
            _motorcycles.RemoveAll(moto => moto.Id.Equals(id));
        }

        public IEnumerable<Motorcycle> GetAll()
        {
            return new List<Motorcycle>(_motorcycles);
        }

        public Motorcycle GetById(Guid id)
        {
            return _motorcycles.Find(moto => moto.Id.Equals(id));
        }

        public void Update(Motorcycle motorcycle)
        {
            Motorcycle foundMotorcycle = GetById(motorcycle.Id);
            if (!(foundMotorcycle is null))
            {
                foundMotorcycle.Id = motorcycle.Id;
                foundMotorcycle.Name = motorcycle.Name;
                foundMotorcycle.Model = motorcycle.Model;
                foundMotorcycle.Year = motorcycle.Year;
                foundMotorcycle.Odometer = motorcycle.Odometer;
            }
        }
    }
}
