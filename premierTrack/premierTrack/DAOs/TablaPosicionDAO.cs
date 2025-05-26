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
    public class TablaPosicionDAO
    {
        private readonly DatabaseHelper dbHelper;

        public TablaPosicionDAO()
        {
            dbHelper = new DatabaseHelper();
        }

        public DataTable GetAllTablaPosiciones()
        {
            try
            {
                return dbHelper.ExecuteQuery("SELECT * FROM tabla_posicion ORDER BY id_tabla_posiciones");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las tablas de posición: " + ex.Message);
            }
        }

        public TablaPosicion GetTablaPosicionById(int idTablaPosiciones)
        {
            try
            {
                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM tabla_posicion WHERE id_tabla_posiciones = :id";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("id", OracleDbType.Int32).Value = idTablaPosiciones;
                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new TablaPosicion
                                {
                                    IdTablaPosiciones = reader.GetInt32(0),
                                    IdTemporada = reader.GetInt32(1),
                                    IdEquipo = reader.GetInt32(2),
                                    PartidosJugados = reader.GetInt32(3),
                                    Ganados = reader.GetInt32(4),
                                    Empatados = reader.GetInt32(5),
                                    Perdidos = reader.GetInt32(6),
                                    GolesFavor = reader.GetInt32(7),
                                    GolesContra = reader.GetInt32(8),
                                    DiferenciaGoles = reader.GetInt32(9),
                                    Puntos = reader.GetInt32(10),
                                    Posicion = reader.GetInt32(11)
                                };
                            }
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la tabla de posición: " + ex.Message);
            }
        }

        public void AddTablaPosicion(TablaPosicion tablaPosicion)
        {
            try
            {
                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "INSERT INTO tabla_posicion (id_tabla_posiciones, id_temporada, id_equipo, partidos_jugados, ganados, empatados, perdidos, goles_favor, goles_contra, diferencia_goles, puntos, posicion) VALUES (:id, :temp, :eq, :pj, :gan, :emp, :per, :gf, :gc, :dg, :puntos, :pos)";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("id", OracleDbType.Int32).Value = tablaPosicion.IdTablaPosiciones;
                        command.Parameters.Add("temp", OracleDbType.Int32).Value = tablaPosicion.IdTemporada;
                        command.Parameters.Add("eq", OracleDbType.Int32).Value = tablaPosicion.IdEquipo;
                        command.Parameters.Add("pj", OracleDbType.Int32).Value = tablaPosicion.PartidosJugados;
                        command.Parameters.Add("gan", OracleDbType.Int32).Value = tablaPosicion.Ganados;
                        command.Parameters.Add("emp", OracleDbType.Int32).Value = tablaPosicion.Empatados;
                        command.Parameters.Add("per", OracleDbType.Int32).Value = tablaPosicion.Perdidos;
                        command.Parameters.Add("gf", OracleDbType.Int32).Value = tablaPosicion.GolesFavor;
                        command.Parameters.Add("gc", OracleDbType.Int32).Value = tablaPosicion.GolesContra;
                        command.Parameters.Add("dg", OracleDbType.Int32).Value = tablaPosicion.DiferenciaGoles;
                        command.Parameters.Add("puntos", OracleDbType.Int32).Value = tablaPosicion.Puntos;
                        command.Parameters.Add("pos", OracleDbType.Int32).Value = tablaPosicion.Posicion;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar la tabla de posición: " + ex.Message);
            }
        }

        public void UpdateTablaPosicion(TablaPosicion tablaPosicion)
        {
            try
            {
                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "UPDATE tabla_posicion SET id_temporada = :temp, id_equipo = :eq, partidos_jugados = :pj, ganados = :gan, empatados = :emp, perdidos = :per, goles_favor = :gf, goles_contra = :gc, diferencia_goles = :dg, puntos = :puntos, posicion = :pos WHERE id_tabla_posiciones = :id";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("temp", OracleDbType.Int32).Value = tablaPosicion.IdTemporada;
                        command.Parameters.Add("eq", OracleDbType.Int32).Value = tablaPosicion.IdEquipo;
                        command.Parameters.Add("pj", OracleDbType.Int32).Value = tablaPosicion.PartidosJugados;
                        command.Parameters.Add("gan", OracleDbType.Int32).Value = tablaPosicion.Ganados;
                        command.Parameters.Add("emp", OracleDbType.Int32).Value = tablaPosicion.Empatados;
                        command.Parameters.Add("per", OracleDbType.Int32).Value = tablaPosicion.Perdidos;
                        command.Parameters.Add("gf", OracleDbType.Int32).Value = tablaPosicion.GolesFavor;
                        command.Parameters.Add("gc", OracleDbType.Int32).Value = tablaPosicion.GolesContra;
                        command.Parameters.Add("dg", OracleDbType.Int32).Value = tablaPosicion.DiferenciaGoles;
                        command.Parameters.Add("puntos", OracleDbType.Int32).Value = tablaPosicion.Puntos;
                        command.Parameters.Add("pos", OracleDbType.Int32).Value = tablaPosicion.Posicion;
                        command.Parameters.Add("id", OracleDbType.Int32).Value = tablaPosicion.IdTablaPosiciones;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la tabla de posición: " + ex.Message);
            }
        }

        public void DeleteTablaPosicion(int idTablaPosiciones)
        {
            try
            {
                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "DELETE FROM tabla_posicion WHERE id_tabla_posiciones = :id";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("id", OracleDbType.Int32).Value = idTablaPosiciones;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la tabla de posición: " + ex.Message);
            }
        }
    }
}
