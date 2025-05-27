using Oracle.ManagedDataAccess.Client;
using premierTrack.Models;
using premierTrack.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace premierTrack.DAOs
{
    public class DivisionDAO
    {
        private readonly DatabaseHelper dbHelper;

        public DivisionDAO()
        {
            dbHelper = new DatabaseHelper();
        }

        public DataTable GetAllDivisions()
        {
            try
            {
                // La corrección aquí: "Division" con comillas dobles para Oracle
                return dbHelper.ExecuteQuery("SELECT * FROM \"Division\" ORDER BY id_division");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las divisiones: " + ex.Message);
            }
        }

        public Division GetDivisionById(int idDivision)
        {
            try
            {
                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM Division WHERE id_division = :id";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("id", OracleDbType.Int32).Value = idDivision;
                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Division
                                {
                                    IdDivision = reader.GetInt32(0),
                                    Nombre = reader.GetString(1)
                                };
                            }
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la división: " + ex.Message);
            }
        }

        public void AddDivision(Division division)
        {
            try
            {
                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();

                
                    string query = @"INSERT INTO ""Division"" (""nombre"")
                                  VALUES (:nombre_division)";

                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        // Parámetros para el nombre de la división (asumiendo que tu objeto Division tiene una propiedad Nombre)
                        command.Parameters.Add("nombre_division", OracleDbType.Varchar2).Value = division.Nombre;


                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar la división: " + ex.Message, ex);
            }
        }

        public void UpdateDivision(Division division)
        {
            try
            {
                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "UPDATE Division SET nombre = :nombre WHERE id_division = :id";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("nombre", OracleDbType.Varchar2).Value = division.Nombre;
                        command.Parameters.Add("id", OracleDbType.Int32).Value = division.IdDivision;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la división: " + ex.Message);
            }
        }

        public void DeleteDivision(int idDivision)
        {
            try
            {
                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "DELETE FROM Division WHERE id_division = :id";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("id", OracleDbType.Int32).Value = idDivision;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la división: " + ex.Message);
            }
        }

        public bool DivisionExists(int idDivision)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM division WHERE id_division = :id";
                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("id", OracleDbType.Int32).Value = idDivision;
                        int count = Convert.ToInt32(command.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar la división: " + ex.Message);
            }
        }
    }
}
