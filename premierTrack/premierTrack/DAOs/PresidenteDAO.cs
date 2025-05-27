using Oracle.ManagedDataAccess.Client;
using premierTrack.Models;
using premierTrack.Utils;
using System.Collections.Generic;
using System;
using System.Data;


namespace premierTrack.DAOs
{
    public class PresidenteDAO
    {
        private readonly DatabaseHelper dbHelper;

        public PresidenteDAO()
        {
            dbHelper = new DatabaseHelper();
        }

        public void AddPresidente(Presidente presidente)
        {
            try
            {
                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();

                    string query = @"INSERT INTO ""presidente"" 
                           (""nombre"", ""fecha_inicio"", ""fecha_fin"", ""cedula"", ""nacionalidad"", ""fecha_nacimiento"") 
                           VALUES 
                           (:nombre, :fechaInicio, :fechaFin, :cedula, :nacionalidad, :fechaNacimiento)";

                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("nombre", OracleDbType.Varchar2).Value = presidente.Nombre ?? (object)DBNull.Value;
                        command.Parameters.Add("fechaInicio", OracleDbType.Date).Value = presidente.FechaInicio ?? (object)DBNull.Value;
                        command.Parameters.Add("fechaFin", OracleDbType.Date).Value = presidente.FechaFin ?? (object)DBNull.Value;
                        command.Parameters.Add("cedula", OracleDbType.Varchar2).Value = presidente.Cedula ?? (object)DBNull.Value;
                        command.Parameters.Add("nacionalidad", OracleDbType.Varchar2).Value = presidente.Nacionalidad ?? (object)DBNull.Value;
                        command.Parameters.Add("fechaNacimiento", OracleDbType.Date).Value = presidente.FechaNacimiento ?? (object)DBNull.Value;

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el presidente: " + ex.Message);
            }
        }


        public List<Presidente> GetAllPresidentes()
        {
            var presidentes = new List<Presidente>();

            try
            {
                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();

                    string query = @"SELECT ""id_presidente"", ""nombre"", ""fecha_inicio"", ""fecha_fin"", ""cedula"", ""nacionalidad"", ""fecha_nacimiento"" 
                                   FROM ""presidente""";

                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var presidente = new Presidente
                                {
                                    IdPresidente = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                                    Nombre = reader.IsDBNull(1) ? null : reader.GetString(1),
                                    FechaInicio = reader.IsDBNull(2) ? (DateTime?)null : reader.GetDateTime(2),
                                    FechaFin = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3),
                                    Cedula = reader.IsDBNull(4) ? null : reader.GetString(4),
                                    Nacionalidad = reader.IsDBNull(5) ? null : reader.GetString(5),
                                    FechaNacimiento = reader.IsDBNull(6) ? (DateTime?)null : reader.GetDateTime(6)
                                };
                                presidentes.Add(presidente);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener los presidentes: {ex.Message}", ex);
            }

            return presidentes;
        }


        public void UpdatePresidente(Presidente presidente)
        {
            try
            {
                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();

                    string query = @"
                UPDATE ""presidente"" SET 
                    ""nombre"" = :nombre,
                    ""fecha_inicio"" = :fechaInicio,
                    ""fecha_fin"" = :fechaFin,
                    ""cedula"" = :cedula,
                    ""nacionalidad"" = :nacionalidad,
                    ""fecha_nacimiento"" = :fechaNacimiento
                WHERE 
                    ""id_presidente"" = :idPresidente";

                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("nombre", OracleDbType.Varchar2).Value = presidente.Nombre ?? (object)DBNull.Value;
                        command.Parameters.Add("fechaInicio", OracleDbType.Date).Value = presidente.FechaInicio ?? (object)DBNull.Value;
                        command.Parameters.Add("fechaFin", OracleDbType.Date).Value = presidente.FechaFin ?? (object)DBNull.Value;
                        command.Parameters.Add("cedula", OracleDbType.Varchar2).Value = presidente.Cedula ?? (object)DBNull.Value;
                        command.Parameters.Add("nacionalidad", OracleDbType.Varchar2).Value = presidente.Nacionalidad ?? (object)DBNull.Value;
                        command.Parameters.Add("fechaNacimiento", OracleDbType.Date).Value = presidente.FechaNacimiento ?? (object)DBNull.Value;
                        command.Parameters.Add("idPresidente", OracleDbType.Int32).Value = presidente.IdPresidente;

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected == 0)
                            throw new Exception("No se encontró un presidente con el ID especificado.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el presidente: " + ex.Message);
            }
        }

     
        public Presidente GetPresidenteByCedula(string cedula)
        {
            Presidente presidente = null;
            try
            {
                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT ""id_presidente"", ""nombre"", ""fecha_inicio"", ""fecha_fin"", ""cedula"", ""nacionalidad"", ""fecha_nacimiento"" FROM ""presidente"" WHERE ""cedula"" = :cedula";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("cedula", OracleDbType.Varchar2).Value = cedula;
                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                presidente = new Presidente
                                {
                                    IdPresidente = reader.GetInt32(reader.GetOrdinal("id_presidente")),
                                    Nombre = reader.IsDBNull(reader.GetOrdinal("nombre")) ? null : reader.GetString(reader.GetOrdinal("nombre")),
                                    FechaInicio = reader.IsDBNull(reader.GetOrdinal("fecha_inicio")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("fecha_inicio")),
                                    FechaFin = reader.IsDBNull(reader.GetOrdinal("fecha_fin")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("fecha_fin")),
                                    Cedula = reader.IsDBNull(reader.GetOrdinal("cedula")) ? null : reader.GetString(reader.GetOrdinal("cedula")),
                                    Nacionalidad = reader.IsDBNull(reader.GetOrdinal("nacionalidad")) ? null : reader.GetString(reader.GetOrdinal("nacionalidad")),
                                    FechaNacimiento = reader.IsDBNull(reader.GetOrdinal("fecha_nacimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("fecha_nacimiento"))
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el presidente por cédula: " + ex.Message, ex);
            }
            return presidente;
        }
    }
}
