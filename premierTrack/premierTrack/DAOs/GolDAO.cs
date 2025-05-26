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
    public class GolDAO
    {
        private readonly DatabaseHelper dbHelper;

        public GolDAO()
        {
            dbHelper = new DatabaseHelper();
        }

        public DataTable GetAllGols()
        {
            try
            {
                return dbHelper.ExecuteQuery("SELECT * FROM gol ORDER BY id_gol");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los goles: " + ex.Message);
            }
        }

        public Gol GetGolById(int idGol)
        {
            try
            {
                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM gol WHERE id_gol = :id";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("id", OracleDbType.Int32).Value = idGol;
                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Gol
                                {
                                    IdGol = reader.GetInt32(0),
                                    IdPartido = reader.GetInt32(1),
                                    IdJugador = reader.GetInt32(2),
                                    TipoGol = reader.GetInt32(3),
                                    Minuto = reader.IsDBNull(4) ? (int?)null : reader.GetInt32(4)
                                };
                            }
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el gol: " + ex.Message);
            }
        }

        public void AddGol(Gol gol)
        {
            try
            {
                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "INSERT INTO gol (id_gol, id_partido, id_jugador, tipo_gol, minuto) VALUES (:id, :part, :jug, :tipo, :min)";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("id", OracleDbType.Int32).Value = gol.IdGol;
                        command.Parameters.Add("part", OracleDbType.Int32).Value = gol.IdPartido;
                        command.Parameters.Add("jug", OracleDbType.Int32).Value = gol.IdJugador;
                        command.Parameters.Add("tipo", OracleDbType.Int32).Value = gol.TipoGol;
                        command.Parameters.Add("min", OracleDbType.Int32).Value = (object)gol.Minuto ?? DBNull.Value;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el gol: " + ex.Message);
            }
        }

        public void UpdateGol(Gol gol)
        {
            try
            {
                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "UPDATE gol SET id_partido = :part, id_jugador = :jug, tipo_gol = :tipo, minuto = :min WHERE id_gol = :id";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("part", OracleDbType.Int32).Value = gol.IdPartido;
                        command.Parameters.Add("jug", OracleDbType.Int32).Value = gol.IdJugador;
                        command.Parameters.Add("tipo", OracleDbType.Int32).Value = gol.TipoGol;
                        command.Parameters.Add("min", OracleDbType.Int32).Value = (object)gol.Minuto ?? DBNull.Value;
                        command.Parameters.Add("id", OracleDbType.Int32).Value = gol.IdGol;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el gol: " + ex.Message);
            }
        }

        public void DeleteGol(int idGol)
        {
            try
            {
                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "DELETE FROM gol WHERE id_gol = :id";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("id", OracleDbType.Int32).Value = idGol;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el gol: " + ex.Message);
            }
        }
    }
}
