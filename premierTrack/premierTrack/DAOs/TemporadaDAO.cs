using System.Data;
using premierTrack.Models;
using premierTrack.Utils;
using Oracle.ManagedDataAccess.Client;
using System;

namespace premierTrack.DAOs

{
    public class TemporadaDAO
    {
        private readonly DatabaseHelper dbHelper;

        public TemporadaDAO()
        {
            dbHelper = new DatabaseHelper();
        }

        public DataTable GetAllTemporadas()
        {
            try
            {
                return dbHelper.ExecuteQuery("SELECT * FROM temporada ORDER BY id_temporada");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las temporadas: " + ex.Message);
            }
        }

        public Temporada GetTemporadaById(int idTemporada)
        {
            try
            {
                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM temporada WHERE id_temporada = :id";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("id", OracleDbType.Int32).Value = idTemporada;
                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Temporada
                                {
                                    IdTemporada = reader.GetInt32(0),
                                    AnioInicio = reader.GetDateTime(1),
                                    AnioFin = reader.GetDateTime(2)
                                };
                            }
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la temporada: " + ex.Message);
            }
        }

        public void AddTemporada(Temporada temporada)
        {
            try
            {
                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "INSERT INTO temporada (id_temporada, anio_inicio, anio_fin) VALUES (:id, :inicio, :fin)";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("id", OracleDbType.Int32).Value = temporada.IdTemporada;
                        command.Parameters.Add("inicio", OracleDbType.Date).Value = temporada.AnioInicio;
                        command.Parameters.Add("fin", OracleDbType.Date).Value = temporada.AnioFin;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar la temporada: " + ex.Message);
            }
        }

        public void UpdateTemporada(Temporada temporada)
        {
            try
            {
                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "UPDATE temporada SET anio_inicio = :inicio, anio_fin = :fin WHERE id_temporada = :id";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("inicio", OracleDbType.Date).Value = temporada.AnioInicio;
                        command.Parameters.Add("fin", OracleDbType.Date).Value = temporada.AnioFin;
                        command.Parameters.Add("id", OracleDbType.Int32).Value = temporada.IdTemporada;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la temporada: " + ex.Message);
            }
        }

        public void DeleteTemporada(int idTemporada)
        {
            try
            {
                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "DELETE FROM temporada WHERE id_temporada = :id";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("id", OracleDbType.Int32).Value = idTemporada;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la temporada: " + ex.Message);
            }
        }
    }
}
