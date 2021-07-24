using System;
using System.Collections.Generic;
using System.Text;
using Serilog;
using HW02.MotorcycleRepo.Models;

namespace HW02.MotorcycleRepo.Controls.Repositories
{
    /// <summary>
    /// Static class to provide access to desireable repository
    /// </summary>
    static class MotorcycleRepositoryProvider
    {
        public static List<Motorcycle> Motorcycles;

        static MotorcycleRepositoryProvider()
        {
            Log.Information($"MotorcycleRepositoryProvider constructor");
            Motorcycles = new List<Motorcycle>();
        }
    }
}
