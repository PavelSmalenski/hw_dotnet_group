using HW02.MotorcycleRepo.Models;
using Serilog;
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
            Log.Information($"Start Add Motorcycle with Id {motorcycle.Id}");
            Array.Resize(ref motorcycles, motorcycles.Length + 1);
            motorcycles[motorcycles.Length - 1] = motorcycle;
            Log.Information("New Motorcycle Added");
        }

        public void Delete(Guid id)
        {
            bool isFind = false;
            Log.Information($"Start search Motorcycle with Id {id} for Delete ");
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
                    Log.Information($"Deleted Motorcycle with Id {id} is done");
                    isFind = true;
                    break;
                }
            }

            if (!isFind)
            {
                Log.Error($"Can not Deleted Motorcycle with Id {id}. Motorcycle not found ");
            }
        }

        public IEnumerable<Motorcycle> GetAll()
        {
            throw new NotImplementedException();
        }

        public Motorcycle GetById(Guid id)
        {
            bool isFind = false;
            Log.Information($"Start GetById Motorcycle with Id {id}");
            Motorcycle result = new Motorcycle();
            for(int i = 0; i < motorcycles.Length; i++)
            {
                if (motorcycles[i].Id == id)
                {
                    result= motorcycles[i];
                    Log.Information($"GetById Motorcycle with Id {id} is done");
                    isFind = true;
                    break;
                }
            }

            if (!isFind)
            {
                Log.Error($"Can not GetById Motorcycle with Id {id}. Motorcycle not found ");
            }

            return result; //????????????
        }

        public void Update(Motorcycle motorcycle)
        {
            bool isFind = false;
            Log.Information($"Start Update Motorcycle with Id {motorcycle.Id}");
            for (int i = 0; i < motorcycles.Length; i++)
            {
                if (motorcycles[i].Id == motorcycle.Id)
                {
                    motorcycles[i] = motorcycle;
                    Log.Information($"Update Motorcycle with Id {motorcycle.Id} is done");
                    isFind = true;
                    break;
                }
                else { /* moto is not find*/}
            }

            if (!isFind)
            {
                Log.Error($"Can not Updated Motorcycle with Id {motorcycle.Id}. Motorcycle not found ");
            }
        }
    }
}
