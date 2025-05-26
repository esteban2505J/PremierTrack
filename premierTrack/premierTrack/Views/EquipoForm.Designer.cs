namespace premierTrack.Views
{
    partial class EquipoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            Nombre = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            cantidadJugadores = new DataGridViewTextBoxColumn();
            Crear_partido = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Nombre, Column1, Column2, cantidadJugadores });
            dataGridView1.Location = new Point(129, 198);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(552, 188);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += this.dataGridView1_CellContentClick;
            // 
            // Nombre
            // 
            Nombre.HeaderText = "Nombre equipo";
            Nombre.MinimumWidth = 6;
            Nombre.Name = "Nombre";
            Nombre.Width = 125;
            // 
            // Column1
            // 
            Column1.HeaderText = "Estadio";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.Width = 125;
            // 
            // Column2
            // 
            Column2.HeaderText = "Presidente";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.Width = 125;
            // 
            // cantidadJugadores
            // 
            cantidadJugadores.HeaderText = "Ciudad";
            cantidadJugadores.MinimumWidth = 6;
            cantidadJugadores.Name = "cantidadJugadores";
            cantidadJugadores.Width = 125;
            // 
            // Crear_partido
            // 
            Crear_partido.BackColor = SystemColors.GradientActiveCaption;
            Crear_partido.Location = new Point(547, 80);
            Crear_partido.Name = "Crear_partido";
            Crear_partido.Size = new Size(134, 48);
            Crear_partido.TabIndex = 1;
            Crear_partido.Text = "Crear equipo";
            Crear_partido.UseVisualStyleBackColor = false;
            Crear_partido.Click += this.button1_Click;
            // 
            // EquipoForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Crear_partido);
            Controls.Add(dataGridView1);
            Name = "EquipoForm";
            Text = "Form1";
            Load += this.EquipoForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn cantidadJugadores;
        private Button Crear_partido;
    }
}