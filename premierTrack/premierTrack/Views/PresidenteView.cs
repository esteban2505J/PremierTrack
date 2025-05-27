using premierTrack.DAOs;
using premierTrack.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace premierTrack.Views
{
    public partial class PresidenteView : Form
    {
        private PresidenteDAO presidenteDAO;
        public PresidenteView()
        {
            InitializeComponent();
            presidenteDAO = new PresidenteDAO();

            this.Load += new EventHandler(PresidenteView_Load);

        }

        private void PresidenteView_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Gestión de Presidentes";

            dataGridViewPresidentes.AutoGenerateColumns = true;
            CargarPresidentes();

        }
        private void CargarPresidentes()
        {
            try
            {
                List<Presidente> presidentes = presidenteDAO.GetAllPresidentes();

                // Mostrar información en un mensaje
                if (presidentes == null || presidentes.Count == 0)
                {
                    MessageBox.Show("No se encontraron presidentes en la base de datos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //else
                //{
                //    string mensaje = "Presidentes encontrados:\n";
                //    foreach (var presidente in presidentes)
                //    {
                //        mensaje += $"ID: {presidente.IdPresidente}, Nombre: {presidente.Nombre}, " +
                //                  $"Fecha Inicio: {presidente.FechaInicio?.ToString() ?? "N/A"}, " +
                //                  $"Fecha Fin: {presidente.FechaFin?.ToString() ?? "N/A"}, " +
                //                  $"Cédula: {presidente.Cedula ?? "N/A"}, " +
                //                  $"Nacionalidad: {presidente.Nacionalidad ?? "N/A"}, " +
                //                  $"Fecha Nacimiento: {presidente.FechaNacimiento?.ToString() ?? "N/A"}\n";
                //    }
                //    MessageBox.Show(mensaje, "Información de Presidentes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}

                dataGridViewPresidentes.DataSource = presidentes; // Asignar la lista al DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los presidentes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void LimpiarCampos()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            dateTimePicker1.Value = DateTime.Now;
        }
        private void Crear_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener los datos de los controles
                string nombre = textBox1.Text.Trim();
                string cedula = textBox2.Text.Trim();
                string nacionalidad = textBox3.Text.Trim();
                DateTime? fechaNacimiento = dateTimePicker1.Value;

                // Validar datos obligatorios
                if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(cedula))
                {
                    MessageBox.Show("El nombre y la cédula son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Obtener el siguiente ID
                PresidenteDAO presidenteDAO = new PresidenteDAO();


                // Crear el objeto Presidente
                Presidente presidente = new Presidente
                {

                    Nombre = nombre,
                    Cedula = cedula,
                    Nacionalidad = nacionalidad,
                    FechaNacimiento = fechaNacimiento
                };

                // Guardar en la base de datos
                presidenteDAO.AddPresidente(presidente);

                // Feedback al usuario
                MessageBox.Show($"Presidente creado exitosamente con ID: ", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar los campos
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear el presidente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void nombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void cedula_textChanged(object sender, EventArgs e)
        {

        }

        private void nacionalidad_textChanged(object sender, EventArgs e)
        {

        }

        private void fechaN_textChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Presidentes_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewPresidentes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CargarPresidentes();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Button update 

            string cedulaParaActualizar = txtCedulaBusqueda.Text.Trim(); // Usamos txtCedulaBusqueda como identificador principal

            if (!string.IsNullOrEmpty(cedulaParaActualizar))
            {
                try
                {
                    // Primero, obtenemos el presidente existente por cédula para obtener su ID
                    Presidente presidenteExistente = presidenteDAO.GetPresidenteByCedula(cedulaParaActualizar);

                    if (presidenteExistente == null)
                    {
                        MessageBox.Show("No se encontró un presidente con la cédula especificada para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Actualizamos los datos del objeto Presidente con los valores del formulario
                    presidenteExistente.Nombre = name_update_textbox.Text.Length > 0 ? name_update_textbox.Text : null;
                    presidenteExistente.Nacionalidad = nacionalidad_textbox.Text.Length > 0 ? nacionalidad_textbox.Text : null;

                    // Manejo de fechas nulas usando el Checked de los DateTimePickers
                    presidenteExistente.FechaInicio = fechaIn_update.Checked ? (DateTime?)fechaIn_update.Value : (DateTime?)null;
                    presidenteExistente.FechaFin = fechaFi_update.Checked ? (DateTime?)fechaFi_update.Value : (DateTime?)null;
                    presidenteExistente.FechaNacimiento = fechaNa_update.Checked ? (DateTime?)fechaNa_update.Value : (DateTime?)null;

                    // La cédula no se actualiza directamente en el objeto porque la usamos como clave de búsqueda,
                    // a menos que quieras permitir la actualización de la cédula y uses el ID como clave principal para UPDATE.
                    // Si la cédula también puede cambiar, deberías agregar un campo para la nueva cédula
                    // o usar el ID interno del presidente como el identificador para la operación de actualización.
                    // Por ahora, asumiremos que txtCedulaBusqueda es la cédula ANTERIOR para buscar y que name_update_textbox, etc., son los NUEVOS valores.
                    // Si la cédula TAMBIÉN se actualiza, necesitarías otro TextBox para la "nueva cédula".
                    // Para simplificar, si la cédula es clave única y se actualiza, es mejor usar ID.
                    // Por el momento, el campo txtCedulaBusqueda se usa para CARGAR, no para el valor a actualizar en la DB.
                    // Si la cédula se puede actualizar, necesitas otro campo para el valor de la cédula a actualizar.
                    // Usaremos la cédula de `presidenteExistente` para enviar a la DB, que es la misma que la de búsqueda.
                    // Si quieres actualizar la cédula, tendrías que obtenerla de un nuevo campo o permitir que el usuario la edite en `txtCedulaBusqueda`
                    // y luego pasarla como parte del objeto presidente para la actualización.
                    // Por claridad, vamos a asumir que `txtCedulaBusqueda` es tanto el campo de búsqueda como el campo editable para la cédula,
                    // y la cédula se asigna de nuevo al objeto `presidenteExistente`.

                    presidenteExistente.Cedula = txtCedulaBusqueda.Text.Length > 0 ? txtCedulaBusqueda.Text : null; // Asumiendo que txtCedulaBusqueda es también el campo editable de la cédula.


                    presidenteDAO.UpdatePresidente(presidenteExistente);
                    MessageBox.Show("Presidente actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCamposActualizar();
                    // Opcional: Recargar el DataGridView en la pestaña "Presidentes"
                    // CargarPresidentes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar el presidente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese una cédula para identificar el presidente a actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        // Método para limpiar los campos de la pestaña "Actualizar"
        private void LimpiarCamposActualizar()
        {
            name_update_textbox.Clear();
            txtCedulaBusqueda.Clear();
            nacionalidad_textbox.Clear();
            fechaIn_update.Checked = false;
            fechaFi_update.Checked = false;
            fechaNa_update.Checked = false;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
