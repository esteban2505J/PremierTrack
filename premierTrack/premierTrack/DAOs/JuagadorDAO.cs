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
    public class JuagadorDAO
    {
        private readonly DatabaseHelper dbHelper;

        public JuagadorDAO()
        {
            dbHelper = new DatabaseHelper();
        }

        public DataTable GetAllJuagadores()
        {
            try
            {
                return dbHelper.ExecuteQuery("SELECT * FROM Juagador ORDER BY id_jugador");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los jugadores: " + ex.Message);
            }
        }

        public Juagador GetJuagadorById(int idJugador)
        {
            try
            {
                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM Juagador WHERE id_jugador = :id";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("id", OracleDbType.Int32).Value = idJugador;
                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Juagador
                                {
                                    IdJugador = reader.GetInt32(0),
                                    Nombre = reader.GetString(1),
                                    Posicion = reader.GetInt32(2),
                                    NumeroCamiseta = reader.GetInt32(3),
                                    IdEquipo = reader.GetInt32(4),
                                    FechaNacimiento = reader.GetInt32(5),
                                    Nacionalidad = reader.IsDBNull(6) ? null : reader.GetString(6)
                                };
                            }
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el jugador: " + ex.Message);
            }
        }

        public void AddJuagador(Juagador jugador)
        {
            try
            {
                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "INSERT INTO Juagador (id_jugador, nombre, posicion, numero_camiseta, id_equipo, fecha_nacimiento, nacionalidad) VALUES (:id, :nombre, :pos, :num, :eq, :fecha, :nacio)";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("id", OracleDbType.Int32).Value = jugador.IdJugador;
                        command.Parameters.Add("nombre", OracleDbType.Varchar2).Value = jugador.Nombre;
                        command.Parameters.Add("pos", OracleDbType.Int32).Value = jugador.Posicion;
                        command.Parameters.Add("num", OracleDbType.Int32).Value = jugador.NumeroCamiseta;
                        command.Parameters.Add("eq", OracleDbType.Int32).Value = jugador.IdEquipo;
                        command.Parameters.Add("fecha", OracleDbType.Int32).Value = jugador.FechaNacimiento;
                        command.Parameters.Add("nacio", OracleDbType.Varchar2).Value = (object)jugador.Nacionalidad ?? DBNull.Value;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el jugador: " + ex.Message);
            }
        }

        public void UpdateJuagador(Juagador jugador)
        {
            try
            {
                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "UPDATE Juagador SET nombre = :nombre, posicion = :pos, numero_camiseta = :num, id_equipo = :eq, fecha_nacimiento = :fecha, nacionalidad = :nacio WHERE id_jugador = :id";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("nombre", OracleDbType.Varchar2).Value = jugador.Nombre;
                        command.Parameters.Add("pos", OracleDbType.Int32).Value = jugador.Posicion;
                        command.Parameters.Add("num", OracleDbType.Int32).Value = jugador.NumeroCamiseta;
                        command.Parameters.Add("eq", OracleDbType.Int32).Value = jugador.IdEquipo;
                        command.Parameters.Add("fecha", OracleDbType.Int32).Value = jugador.FechaNacimiento;
                        command.Parameters.Add("nacio", OracleDbType.Varchar2).Value = (object)jugador.Nacionalidad ?? DBNull.Value;
                        command.Parameters.Add("id", OracleDbType.Int32).Value = jugador.IdJugador;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el jugador: " + ex.Message);
            }
        }

        public void DeleteJuagador(int idJugador)
        {
            try
            {
                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "DELETE FROM Juagador WHERE id_jugador = :id";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("id", OracleDbType.Int32).Value = idJugador;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el jugador: " + ex.Message);
            }
        }
    }
}
