using Oracle.ManagedDataAccess.Client;
using premierTrack.Models;
using premierTrack.Utils;
using System;
using System.Data;


namespace premierTrack.DAOs
{
    public class PresidenteDAO
    {
        private readonly DatabaseHelper dbHelper;

        public PresidenteDAO()
        {
            dbHelper = new DatabaseHelper();
        }

        public DataTable GetAllPresidentes()
        {
            try
            {
                return dbHelper.ExecuteQuery("SELECT * FROM presidente ORDER BY id_presidente");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los presidentes: " + ex.Message);
            }
        }

        public Presidente GetPresidenteById(int idPresidente)
        {
            try
            {
                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM presidente WHERE id_presidente = :id";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("id", OracleDbType.Int32).Value = idPresidente;
                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Presidente
                                {
                                    IdPresidente = reader.GetInt32(0),
                                    Nombre = reader.GetString(1),
                                    FechaInicio = reader.IsDBNull(2) ? (DateTime?)null : reader.GetDateTime(2),
                                    FechaFin = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3),
                                    IdEquipo = reader.GetInt32(4)
                                };
                            }
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el presidente: " + ex.Message);
            }
        }

        public void AddPresidente(Presidente presidente)
        {
            try
            {
                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "INSERT INTO presidente (id_presidente, nombre, fecha_icio, fecha_fin, id_equipo) VALUES (:id, :nombre, :inicio, :fin, :eq)";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("id", OracleDbType.Int32).Value = presidente.IdPresidente;
                        command.Parameters.Add("nombre", OracleDbType.Varchar2).Value = presidente.Nombre;
                        command.Parameters.Add("inicio", OracleDbType.Date).Value = (object)presidente.FechaInicio ?? DBNull.Value;
                        command.Parameters.Add("fin", OracleDbType.Date).Value = (object)presidente.FechaFin ?? DBNull.Value;
                        command.Parameters.Add("eq", OracleDbType.Int32).Value = presidente.IdEquipo;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el presidente: " + ex.Message);
            }
        }

        public void UpdatePresidente(Presidente presidente)
        {
            try
            {
                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "UPDATE presidente SET nombre = :nombre, fecha_icio = :inicio, fecha_fin = :fin, id_equipo = :eq WHERE id_presidente = :id";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("nombre", OracleDbType.Varchar2).Value = presidente.Nombre;
                        command.Parameters.Add("inicio", OracleDbType.Date).Value = (object)presidente.FechaInicio ?? DBNull.Value;
                        command.Parameters.Add("fin", OracleDbType.Date).Value = (object)presidente.FechaFin ?? DBNull.Value;
                        command.Parameters.Add("eq", OracleDbType.Int32).Value = presidente.IdEquipo;
                        command.Parameters.Add("id", OracleDbType.Int32).Value = presidente.IdPresidente;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el presidente: " + ex.Message);
            }
        }

        public void DeletePresidente(int idPresidente)
        {
            try
            {
                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "DELETE FROM presidente WHERE id_presidente = :id";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("id", OracleDbType.Int32).Value = idPresidente;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el presidente: " + ex.Message);
            }
        }
    }
}
