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
    public class PartidoDAO
    {
        private readonly DatabaseHelper dbHelper;

        public PartidoDAO()
        {
            dbHelper = new DatabaseHelper();
        }

        public DataTable GetAllPartidos()
        {
            try
            {
                return dbHelper.ExecuteQuery("SELECT * FROM partido ORDER BY id_partido");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los partidos: " + ex.Message);
            }
        }

        public Partido GetPartidoById(int idPartido)
        {
            try
            {
                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM partido WHERE id_partido = :id";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("id", OracleDbType.Int32).Value = idPartido;
                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Partido
                                {
                                    IdPartido = reader.GetInt32(0),
                                    IdEquipoLocal = reader.GetInt32(1),
                                    IdEquipoVisitante = reader.GetInt32(2),
                                    GolesLocal = reader.GetInt32(3),
                                    GolesVisitante = reader.GetInt32(4),
                                    Fecha = reader.GetDateTime(5),
                                    IdJornada = reader.GetInt32(6),
                                    Estadio = reader.GetString(7)
                                };
                            }
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el partido: " + ex.Message);
            }
        }

        public void AddPartido(Partido partido)
        {
            try
            {
                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "INSERT INTO partido (id_partido, id_equipo_local, id_equipo_visitante, goles_local, goles_visitante, fecha, id_jornada, estadio) VALUES (:id, :loc, :vis, :gloc, :gvis, :fecha, :jor, :est)";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("id", OracleDbType.Int32).Value = partido.IdPartido;
                        command.Parameters.Add("loc", OracleDbType.Int32).Value = partido.IdEquipoLocal;
                        command.Parameters.Add("vis", OracleDbType.Int32).Value = partido.IdEquipoVisitante;
                        command.Parameters.Add("gloc", OracleDbType.Int32).Value = partido.GolesLocal;
                        command.Parameters.Add("gvis", OracleDbType.Int32).Value = partido.GolesVisitante;
                        command.Parameters.Add("fecha", OracleDbType.Date).Value = partido.Fecha;
                        command.Parameters.Add("jor", OracleDbType.Int32).Value = partido.IdJornada;
                        command.Parameters.Add("est", OracleDbType.Varchar2).Value = partido.Estadio;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el partido: " + ex.Message);
            }
        }

        public void UpdatePartido(Partido partido)
        {
            try
            {
                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "UPDATE partido SET id_equipo_local = :loc, id_equipo_visitante = :vis, goles_local = :gloc, goles_visitante = :gvis, fecha = :fecha, id_jornada = :jor, estadio = :est WHERE id_partido = :id";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("loc", OracleDbType.Int32).Value = partido.IdEquipoLocal;
                        command.Parameters.Add("vis", OracleDbType.Int32).Value = partido.IdEquipoVisitante;
                        command.Parameters.Add("gloc", OracleDbType.Int32).Value = partido.GolesLocal;
                        command.Parameters.Add("gvis", OracleDbType.Int32).Value = partido.GolesVisitante;
                        command.Parameters.Add("fecha", OracleDbType.Date).Value = partido.Fecha;
                        command.Parameters.Add("jor", OracleDbType.Int32).Value = partido.IdJornada;
                        command.Parameters.Add("est", OracleDbType.Varchar2).Value = partido.Estadio;
                        command.Parameters.Add("id", OracleDbType.Int32).Value = partido.IdPartido;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el partido: " + ex.Message);
            }
        }

        public void DeletePartido(int idPartido)
        {
            try
            {
                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "DELETE FROM partido WHERE id_partido = :id";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("id", OracleDbType.Int32).Value = idPartido;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el partido: " + ex.Message);
            }
        }
    }
}
