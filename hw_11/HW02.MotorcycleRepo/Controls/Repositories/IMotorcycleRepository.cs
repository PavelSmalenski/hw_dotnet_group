using HW02.MotorcycleRepo.Models;
using System;
using System.Collections.Generic;

namespace HW02.MotorcycleRepo.Controls.Repositories
{
    /// <summary>
    /// Interface for CRUD Repository of Motorcycles
    /// </summary>
    interface IMotorcycleRepository
    {
        public void Add(Motorcycle motorcycle);
        public IList<Motorcycle> GetAll();
        public Motorcycle GetById(Guid id);
        public void Delete(Guid id);
        public void Update(Motorcycle motorcycle);
    }
}
