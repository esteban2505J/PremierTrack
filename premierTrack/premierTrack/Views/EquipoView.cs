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
    public partial class EquipoView : Form
    {

        private DivisionDAO divisionDAO;
        public EquipoView()
        {
            InitializeComponent();
            divisionDAO = new DivisionDAO();
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {

        }

        private void PresidenteView_Load(object sender, EventArgs e)
        {
            // ... Tu lógica existente de carga de formulario ...
            // CargarPresidentes(); // Si tienes esto
            CargarPresidentes(); // Llama a la función para cargar las divisiones
        }

        private void CargarPresidentes()
        {
            try
            {
                // Llama a tu método GetAllDivisions que devuelve un DataTable
                DataTable dt = divisionDAO.GetAllDivisions();

                // Asigna el DataTable como DataSource del DataGridView
                dataGridViewDivisiones.DataSource = dt;

                // Opcional: Ajustar el DataGridView para que se ajuste automáticamente
                dataGridViewDivisiones.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las divisiones: " + ex.Message, "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CargarPresidentes();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Crear_Click(object sender, EventArgs e)
        {
            // Lógica para crear una nueva división
            try
            {
                // Verifica que el campo de nombre no esté vacío
                if (string.IsNullOrWhiteSpace(nombre_division.Text))
                {
                    MessageBox.Show("El nombre de la división no puede estar vacío.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Sale del método si el nombre está vacío
                }

                // Crea una nueva instancia de la clase Division
              
                Division nuevaDivision = new Division()
                {
                    Nombre = nombre_division.Text.Trim(),
                   
                };

                // Llama al método AddDivision de tu repositorio
                divisionDAO.AddDivision(nuevaDivision);

                MessageBox.Show("División creada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar el campo de texto después de la creación exitosa
                LimpiarCamposCrear();

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear la división: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCamposCrear()
        {
            nombre_division.Clear();
           
        }

    }
}
