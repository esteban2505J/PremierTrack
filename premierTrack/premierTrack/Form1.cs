using Oracle.ManagedDataAccess.Client;
using premierTrack.Utils;
using premierTrack.Views;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Windows.Forms;

namespace premierTrack
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DatabaseHelper dbHelper = new DatabaseHelper();
            if (dbHelper.TestConnection(out string errorMessage))
            {
                MessageBox.Show("Conexión a la base de datos exitosa!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"No se pudo conectar a la base de datos: {errorMessage}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        // ✅ AGREGAR ESTE MÉTODO AQUÍ
        private void ProbarConexionDetallada()
        {
            try
            {
                DatabaseHelper dbHelper = new DatabaseHelper();
                string resultado = "=== PRUEBA DE CONEXIÓN DETALLADA ===\n\n";

                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();

                    resultado += "✅ CONEXIÓN EXITOSA\n";
                    resultado += $"Estado: {connection.State}\n";
                    resultado += $"Base de datos: {connection.DatabaseName}\n";
                    resultado += $"Servidor: {connection.DataSource}\n";
                    resultado += $"Versión: {connection.ServerVersion}\n\n";

                    // Probar fecha del servidor
                    string queryFecha = "SELECT SYSDATE FROM DUAL";
                    using (OracleCommand command = new OracleCommand(queryFecha, connection))
                    {
                        DateTime fechaServidor = Convert.ToDateTime(command.ExecuteScalar());
                        resultado += $"Fecha del servidor: {fechaServidor}\n\n";
                    }

                    // Probar tabla presidente
                    try
                    {
                        string queryCount = "SELECT COUNT(*) FROM \"presidente\"";
                        using (OracleCommand command = new OracleCommand(queryCount, connection))
                        {
                            int count = Convert.ToInt32(command.ExecuteScalar());
                            resultado += $"✅ Tabla 'presidente' encontrada: {count} registros\n\n";
                        }

                        // Mostrar estructura de la tabla
                        string queryEstructura = @"SELECT COLUMN_NAME, DATA_TYPE, NULLABLE 
                                                 FROM USER_TAB_COLUMNS 
                                                 WHERE TABLE_NAME = 'PRESIDENTE' 
                                                 ORDER BY COLUMN_ID";

                        using (OracleCommand command = new OracleCommand(queryEstructura, connection))
                        {
                            using (OracleDataReader reader = command.ExecuteReader())
                            {
                                resultado += "Estructura de la tabla:\n";
                                while (reader.Read())
                                {
                                    string columnName = reader["COLUMN_NAME"].ToString();
                                    string dataType = reader["DATA_TYPE"].ToString();
                                    string nullable = reader["NULLABLE"].ToString();
                                    resultado += $"- {columnName}: {dataType} (Nullable: {nullable})\n";
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        resultado += $"❌ Error al acceder a tabla 'presidente': {ex.Message}\n";
                    }
                }

                // Mostrar resultado en MessageBox
                MessageBox.Show(resultado, "Resultado de Prueba", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                string error = $"❌ ERROR DE CONEXIÓN:\n\n";
                error += $"Mensaje: {ex.Message}\n";
                error += $"Tipo: {ex.GetType().Name}\n";
                if (ex.InnerException != null)
                {
                    error += $"Error interno: {ex.InnerException.Message}\n";
                }

                MessageBox.Show(error, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void tablaPosiciónToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tablaDeClasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void presidenteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            PresidenteView presidenteView = new PresidenteView();
            presidenteView.Show(); // No modal


        }


        // ✅ AGREGAR ESTE EVENTO PARA UN MENÚ EXISTENTE
        private void checkDB(object sender, EventArgs e)
        {
            ProbarConexionDetallada(); // Llamar a la función de prueba
        }
    }
}
