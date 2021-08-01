using HW02.MotorcycleRepo.Controls.Repositories;
using HW02.MotorcycleRepo.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW02.MotorcycleRepo
{
    class MotorcycleRepositoryStatic : IMotorcycleRepository
    {
        private static IList<Motorcycle> _allMotorcycles = new List<Motorcycle>()
        {
        new Motorcycle("Suzuki", "SV1000", 2003, 46_000),
        new Motorcycle("YCF", "Bigy 125MX", 2020, 120),
        new Motorcycle("Yamaha", "XV1700", 2006, 59_546),
        new Motorcycle("Honda", "CB650R", 2019, 900),
        new Motorcycle("Honda", "CMX", 2019, 166),
        new Motorcycle("BMW", "F800S", 2009, 34_208)
        };

        public Guid delTestId = _allMotorcycles[3].Id;
        public Guid getTestId = _allMotorcycles[2].Id;

        public void Add(Motorcycle motorcycle)
        {
            Log.Information("method Add execution");
            _allMotorcycles.Add(motorcycle);
        }

        public IList<Motorcycle> GetAll()
        {
            Log.Information("method GetAll execution");
            return _allMotorcycles;
        }

        public Motorcycle GetById(Guid id)
        {
            Log.Information("method GetById execution");

            Motorcycle requiredMotorcycle = new Motorcycle();

            foreach (var moto in _allMotorcycles)
            {
                if (moto.Id == id)
                {
                    requiredMotorcycle = moto;
                    break;
                }
            }
            if (requiredMotorcycle.Model == null)
            {
                Log.Warning("Item not found");
            }
            return requiredMotorcycle;
        }

        public void Delete(Guid id)
        {
            Log.Information("method Delete execution");

            foreach (var moto in _allMotorcycles)
            {
                if (moto.Id == id)
                {
                    _allMotorcycles.Remove(moto);
                    break;
                }
            }
        }

        public void Update(Motorcycle motorcycle)
        {
            Log.Information("method Update execution");

            Motorcycle requiredMotorcycle = GetById(motorcycle.Id);

            if (requiredMotorcycle.Model != null)
            {
                requiredMotorcycle.Model = motorcycle.Model;
                requiredMotorcycle.Name = motorcycle.Name;
                requiredMotorcycle.Odometer = motorcycle.Odometer;
                requiredMotorcycle.Year = motorcycle.Year;
            }
            else
            {
                Log.Warning("Item for update not found");
            }
        }

        public StringBuilder ShowMotorcyclesInfo()
        {
            Log.Information("method ShowMotorcyclesInfo execution");

            StringBuilder motorcyclesInfo = new StringBuilder();

            foreach (var motorcycle in _allMotorcycles)
            {
                motorcyclesInfo.Append($"{motorcycle.Name}, {motorcycle.Model}, {motorcycle.Year}, {motorcycle.Odometer}, {motorcycle.Id} \n");
            }

            return motorcyclesInfo;
        }
        
    }
}
