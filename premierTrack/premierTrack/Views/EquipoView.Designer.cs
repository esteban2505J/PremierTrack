namespace premierTrack.Views
{
    partial class EquipoView
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
            Eliminar = new TabPage();
            button1 = new Button();
            label1 = new Label();
            dataGridViewDivisiones = new DataGridView();
            Actualizar = new TabPage();
            Crear = new TabPage();
            button2 = new Button();
            label3 = new Label();
            nombre_division = new TextBox();
            label2 = new Label();
            Delete = new TabPage();
            tabControl1 = new TabControl();
            Eliminar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDivisiones).BeginInit();
            Crear.SuspendLayout();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // Eliminar
            // 
            Eliminar.BackColor = Color.DarkSlateGray;
            Eliminar.Controls.Add(button1);
            Eliminar.Controls.Add(label1);
            Eliminar.Controls.Add(dataGridViewDivisiones);
            Eliminar.Location = new Point(4, 29);
            Eliminar.Name = "Eliminar";
            Eliminar.Padding = new Padding(3);
            Eliminar.Size = new Size(786, 413);
            Eliminar.TabIndex = 3;
            Eliminar.Text = "Divisiones";
            Eliminar.Click += Eliminar_Click;
            // 
            // button1
            // 
            button1.Location = new Point(337, 357);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 2;
            button1.Text = "Cargar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(350, 37);
            label1.Name = "label1";
            label1.Size = new Size(109, 28);
            label1.TabIndex = 1;
            label1.Text = "Divisiones";
            // 
            // dataGridViewDivisiones
            // 
            dataGridViewDivisiones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDivisiones.Location = new Point(145, 87);
            dataGridViewDivisiones.Name = "dataGridViewDivisiones";
            dataGridViewDivisiones.RowHeadersWidth = 51;
            dataGridViewDivisiones.Size = new Size(497, 235);
            dataGridViewDivisiones.TabIndex = 0;
            // 
            // Actualizar
            // 
            Actualizar.Location = new Point(4, 29);
            Actualizar.Name = "Actualizar";
            Actualizar.Padding = new Padding(3);
            Actualizar.Size = new Size(786, 413);
            Actualizar.TabIndex = 2;
            Actualizar.Text = "tabPage3";
            Actualizar.UseVisualStyleBackColor = true;
            // 
            // Crear
            // 
            Crear.Controls.Add(button2);
            Crear.Controls.Add(label3);
            Crear.Controls.Add(nombre_division);
            Crear.Controls.Add(label2);
            Crear.Location = new Point(4, 29);
            Crear.Name = "Crear";
            Crear.Padding = new Padding(3);
            Crear.Size = new Size(786, 413);
            Crear.TabIndex = 1;
            Crear.Text = "Crear";
            Crear.UseVisualStyleBackColor = true;
            Crear.Click += Crear_Click;
            // 
            // button2
            // 
            button2.Location = new Point(344, 267);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 3;
            button2.Text = "crear";
            button2.UseVisualStyleBackColor = true;
            button2.Click += Crear_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(297, 37);
            label3.Name = "label3";
            label3.Size = new Size(183, 28);
            label3.TabIndex = 2;
            label3.Text = "Crear una disivión";
            label3.Click += label3_Click;
            // 
            // nombre_division
            // 
            nombre_division.Location = new Point(297, 149);
            nombre_division.Name = "nombre_division";
            nombre_division.Size = new Size(252, 27);
            nombre_division.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(128, 150);
            label2.Name = "label2";
            label2.Size = new Size(81, 23);
            label2.TabIndex = 0;
            label2.Text = "Nombre:";
            label2.Click += label2_Click;
            // 
            // Delete
            // 
            Delete.Location = new Point(4, 29);
            Delete.Name = "Delete";
            Delete.Padding = new Padding(3);
            Delete.Size = new Size(786, 413);
            Delete.TabIndex = 0;
            Delete.Text = "Eliminar";
            Delete.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(Eliminar);
            tabControl1.Controls.Add(Crear);
            tabControl1.Controls.Add(Delete);
            tabControl1.Controls.Add(Actualizar);
            tabControl1.Location = new Point(3, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(794, 446);
            tabControl1.TabIndex = 0;
            // 
            // DivisionView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Name = "DivisionView";
            Text = "Form1";
            Eliminar.ResumeLayout(false);
            Eliminar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDivisiones).EndInit();
            Crear.ResumeLayout(false);
            Crear.PerformLayout();
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabPage Eliminar;
        private TabPage Actualizar;
        private TabPage Crear;
        private TabPage Delete;
        private TabControl tabControl1;
        private Button button1;
        private Label label1;
        private DataGridView dataGridViewDivisiones;
        private Label label3;
        private TextBox nombre_division;
        private Label label2;
        private Button button2;
    }
}