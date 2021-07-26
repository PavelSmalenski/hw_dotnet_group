using HW02.MotorcycleRepo.Controls.Logging;
using HW02.MotorcycleRepo.Controls.Repositories;
using HW02.MotorcycleRepo.Models;
using System;

namespace HW02.MotorcycleRepo
{
    class Program
    {
        static void Main(string[] args)
        {
            StartProgram();

            // Init static repo using data from DB repo
            var dbRepo = MotorcycleRepositoryProvider.DBRepository;
            var staticRepo = MotorcycleRepositoryProvider.StaticRepository;
            var dbMotorcycles = dbRepo.GetAll();
            foreach (var motorcycle in dbMotorcycles)
            {
                staticRepo.Add(motorcycle);
            }

            TestRepository(dbRepo);
            TestRepository(staticRepo);

            FinishProgram();
            Console.ReadLine();
        }

        public static void TestRepository(IMotorcycleRepository repo)
        {
            // Read
            Motorcycle existingMotorcycle;
            try
            {
                existingMotorcycle = repo.GetAll()[0];
                Console.WriteLine($"READ - item: {existingMotorcycle}");
            }
            catch (IndexOutOfRangeException)
            {
                Logging.GetLogger(LogType.Exception).Error($"Repository should have at least 1 item for testing!");
                return;
            }

            // Update
            string oldName = existingMotorcycle.Name;
            existingMotorcycle.Name = "New Name";

            repo.Update(existingMotorcycle);
            var repoMotorcycle = repo.GetById(existingMotorcycle.Id);
            Console.WriteLine($"UPDATE - item BEFORE: {repoMotorcycle}");

            existingMotorcycle.Name = oldName;
            repo.Update(existingMotorcycle);
            repoMotorcycle = repo.GetById(existingMotorcycle.Id);
            Console.WriteLine($"UPDATE - item AFTER: {repoMotorcycle}");

            // Delete - Add
            repo.Delete(existingMotorcycle.Id);
            Console.WriteLine($"DELETE - repo after delete:");
            foreach (var motorcycle in repo.GetAll())
            {
                Console.WriteLine(motorcycle);
            }

            repo.Add(existingMotorcycle);
            Console.WriteLine($"ADD - repo after add:");
            foreach (var motorcycle in repo.GetAll())
            {
                Console.WriteLine(motorcycle);
            }
        }

        public static void StartProgram()
        {
            Logging.GetLogger(LogType.Application).Information("Application started");
        }

        public static void FinishProgram()
        {
            Logging.GetLogger(LogType.ProgramFinish).Information("Application finished");
        }
    }
}
