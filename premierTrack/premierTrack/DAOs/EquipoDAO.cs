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
    public class EquipoDAO
    {
        private readonly DatabaseHelper dbHelper;

        public EquipoDAO()
        {
            dbHelper = new DatabaseHelper();
        }

        public DataTable GetAllEquipos()
        {
            try
            {
                return dbHelper.ExecuteQuery("SELECT * FROM Equipo ORDER BY ID_Equipo");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los equipos: " + ex.Message);
            }
        }

        public Equipo GetEquipoById(int idEquipo)
        {
            try
            {
                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM Equipo WHERE ID_Equipo = :id";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("id", OracleDbType.Int32).Value = idEquipo;
                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Equipo
                                {
                                    IdEquipo = reader.GetInt32(0),
                                    Nombre = reader.GetString(1),
                                    IdDivision = reader.GetInt32(2),
                                    Ciudad = reader.IsDBNull(3) ? null : reader.GetString(3),
                                    Estadio = reader.IsDBNull(4) ? null : reader.GetString(4),
                                    Presidente = reader.GetInt32(5)
                                };
                            }
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el equipo: " + ex.Message);
            }
        }

        public void AddEquipo(Equipo equipo)
        {
            try
            {
                // Validar que la división exista
                DivisionDAO divisionDAO = new DivisionDAO();
                if (!divisionDAO.DivisionExists(equipo.IdDivision))
                {
                    throw new Exception($"La división con ID {equipo.IdDivision} no existe.");
                }

                

                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "INSERT INTO Equipo (ID_Equipo, nombre, id_division, ciudad, estadio, presidente) " +
                                   "VALUES (:id, :nombre, :div, :ciudad, :estadio, :pres)";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("id", OracleDbType.Int32).Value = equipo.IdEquipo;
                        command.Parameters.Add("nombre", OracleDbType.Varchar2).Value = equipo.Nombre ?? (object)DBNull.Value;
                        command.Parameters.Add("div", OracleDbType.Int32).Value = equipo.IdDivision;
                        command.Parameters.Add("ciudad", OracleDbType.Varchar2).Value = (object)equipo.Ciudad ?? DBNull.Value;
                        command.Parameters.Add("estadio", OracleDbType.Varchar2).Value = (object)equipo.Estadio ?? DBNull.Value;
                        command.Parameters.Add("pres", OracleDbType.Int32).Value = equipo.Presidente;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el equipo: " + ex.Message);
            }
        }

        public void UpdateEquipo(Equipo equipo)
        {
            try
            {
                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "UPDATE Equipo SET nombre = :nombre, id_division = :div, ciudad = :ciudad, estadio = :estadio, presidente = :pres WHERE ID_Equipo = :id";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("nombre", OracleDbType.Varchar2).Value = equipo.Nombre;
                        command.Parameters.Add("div", OracleDbType.Int32).Value = equipo.IdDivision;
                        command.Parameters.Add("ciudad", OracleDbType.Varchar2).Value = (object)equipo.Ciudad ?? DBNull.Value;
                        command.Parameters.Add("estadio", OracleDbType.Varchar2).Value = (object)equipo.Estadio ?? DBNull.Value;
                        command.Parameters.Add("pres", OracleDbType.Int32).Value = equipo.Presidente;
                        command.Parameters.Add("id", OracleDbType.Int32).Value = equipo.IdEquipo;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el equipo: " + ex.Message);
            }
        }

        public void DeleteEquipo(int idEquipo)
        {
            try
            {
                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "DELETE FROM Equipo WHERE ID_Equipo = :id";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("id", OracleDbType.Int32).Value = idEquipo;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el equipo: " + ex.Message);
            }
        }
    }
}
