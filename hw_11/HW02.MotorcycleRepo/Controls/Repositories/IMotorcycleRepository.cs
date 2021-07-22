using HW02.MotorcycleRepo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW02.MotorcycleRepo.Controls.Repositories
{
    /// <summary>
    /// Interface for CRUD Repository of Motorcycles
    /// </summary>
    interface IMotorcycleRepository
    {
        public void Add(Motorcycle motorcycle);
        public IEnumerable<Motorcycle> GetAll();
        public Motorcycle GetById(string id);
        public void Delete(string id);
        public void Update(Motorcycle motorcycle);
    }
}
