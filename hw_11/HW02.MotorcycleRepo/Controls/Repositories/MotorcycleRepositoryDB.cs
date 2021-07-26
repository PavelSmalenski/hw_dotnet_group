using HW02.MotorcycleRepo.Models;
using HW02.MotorcycleRepo.Controls.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HW02.MotorcycleRepo.Controls.Repositories
{
    class MotorcycleRepositoryDB : IMotorcycleRepository
    {
        // TODO: This should be stored in config file
        string _connectionString = "Server=localhost;Database=hw_dotnet;Trusted_Connection=True;";
        string _targetTable = "hw_11.Motorcycle";

        private List<Motorcycle> ExecuteSQLSelectQuery(string sqlExpression)
        {
            var crudLogger = Logging.Logging.GetLogger(LogType.CRUD);

            List<Motorcycle> resultRows = new List<Motorcycle>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                crudLogger.Information("DB Connection opened");

                try
                {
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        crudLogger.Information("Executing DB read operation");
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                try
                                {
                                    resultRows.Add(new Motorcycle(
                                        Guid.Parse((string)reader["Id"]),
                                        (string)reader["Name"],
                                        (string)reader["Model"],
                                        (int)reader["Year"],
                                        (int)reader["Odometer"]));
                                }
                                catch (FormatException ex)
                                {
                                    Logging.Logging.GetLogger(LogType.Exception).Error($"Failed to convert SQL field to object field type. Reason: {ex.Message}");
                                    return null; // TODO: OR we can try returning result but without failed items
                                }
                            }
                        }
                        crudLogger.Information($"Number of rows read: {resultRows.Count}");
                    }
                }
                catch (SqlException ex)
                {
                    Logging.Logging.GetLogger(LogType.Exception).Error($"Failed to execute SQL '{sqlExpression}'. Reason: {ex.Message}");
                    return null;
                }
            }
            crudLogger.Information("DB Connection closed");

            return resultRows;
        }

        private void ExecuteSQLModifyingQuery(string sqlExpression)
        {
            var crudLogger = Logging.Logging.GetLogger(LogType.CRUD);

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                crudLogger.Information("DB Connection opened");

                using (var command = new SqlCommand(sqlExpression, connection))
                {
                    crudLogger.Information($"Executing DB command: {sqlExpression}");
                    try
                    {
                        var rowsAffectedNum = command.ExecuteNonQuery();
                        crudLogger.Information($"Numver of rows affected: {rowsAffectedNum}");
                    }
                    catch (SqlException ex)
                    {
                        Logging.Logging.GetLogger(LogType.Exception).Error($"Failed to execute SQL '{sqlExpression}'. Reason: {ex.Message}");
                    }
                }
            }
            crudLogger.Information("DB Connection closed");
        }

        public void Add(Motorcycle motorcycle)
        {
            ExecuteSQLModifyingQuery($"INSERT {_targetTable} VALUES ('{motorcycle.Id}', '{motorcycle.Name}', '{motorcycle.Model}', {motorcycle.Year}, {motorcycle.Odometer});");
        }

        public void Delete(Guid id)
        {
            ExecuteSQLModifyingQuery($"DELETE {_targetTable} WHERE [Id]='{id}';");
        }

        public List<Motorcycle> GetAll()
        {
            return ExecuteSQLSelectQuery($"SELECT [Id], [Name], [Model], [Year], [Odometer] FROM {_targetTable};");
        }

        public Motorcycle GetById(Guid id)
        {
            var result = ExecuteSQLSelectQuery($"SELECT [Id], [Name], [Model], [Year], [Odometer] FROM {_targetTable} WHERE [Id]='{id}';");
            if (result == null)
            {
                return null;
            }
            else
            {
                if (result.Count == 0)
                {
                    return null;
                }
                else
                {
                    return result[0];
                }
            }
        }

        public void Update(Motorcycle motorcycle)
        {
            ExecuteSQLModifyingQuery($"UPDATE {_targetTable} SET [Name]='{motorcycle.Name}', [Model]='{motorcycle.Model}', [Year]={motorcycle.Year}, [Odometer]={motorcycle.Odometer} WHERE [Id]='{motorcycle.Id}';");
        }
    }
}
