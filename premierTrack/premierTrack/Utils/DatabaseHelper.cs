using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


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
                connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["OracleConnection"].ConnectionString;
                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new Exception("La cadena de conexión 'OracleConnection' no está configurada en app.config.");
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
    }
}
