using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using dotenv.net;


namespace premierTrack.Utils
{
    public class DatabaseHelper
    {
        private readonly string connectionString;

        // Constructor que lee la cadena de conexión desde app.config
        public DatabaseHelper()
        {
            try
            {
                DotEnv.Load();

                string host = Environment.GetEnvironmentVariable("DB_HOST") ?? "localhost";
                string port = Environment.GetEnvironmentVariable("DB_PORT") ?? "1521";
                string serviceName = Environment.GetEnvironmentVariable("DB_SERVICE_NAME") ?? "XE";
                string userId = Environment.GetEnvironmentVariable("DB_USER") ?? "premiertrack";
                string password = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "password123";


                Console.WriteLine($"DB_HOST: {host}");
                Console.WriteLine($"DB_PORT: {port}");
                Console.WriteLine($"DB_SERVICE_NAME: {serviceName}");
                Console.WriteLine($"DB_USER: {userId}");
                Console.WriteLine($"DB_PASSWORD: {password}");

                connectionString = $"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST={host})(PORT={port})))(CONNECT_DATA=(SERVICE_NAME={serviceName})));User Id=system;Password=1404;";
                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new Exception("La cadena de conexión no se pudo construir debido a variables de entorno faltantes.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al leer la cadena de conexión: " + ex.Message);
            }
        }

        // Método para obtener una conexión
        public OracleConnection GetConnection()
        {
            OracleConnection connection = new OracleConnection(connectionString);
            return connection;
        }

        // Método para ejecutar consultas SELECT y devolver un DataTable
        public DataTable ExecuteQuery(string query)
        {
            using (OracleConnection connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        using (OracleDataAdapter adapter = new OracleDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            return dataTable;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error al ejecutar la consulta: {ex.Message}");
                }
            }
        }

        // Método para ejecutar comandos INSERT, UPDATE, DELETE
        public void ExecuteNonQuery(string query)
        {
            using (OracleConnection connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error al ejecutar el comando: {ex.Message}");
                }


            }
        }

        public bool TestConnection(out string errorMessage)
        {
            using (OracleConnection connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    errorMessage = null;
                    return true;
                }
                catch (Exception ex)
                {
                    errorMessage = ex.Message;
                    return false;
                }
            }
        }
    }
}
