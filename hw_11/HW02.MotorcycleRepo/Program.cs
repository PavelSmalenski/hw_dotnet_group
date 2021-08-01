using HW02.MotorcycleRepo.Controls.Logging;
using HW02.MotorcycleRepo.Models;
using Serilog;
using System;
using System.Collections.Generic;

namespace HW02.MotorcycleRepo
{
    class Program
    {
        static void Main(string[] args)
        {
            
            MotorcycleRepositoryStatic staticRepo = new MotorcycleRepositoryStatic();

            Logging.Configuration();

            Log.Information($"Start application {System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}");
           
                Console.WriteLine(staticRepo.ShowMotorcyclesInfo());
                Console.WriteLine(new string('#', 60));

                Motorcycle bmwTRacer = new Motorcycle("BMW", "T Racer", 2019, 5_704);
                staticRepo.Add(bmwTRacer);
                Console.WriteLine(staticRepo.ShowMotorcyclesInfo());
                Console.WriteLine(new string('#', 60));

                IList<Motorcycle> motorcyclesList = staticRepo.GetAll();
                foreach (var moto in motorcyclesList)
                {
                    Console.WriteLine($"{moto.Name}, {moto.Model}, {moto.Year}, {moto.Odometer}, {moto.Id}");
                }
                Console.WriteLine(new string('#', 60));

                Motorcycle currentMoto = staticRepo.GetById(staticRepo.getTestId);
                Console.WriteLine($"{currentMoto.Name}, {currentMoto.Model}, {currentMoto.Year}, {currentMoto.Odometer}, {currentMoto.Id}");
                Console.WriteLine(new string('#', 60));

                staticRepo.Delete(staticRepo.delTestId);
                Console.WriteLine(staticRepo.ShowMotorcyclesInfo());
                Console.WriteLine(new string('#', 60));

                Motorcycle bmwXracer = new Motorcycle("BMW", "X racer", 2013, 12_205);
                try
                {
                    staticRepo.Update(bmwXracer);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                currentMoto.Odometer = 64_212;
                staticRepo.Update(currentMoto);
                Console.WriteLine(staticRepo.ShowMotorcyclesInfo());
                Console.WriteLine(new string('#', 60));
            
            Log.Debug("The program is successful completed");

            Console.ReadLine();
        }
    }
}
