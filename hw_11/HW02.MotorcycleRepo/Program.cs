using System;
using HW02.MotorcycleRepo.Controls.Repositories;
using HW02.MotorcycleRepo.Models;
using Serilog;

namespace HW02.MotorcycleRepo
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Console()
                .WriteTo.File("logs/repositoryApp.txt", rollingInterval: RollingInterval.Minute)
                .CreateLogger();
            Log.Information($"App name: \"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}\"");          
            
            Random rnd = new Random();
            string name, model;
            try
            {
                MotorcycleRepository motorcycles = new MotorcycleRepository();
                for (int i = 0; i < 4; i++)
                {
                    name = Faker.Name.First();
                    model = Faker.Internet.UserName();
                    motorcycles.Add(new Motorcycle(name, model, rnd.Next(1980, 2021), rnd.Next(0, 200)));
                }
                motorcycles.PrintAll();
                Motorcycle newMoto = new Motorcycle("Honda", "CBR", 2020, 2000);
                motorcycles.Add(newMoto);
                motorcycles.PrintAll();
                Console.WriteLine(motorcycles.GetById(newMoto.Id));
                newMoto.Name = "Suzuki";
                newMoto.Model = "gsx r1000";
                newMoto.Odometer = 0;
                newMoto.Year = 2021;
                motorcycles.Update(newMoto);
                motorcycles.PrintAll();
                motorcycles.Delete(newMoto.Id);
                motorcycles.PrintAll();
                Motorcycle newMoto1 = new Motorcycle("", "", 2020, 2000);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Something went wrong");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
