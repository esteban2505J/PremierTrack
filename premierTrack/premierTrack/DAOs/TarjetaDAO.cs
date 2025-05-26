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
    public class TarjetaDAO
    {
        private readonly DatabaseHelper dbHelper;

        public TarjetaDAO()
        {
            dbHelper = new DatabaseHelper();
        }

        public DataTable GetAllTarjetas()
        {
            try
            {
                return dbHelper.ExecuteQuery("SELECT * FROM tarjeta ORDER BY id_tarjeta");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las tarjetas: " + ex.Message);
            }
        }

        public Tarjeta GetTarjetaById(int idTarjeta)
        {
            try
            {
                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM tarjeta WHERE id_tarjeta = :id";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("id", OracleDbType.Int32).Value = idTarjeta;
                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Tarjeta
                                {
                                    IdTarjeta = reader.GetInt32(0),
                                    IdPartido = reader.GetInt32(1),
                                    IdJugador = reader.GetInt32(2),
                                    Minuto = reader.IsDBNull(3) ? (int?)null : reader.GetInt32(3),
                                    IdTipoTarjeta = reader.GetInt32(4)
                                };
                            }
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la tarjeta: " + ex.Message);
            }
        }

        public void AddTarjeta(Tarjeta tarjeta)
        {
            try
            {
                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "INSERT INTO tarjeta (id_tarjeta, id_partido, id_jugador, minuto, id_type_tarjeta) VALUES (:id, :part, :jug, :min, :tipo)";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("id", OracleDbType.Int32).Value = tarjeta.IdTarjeta;
                        command.Parameters.Add("part", OracleDbType.Int32).Value = tarjeta.IdPartido;
                        command.Parameters.Add("jug", OracleDbType.Int32).Value = tarjeta.IdJugador;
                        command.Parameters.Add("min", OracleDbType.Int32).Value = (object)tarjeta.Minuto ?? DBNull.Value;
                        command.Parameters.Add("tipo", OracleDbType.Int32).Value = tarjeta.IdTipoTarjeta;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar la tarjeta: " + ex.Message);
            }
        }

        public void UpdateTarjeta(Tarjeta tarjeta)
        {
            try
            {
                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "UPDATE tarjeta SET id_partido = :part, id_jugador = :jug, minuto = :min, id_type_tarjeta = :tipo WHERE id_tarjeta = :id";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("part", OracleDbType.Int32).Value = tarjeta.IdPartido;
                        command.Parameters.Add("jug", OracleDbType.Int32).Value = tarjeta.IdJugador;
                        command.Parameters.Add("min", OracleDbType.Int32).Value = (object)tarjeta.Minuto ?? DBNull.Value;
                        command.Parameters.Add("tipo", OracleDbType.Int32).Value = tarjeta.IdTipoTarjeta;
                        command.Parameters.Add("id", OracleDbType.Int32).Value = tarjeta.IdTarjeta;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la tarjeta: " + ex.Message);
            }
        }

        public void DeleteTarjeta(int idTarjeta)
        {
            try
            {
                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "DELETE FROM tarjeta WHERE id_tarjeta = :id";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("id", OracleDbType.Int32).Value = idTarjeta;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la tarjeta: " + ex.Message);
            }
        }
    }
}
