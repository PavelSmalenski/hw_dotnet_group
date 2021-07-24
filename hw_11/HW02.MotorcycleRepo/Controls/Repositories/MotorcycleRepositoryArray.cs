using HW02.MotorcycleRepo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW02.MotorcycleRepo.Controls.Repositories
{
    class MotorcycleRepositoryArray : IMotorcycleRepository
    {
        Motorcycle[] motorcycles = new Motorcycle[0];

        public void Add(Motorcycle motorcycle)
        {
            Array.Resize(ref motorcycles, motorcycles.Length + 1);
            motorcycles[motorcycles.Length - 1] = motorcycle;
        }

        public void Delete(Guid id)
        {
            for (int i = 0; i < motorcycles.Length-1; i++)
            {
                if (motorcycles[i].Id == id)
                {
                    Array.Clear(motorcycles, i, 1);
                    for (int j = i; j < motorcycles.Length - 1; j++)
                    {
                        motorcycles[j] = motorcycles[j + 1];
                    }
                    Array.Resize(ref motorcycles, motorcycles.Length - 1);
                    break;
                }
            }
        }

        public IEnumerable<Motorcycle> GetAll()
        {
            throw new NotImplementedException();
        }

        public Motorcycle GetById(Guid id)
        {
            Motorcycle result = new Motorcycle();
            for(int i = 0; i < motorcycles.Length; i++)
            {
                if (motorcycles[i].Id == id)
                {
                    result= motorcycles[i];
                    break;
                }
            }
            return result;
        }

        public void Update(Motorcycle motorcycle)
        {
            for (int i = 0; i < motorcycles.Length; i++)
            {
                if (motorcycles[i].Id == motorcycle.Id)
                {
                    motorcycles[i] = motorcycle;
                    break;
                }
                else { /* moto is not find*/}
            }
        }
    }
}
