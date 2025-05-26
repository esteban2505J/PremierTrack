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
    public class EstadisticasJugadorDAO
    {
        private readonly DatabaseHelper dbHelper;

        public EstadisticasJugadorDAO()
        {
            dbHelper = new DatabaseHelper();
        }

        public DataTable GetAllEstadisticasJugadores()
        {
            try
            {
                return dbHelper.ExecuteQuery("SELECT * FROM estadisticas_jugador ORDER BY id_estadistica");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las estadísticas de jugadores: " + ex.Message);
            }
        }

        public EstadisticasJugador GetEstadisticaById(int idEstadistica)
        {
            try
            {
                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM estadisticas_jugador WHERE id_estadistica = :id";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("id", OracleDbType.Int32).Value = idEstadistica;
                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new EstadisticasJugador
                                {
                                    IdEstadistica = reader.GetInt32(0),
                                    IdJugador = reader.GetInt32(1),
                                    IdPartido = reader.GetInt32(2),
                                    IdTemporada = reader.GetInt32(3),
                                    CantidadGoles = reader.IsDBNull(4) ? (int?)null : reader.GetInt32(4),
                                    Asistencias = reader.IsDBNull(5) ? (int?)null : reader.GetInt32(5),
                                    TirosAPuerta = reader.IsDBNull(6) ? (int?)null : reader.GetInt32(6),
                                    PasesCompletados = reader.IsDBNull(7) ? (int?)null : reader.GetInt32(7),
                                    TarjetasAmarillas = reader.IsDBNull(8) ? (int?)null : reader.GetInt32(8),
                                    TarjetasRojas = reader.IsDBNull(9) ? (int?)null : reader.GetInt32(9)
                                };
                            }
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la estadística: " + ex.Message);
            }
        }

        public void AddEstadisticaJugador(EstadisticasJugador estadistica)
        {
            try
            {
                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "INSERT INTO estadisticas_jugador (id_estadistica, id_jugador, id_partido, id_temporada, cantidad_goles, asistencias, tiros_a_puerta, pases_completados, tarjetas_amarillas, tarjetas_rojas) VALUES (:id, :jug, :part, :temp, :goles, :asist, :tiros, :pases, :amarillas, :rojas)";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("id", OracleDbType.Int32).Value = estadistica.IdEstadistica;
                        command.Parameters.Add("jug", OracleDbType.Int32).Value = estadistica.IdJugador;
                        command.Parameters.Add("part", OracleDbType.Int32).Value = estadistica.IdPartido;
                        command.Parameters.Add("temp", OracleDbType.Int32).Value = estadistica.IdTemporada;
                        command.Parameters.Add("goles", OracleDbType.Int32).Value = (object)estadistica.CantidadGoles ?? DBNull.Value;
                        command.Parameters.Add("asist", OracleDbType.Int32).Value = (object)estadistica.Asistencias ?? DBNull.Value;
                        command.Parameters.Add("tiros", OracleDbType.Int32).Value = (object)estadistica.TirosAPuerta ?? DBNull.Value;
                        command.Parameters.Add("pases", OracleDbType.Int32).Value = (object)estadistica.PasesCompletados ?? DBNull.Value;
                        command.Parameters.Add("amarillas", OracleDbType.Int32).Value = (object)estadistica.TarjetasAmarillas ?? DBNull.Value;
                        command.Parameters.Add("rojas", OracleDbType.Int32).Value = (object)estadistica.TarjetasRojas ?? DBNull.Value;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar la estadística: " + ex.Message);
            }
        }

        public void UpdateEstadisticaJugador(EstadisticasJugador estadistica)
        {
            try
            {
                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "UPDATE estadisticas_jugador SET id_jugador = :jug, id_partido = :part, id_temporada = :temp, cantidad_goles = :goles, asistencias = :asist, tiros_a_puerta = :tiros, pases_completados = :pases, tarjetas_amarillas = :amarillas, tarjetas_rojas = :rojas WHERE id_estadistica = :id";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("jug", OracleDbType.Int32).Value = estadistica.IdJugador;
                        command.Parameters.Add("part", OracleDbType.Int32).Value = estadistica.IdPartido;
                        command.Parameters.Add("temp", OracleDbType.Int32).Value = estadistica.IdTemporada;
                        command.Parameters.Add("goles", OracleDbType.Int32).Value = (object)estadistica.CantidadGoles ?? DBNull.Value;
                        command.Parameters.Add("asist", OracleDbType.Int32).Value = (object)estadistica.Asistencias ?? DBNull.Value;
                        command.Parameters.Add("tiros", OracleDbType.Int32).Value = (object)estadistica.TirosAPuerta ?? DBNull.Value;
                        command.Parameters.Add("pases", OracleDbType.Int32).Value = (object)estadistica.PasesCompletados ?? DBNull.Value;
                        command.Parameters.Add("amarillas", OracleDbType.Int32).Value = (object)estadistica.TarjetasAmarillas ?? DBNull.Value;
                        command.Parameters.Add("rojas", OracleDbType.Int32).Value = (object)estadistica.TarjetasRojas ?? DBNull.Value;
                        command.Parameters.Add("id", OracleDbType.Int32).Value = estadistica.IdEstadistica;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la estadística: " + ex.Message);
            }
        }

        public void DeleteEstadisticaJugador(int idEstadistica)
        {
            try
            {
                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "DELETE FROM estadisticas_jugador WHERE id_estadistica = :id";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("id", OracleDbType.Int32).Value = idEstadistica;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la estadística: " + ex.Message);
            }
        }
    }
}
