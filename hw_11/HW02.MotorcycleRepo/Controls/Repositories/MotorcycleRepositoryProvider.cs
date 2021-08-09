using System;
using System.Collections.Generic;
using System.Text;

namespace HW02.MotorcycleRepo.Controls.Repositories
{
    /// <summary>
    /// Static class to provide access to desireable repository
    /// </summary>
    static class MotorcycleRepositoryProvider
    {
        static IMotorcycleRepository _staticRepository;
        static IMotorcycleRepository _dbRepository;

        public static IMotorcycleRepository StaticRepository
        {
            get { return _staticRepository; }
        }
        public static IMotorcycleRepository DBRepository
        {
            get { return _dbRepository; }
        }

        static MotorcycleRepositoryProvider()
        {
            _dbRepository = new MotorcycleRepositoryDB();
            _staticRepository = new MotorcycleRepositoryStatic();
        }
    }
}
