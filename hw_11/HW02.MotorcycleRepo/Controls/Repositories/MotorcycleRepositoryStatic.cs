using HW02.MotorcycleRepo.Controls.Logging;
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
            var crudLogger = Logging.Logging.GetLogger(LogType.CRUD);
            crudLogger.Information("Executing static add operation");
            _motorcycles.Add(motorcycle);
        }

        public void Delete(Guid id)
        {
            var crudLogger = Logging.Logging.GetLogger(LogType.CRUD);
            crudLogger.Information("Executing static delete operation");
            _motorcycles.RemoveAll(moto => moto.Id.Equals(id));
        }

        public List<Motorcycle> GetAll()
        {
            var crudLogger = Logging.Logging.GetLogger(LogType.CRUD);
            crudLogger.Information("Executing static full return operation");
            return new List<Motorcycle>(_motorcycles);
        }

        public Motorcycle GetById(Guid id)
        {
            var crudLogger = Logging.Logging.GetLogger(LogType.CRUD);
            crudLogger.Information("Executing static add operation");
            return _motorcycles.Find(moto => moto.Id.Equals(id));
        }

        public void Update(Motorcycle motorcycle)
        {
            var crudLogger = Logging.Logging.GetLogger(LogType.CRUD);
            crudLogger.Information("Executing static update operation");

            Motorcycle foundMotorcycle = GetById(motorcycle.Id);
            if (!(foundMotorcycle is null))
            {
                foundMotorcycle.Id = motorcycle.Id;
                foundMotorcycle.Name = motorcycle.Name;
                foundMotorcycle.Model = motorcycle.Model;
                foundMotorcycle.Year = motorcycle.Year;
                foundMotorcycle.Odometer = motorcycle.Odometer;
            }
            else
            {
                crudLogger.Warning("Item for update not found");
            }
        }
    }
}
