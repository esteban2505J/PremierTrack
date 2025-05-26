using Oracle.ManagedDataAccess.Client;
using premierTrack.Models;
using premierTrack.Utils;
using System;
using System.Data;


namespace premierTrack.DAOs
{
    public class TipoGolDAO
    {
        private readonly DatabaseHelper dbHelper;

        public TipoGolDAO()
        {
            dbHelper = new DatabaseHelper();
        }

        public DataTable GetAllTipoGols()
        {
            try
            {
                return dbHelper.ExecuteQuery("SELECT * FROM tipo_gol ORDER BY id_tipo_gol");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los tipos de gol: " + ex.Message);
            }
        }

        public TipoGol GetTipoGolById(int idTipoGol)
        {
            try
            {
                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM tipo_gol WHERE id_tipo_gol = :id";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("id", OracleDbType.Int32).Value = idTipoGol;
                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new TipoGol
                                {
                                    IdTipoGol = reader.GetInt32(0),
                                    Nombre = reader.GetString(1),
                                    Descripcion = reader.IsDBNull(2) ? null : reader.GetString(2)
                                };
                            }
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el tipo de gol: " + ex.Message);
            }
        }

        public void AddTipoGol(TipoGol tipoGol)
        {
            try
            {
                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "INSERT INTO tipo_gol (id_tipo_gol, nombre, descripcion) VALUES (:id, :nombre, :desc)";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("id", OracleDbType.Int32).Value = tipoGol.IdTipoGol;
                        command.Parameters.Add("nombre", OracleDbType.Varchar2).Value = tipoGol.Nombre;
                        command.Parameters.Add("desc", OracleDbType.Varchar2).Value = (object)tipoGol.Descripcion ?? DBNull.Value;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el tipo de gol: " + ex.Message);
            }
        }

        public void UpdateTipoGol(TipoGol tipoGol)
        {
            try
            {
                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "UPDATE tipo_gol SET nombre = :nombre, descripcion = :desc WHERE id_tipo_gol = :id";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("nombre", OracleDbType.Varchar2).Value = tipoGol.Nombre;
                        command.Parameters.Add("desc", OracleDbType.Varchar2).Value = (object)tipoGol.Descripcion ?? DBNull.Value;
                        command.Parameters.Add("id", OracleDbType.Int32).Value = tipoGol.IdTipoGol;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el tipo de gol: " + ex.Message);
            }
        }

        public void DeleteTipoGol(int idTipoGol)
        {
            try
            {
                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "DELETE FROM tipo_gol WHERE id_tipo_gol = :id";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("id", OracleDbType.Int32).Value = idTipoGol;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el tipo de gol: " + ex.Message);
            }
        }
    }
}
