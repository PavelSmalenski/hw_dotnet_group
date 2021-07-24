using System;
using System.Collections.Generic;
using System.Text;
using Serilog;
using HW02.MotorcycleRepo.Models;

namespace HW02.MotorcycleRepo.Controls.Repositories
{
    class MotorcycleRepository : IMotorcycleRepository
    {
        private List<Motorcycle> _repository;

        public MotorcycleRepository()
        {
            Log.Information($"MotorcycleRepository constructor");
            _repository = MotorcycleRepositoryProvider.Motorcycles;
        }

        public void Add(Motorcycle motorcycle)
        {
            Log.Information($"MotorcycleRepository.Add()");
            _repository.Add(motorcycle);
        }
        public List<Motorcycle> GetAll()
        {
            Log.Information($"MotorcycleRepository.GetAll()");
            return _repository;
        }
        public Motorcycle GetById(Guid id)
        {
            Log.Information($"MotorcycleRepository.GetById()");
            return _repository.Find(x=>x.Id==id);
        }
        public void Delete(Guid id)
        {
            Log.Information($"MotorcycleRepository.Delete()");
            _repository.Remove(_repository.Find(x => x.Id == id));
        }
        public void Update(Motorcycle motorcycle)
        {
            Log.Information($"MotorcycleRepository.Update()");
            int position = _repository.FindIndex(x => x.Id == motorcycle.Id);
            _repository[position] = motorcycle;
        }
        public void PrintAll()
        {
            Log.Information($"MotorcycleRepository.PrintAll()");
            int counter= 1;
            Console.WriteLine("--------------Motorcycles--------------");
            foreach (Motorcycle moto in _repository)
            {
                Console.WriteLine($"{counter}) {moto}");
                counter++;
            }
        }
    }
}
