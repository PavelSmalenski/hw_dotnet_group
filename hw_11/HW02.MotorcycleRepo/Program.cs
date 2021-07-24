using HW02.MotorcycleRepo.Controls.Repositories;
using HW02.MotorcycleRepo.Models;
using System;

namespace HW02.MotorcycleRepo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Motorcycle moto = new Motorcycle(id: Guid.Parse("6da180ba-05de-4a05-908f-73e92eb316b4"), name: "Minsk8", model: "X250", year: 2010, odometer: 25_358) ;

            MotorcycleRepositoryArray repositoryArray = new MotorcycleRepositoryArray();
            repositoryArray.Add(new Motorcycle(id: Guid.Parse("ba2e3ba9-ee93-42db-930a-6e78c169f836"), name: "Minsk1", model: "X250", year: 2010, odometer: 11_358));
            repositoryArray.Add(new Motorcycle(id: Guid.Parse("d2992a1b-62b4-4ebd-bfa2-245e72e2f0b1"), name: "Minsk2", model: "X250", year: 2010, odometer: 12_358));
            repositoryArray.Add(new Motorcycle(id: Guid.Parse("5aa3718a-408f-4a49-9b4c-5a1a555e887c"), name: "Minsk3", model: "X250", year: 2010, odometer: 13_358));
            repositoryArray.Add(new Motorcycle(id: Guid.Parse("ac138e79-76bf-4dbf-ab0f-fb4a5b679e5f"), name: "Minsk4", model: "X250", year: 2010, odometer: 14_358));
            repositoryArray.Add(new Motorcycle(id: Guid.Parse("759dea39-5bb2-4588-9761-bc3b6ba39b01"), name: "Minsk5", model: "X250", year: 2010, odometer: 15_358));
            repositoryArray.Add(new Motorcycle(id: Guid.Parse("6e063a00-c2d6-4ca6-8667-ed7f58363092"), name: "Minsk6", model: "X250", year: 2010, odometer: 16_358));
            repositoryArray.Add(new Motorcycle(id: Guid.Parse("8deb8533-b63d-4daa-b3bd-7281eae38817"), name: "Minsk7", model: "X250", year: 2010, odometer: 17_358));
            repositoryArray.Add(new Motorcycle(id: Guid.Parse("6da180ba-05de-4a05-908f-73e92eb316b4"), name: "Minsk8", model: "X250", year: 2010, odometer: 18_358));
            repositoryArray.Add(new Motorcycle(id: Guid.Parse("7d230338-dcac-4d63-ba06-26cc7f23347a"), name: "Minsk9", model: "X250", year: 2010, odometer: 19_358));
            repositoryArray.Add(new Motorcycle(id: Guid.Parse("9eadcf42-e630-4f25-a4d6-a56929dbf993"), name: "Minsk10", model: "X250", year: 2010, odometer: 20_358));

            repositoryArray.Delete( Guid.Parse("ac138e79-76bf-4dbf-ab0f-fb4a5b679e5f") );

            repositoryArray.GetById(Guid.Parse("9eadcf42-e630-4f25-a4d6-a56929dbf993"));

            repositoryArray.Update(moto);

        }
    }
}
