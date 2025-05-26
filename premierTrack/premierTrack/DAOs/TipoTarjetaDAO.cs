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
    public class TipoTarjetaDAO
    {
        private readonly DatabaseHelper dbHelper;

        public TipoTarjetaDAO()
        {
            dbHelper = new DatabaseHelper();
        }

        public DataTable GetAllTipoTarjetas()
        {
            try
            {
                return dbHelper.ExecuteQuery("SELECT * FROM tipo_tarjeta ORDER BY id_tipo_tarjeta");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los tipos de tarjeta: " + ex.Message);
            }
        }

        public TipoTarjeta GetTipoTarjetaById(int idTipoTarjeta)
        {
            try
            {
                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM tipo_tarjeta WHERE id_tipo_tarjeta = :id";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("id", OracleDbType.Int32).Value = idTipoTarjeta;
                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new TipoTarjeta
                                {
                                    IdTipoTarjeta = reader.GetInt32(0),
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
                throw new Exception("Error al obtener el tipo de tarjeta: " + ex.Message);
            }
        }

        public void AddTipoTarjeta(TipoTarjeta tipoTarjeta)
        {
            try
            {
                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "INSERT INTO tipo_tarjeta (id_type_tarjeta, nombre, descripcion) VALUES (:id, :nombre, :desc)";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("id", OracleDbType.Int32).Value = tipoTarjeta.IdTipoTarjeta;
                        command.Parameters.Add("nombre", OracleDbType.Varchar2).Value = tipoTarjeta.Nombre;
                        command.Parameters.Add("desc", OracleDbType.Varchar2).Value = (object)tipoTarjeta.Descripcion ?? DBNull.Value;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el tipo de tarjeta: " + ex.Message);
            }
        }

        public void UpdateTipoTarjeta(TipoTarjeta tipoTarjeta)
        {
            try
            {
                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "UPDATE tipo_tarjeta SET nombre = :nombre, descripcion = :desc WHERE id_type_tarjeta = :id";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("nombre", OracleDbType.Varchar2).Value = tipoTarjeta.Nombre;
                        command.Parameters.Add("desc", OracleDbType.Varchar2).Value = (object)tipoTarjeta.Descripcion ?? DBNull.Value;
                        command.Parameters.Add("id", OracleDbType.Int32).Value = tipoTarjeta.IdTipoTarjeta;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el tipo de tarjeta: " + ex.Message);
            }
        }

        public void DeleteTipoTarjeta(int idTipoTarjeta)
        {
            try
            {
                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "DELETE FROM tipo_tarjeta WHERE id_type_tarjeta = :id";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("id", OracleDbType.Int32).Value = idTipoTarjeta;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el tipo de tarjeta: " + ex.Message);
            }
        }
    }
}
