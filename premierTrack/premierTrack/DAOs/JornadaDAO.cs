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
    public class JornadaDAO
    {
        private readonly DatabaseHelper dbHelper;

        public JornadaDAO()
        {
            dbHelper = new DatabaseHelper();
        }

        public DataTable GetAllJornadas()
        {
            try
            {
                return dbHelper.ExecuteQuery("SELECT * FROM Jornada ORDER BY id_jornada");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las jornadas: " + ex.Message);
            }
        }

        public Jornada GetJornadaById(int idJornada)
        {
            try
            {
                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM Jornada WHERE id_jornada = :id";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("id", OracleDbType.Int32).Value = idJornada;
                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Jornada
                                {
                                    IdJornada = reader.GetInt32(0),
                                    NumeroJornada = reader.GetInt32(1),
                                    IdTemporada = reader.GetInt32(2),
                                    FechaInicio = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3),
                                    FechaFin = reader.IsDBNull(4) ? (DateTime?)null : reader.GetDateTime(4),
                                    Estado = reader.IsDBNull(5) ? null : reader.GetString(5)
                                };
                            }
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la jornada: " + ex.Message);
            }
        }

        public void AddJornada(Jornada jornada)
        {
            try
            {
                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "INSERT INTO Jornada (id_jornada, numero_jornada, id_temporada, fecha_inicio, fecha_fin, estado) VALUES (:id, :num, :temp, :inicio, :fin, :est)";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("id", OracleDbType.Int32).Value = jornada.IdJornada;
                        command.Parameters.Add("num", OracleDbType.Int32).Value = jornada.NumeroJornada;
                        command.Parameters.Add("temp", OracleDbType.Int32).Value = jornada.IdTemporada;
                        command.Parameters.Add("inicio", OracleDbType.Date).Value = (object)jornada.FechaInicio ?? DBNull.Value;
                        command.Parameters.Add("fin", OracleDbType.Date).Value = (object)jornada.FechaFin ?? DBNull.Value;
                        command.Parameters.Add("est", OracleDbType.Varchar2).Value = (object)jornada.Estado ?? DBNull.Value;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar la jornada: " + ex.Message);
            }
        }

        public void UpdateJornada(Jornada jornada)
        {
            try
            {
                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "UPDATE Jornada SET numero_jornada = :num, id_temporada = :temp, fecha_inicio = :inicio, fecha_fin = :fin, estado = :est WHERE id_jornada = :id";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("num", OracleDbType.Int32).Value = jornada.NumeroJornada;
                        command.Parameters.Add("temp", OracleDbType.Int32).Value = jornada.IdTemporada;
                        command.Parameters.Add("inicio", OracleDbType.Date).Value = (object)jornada.FechaInicio ?? DBNull.Value;
                        command.Parameters.Add("fin", OracleDbType.Date).Value = (object)jornada.FechaFin ?? DBNull.Value;
                        command.Parameters.Add("est", OracleDbType.Varchar2).Value = (object)jornada.Estado ?? DBNull.Value;
                        command.Parameters.Add("id", OracleDbType.Int32).Value = jornada.IdJornada;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la jornada: " + ex.Message);
            }
        }

        public void DeleteJornada(int idJornada)
        {
            try
            {
                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "DELETE FROM Jornada WHERE id_jornada = :id";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("id", OracleDbType.Int32).Value = idJornada;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la jornada: " + ex.Message);
            }
        }
    }
}
