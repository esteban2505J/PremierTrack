namespace premierTrack.Views
{
    partial class PresidenteView
    {

       

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
            components = new System.ComponentModel.Container();
            tabControl1 = new TabControl();
            Presidentes = new TabPage();
            button2 = new Button();
            label6 = new Label();
            dataGridViewPresidentes = new DataGridView();
            presidenteDAOBindingSource = new BindingSource(components);
            Crear = new TabPage();
            dateTimePicker1 = new DateTimePicker();
            button1 = new Button();
            label5 = new Label();
            textBox3 = new TextBox();
            label4 = new Label();
            label3 = new Label();
            textBox2 = new TextBox();
            label2 = new Label();
            label1 = new Label();
            textBox1 = new TextBox();
            Actualizar = new TabPage();
            label13 = new Label();
            updateButton = new Button();
            nacionalidad_textbox = new TextBox();
            txtCedulaBusqueda = new TextBox();
            name_update_textbox = new TextBox();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            fechaNa_update = new DateTimePicker();
            fechaFi_update = new DateTimePicker();
            fechaIn_update = new DateTimePicker();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            Eliminar = new TabPage();
            delete_button = new Button();
            cedula_delete = new TextBox();
            label15 = new Label();
            label14 = new Label();
            tabControl1.SuspendLayout();
            Presidentes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPresidentes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)presidenteDAOBindingSource).BeginInit();
            Crear.SuspendLayout();
            Actualizar.SuspendLayout();
            Eliminar.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(Presidentes);
            tabControl1.Controls.Add(Crear);
            tabControl1.Controls.Add(Actualizar);
            tabControl1.Controls.Add(Eliminar);
            tabControl1.Location = new Point(-4, 1);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(879, 518);
            tabControl1.TabIndex = 0;
            // 
            // Presidentes
            // 
            Presidentes.BackColor = Color.DarkSlateGray;
            Presidentes.Controls.Add(button2);
            Presidentes.Controls.Add(label6);
            Presidentes.Controls.Add(dataGridViewPresidentes);
            Presidentes.Cursor = Cursors.Hand;
            Presidentes.Location = new Point(4, 29);
            Presidentes.Name = "Presidentes";
            Presidentes.Padding = new Padding(3);
            Presidentes.Size = new Size(871, 485);
            Presidentes.TabIndex = 0;
            Presidentes.Text = "Presidentes";
            Presidentes.Click += Presidentes_Click;
            // 
            // button2
            // 
            button2.Location = new Point(401, 396);
            button2.Name = "button2";
            button2.Size = new Size(82, 28);
            button2.TabIndex = 2;
            button2.Text = "Cargar presidentes";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.ButtonHighlight;
            label6.Location = new Point(350, 60);
            label6.Name = "label6";
            label6.Size = new Size(213, 46);
            label6.TabIndex = 1;
            label6.Text = "Presidentes ";
            label6.Click += label6_Click;
            // 
            // dataGridViewPresidentes
            // 
            dataGridViewPresidentes.AutoGenerateColumns = false;
            dataGridViewPresidentes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPresidentes.DataSource = presidenteDAOBindingSource;
            dataGridViewPresidentes.Location = new Point(39, 154);
            dataGridViewPresidentes.Name = "dataGridViewPresidentes";
            dataGridViewPresidentes.RowHeadersWidth = 51;
            dataGridViewPresidentes.Size = new Size(804, 198);
            dataGridViewPresidentes.TabIndex = 0;
            dataGridViewPresidentes.CellContentClick += dataGridViewPresidentes_CellContentClick;
            // 
            // presidenteDAOBindingSource
            // 
            presidenteDAOBindingSource.DataSource = typeof(DAOs.PresidenteDAO);
            // 
            // Crear
            // 
            Crear.Controls.Add(dateTimePicker1);
            Crear.Controls.Add(button1);
            Crear.Controls.Add(label5);
            Crear.Controls.Add(textBox3);
            Crear.Controls.Add(label4);
            Crear.Controls.Add(label3);
            Crear.Controls.Add(textBox2);
            Crear.Controls.Add(label2);
            Crear.Controls.Add(label1);
            Crear.Controls.Add(textBox1);
            Crear.Font = new Font("Segoe UI", 10.2F);
            Crear.Location = new Point(4, 29);
            Crear.Name = "Crear";
            Crear.Padding = new Padding(3);
            Crear.Size = new Size(871, 485);
            Crear.TabIndex = 1;
            Crear.Text = "Crear";
            Crear.UseVisualStyleBackColor = true;
            Crear.Click += Crear_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(56, 231);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(314, 30);
            dateTimePicker1.TabIndex = 10;
            // 
            // button1
            // 
            button1.Location = new Point(361, 343);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 9;
            button1.Text = "Crear";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Crear_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(195, 33);
            label5.Name = "label5";
            label5.Size = new Size(450, 38);
            label5.TabIndex = 8;
            label5.Text = "Crear un Registro de un Presidente";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(576, 228);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(182, 30);
            textBox3.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F);
            label4.Location = new Point(456, 231);
            label4.Name = "label4";
            label4.Size = new Size(110, 23);
            label4.TabIndex = 5;
            label4.Text = "Nacionalidad";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F);
            label3.Location = new Point(56, 195);
            label3.Name = "label3";
            label3.Size = new Size(168, 23);
            label3.TabIndex = 4;
            label3.Text = "Fecha de nacimiento";
            label3.Click += label3_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(544, 126);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(214, 30);
            textBox2.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F);
            label2.Location = new Point(456, 133);
            label2.Name = "label2";
            label2.Size = new Size(63, 23);
            label2.TabIndex = 2;
            label2.Text = "Cedula";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F);
            label1.Location = new Point(56, 133);
            label1.Name = "label1";
            label1.Size = new Size(73, 23);
            label1.TabIndex = 1;
            label1.Text = "Nombre";
            label1.Click += label1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(159, 126);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(211, 30);
            textBox1.TabIndex = 0;
            // 
            // Actualizar
            // 
            Actualizar.AccessibleRole = AccessibleRole.None;
            Actualizar.BackColor = Color.DarkSlateGray;
            Actualizar.Controls.Add(label13);
            Actualizar.Controls.Add(updateButton);
            Actualizar.Controls.Add(nacionalidad_textbox);
            Actualizar.Controls.Add(txtCedulaBusqueda);
            Actualizar.Controls.Add(name_update_textbox);
            Actualizar.Controls.Add(label12);
            Actualizar.Controls.Add(label11);
            Actualizar.Controls.Add(label10);
            Actualizar.Controls.Add(fechaNa_update);
            Actualizar.Controls.Add(fechaFi_update);
            Actualizar.Controls.Add(fechaIn_update);
            Actualizar.Controls.Add(label9);
            Actualizar.Controls.Add(label8);
            Actualizar.Controls.Add(label7);
            Actualizar.Location = new Point(4, 29);
            Actualizar.Name = "Actualizar";
            Actualizar.Size = new Size(871, 485);
            Actualizar.TabIndex = 2;
            Actualizar.Text = "Actualizar";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.ForeColor = SystemColors.AppWorkspace;
            label13.Location = new Point(357, 29);
            label13.Name = "label13";
            label13.Size = new Size(214, 28);
            label13.TabIndex = 13;
            label13.Text = "Actualizar Presidente";
            // 
            // updateButton
            // 
            updateButton.ForeColor = SystemColors.ControlText;
            updateButton.Location = new Point(388, 393);
            updateButton.Name = "updateButton";
            updateButton.Size = new Size(94, 29);
            updateButton.TabIndex = 12;
            updateButton.Text = "Actualizar";
            updateButton.UseVisualStyleBackColor = true;
            updateButton.Click += button3_Click;
            // 
            // nacionalidad_textbox
            // 
            nacionalidad_textbox.Location = new Point(176, 202);
            nacionalidad_textbox.Name = "nacionalidad_textbox";
            nacionalidad_textbox.Size = new Size(169, 27);
            nacionalidad_textbox.TabIndex = 11;
            // 
            // txtCedulaBusqueda
            // 
            txtCedulaBusqueda.Location = new Point(588, 112);
            txtCedulaBusqueda.Name = "txtCedulaBusqueda";
            txtCedulaBusqueda.Size = new Size(194, 27);
            txtCedulaBusqueda.TabIndex = 10;
            txtCedulaBusqueda.TextChanged += textBox5_TextChanged;
            // 
            // name_update_textbox
            // 
            name_update_textbox.Location = new Point(176, 109);
            name_update_textbox.Name = "name_update_textbox";
            name_update_textbox.Size = new Size(169, 27);
            name_update_textbox.TabIndex = 9;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label12.ForeColor = SystemColors.ButtonFace;
            label12.Location = new Point(425, 203);
            label12.Name = "label12";
            label12.Size = new Size(157, 23);
            label12.TabIndex = 8;
            label12.Text = "Fecha Nacimiento:";
            label12.Click += label12_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label11.ForeColor = SystemColors.ButtonFace;
            label11.Location = new Point(482, 291);
            label11.Name = "label11";
            label11.Size = new Size(89, 23);
            label11.TabIndex = 7;
            label11.Text = "Fecha Fin:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label10.ForeColor = SystemColors.ButtonFace;
            label10.Location = new Point(31, 295);
            label10.Name = "label10";
            label10.Size = new Size(108, 23);
            label10.TabIndex = 6;
            label10.Text = "Fecha Inicio:";
            // 
            // fechaNa_update
            // 
            fechaNa_update.Location = new Point(588, 198);
            fechaNa_update.Name = "fechaNa_update";
            fechaNa_update.Size = new Size(250, 27);
            fechaNa_update.TabIndex = 5;
            // 
            // fechaFi_update
            // 
            fechaFi_update.Location = new Point(588, 288);
            fechaFi_update.Name = "fechaFi_update";
            fechaFi_update.Size = new Size(250, 27);
            fechaFi_update.TabIndex = 4;
            // 
            // fechaIn_update
            // 
            fechaIn_update.Location = new Point(176, 291);
            fechaIn_update.Name = "fechaIn_update";
            fechaIn_update.Size = new Size(250, 27);
            fechaIn_update.TabIndex = 3;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label9.ForeColor = SystemColors.ButtonFace;
            label9.Location = new Point(31, 201);
            label9.Name = "label9";
            label9.Size = new Size(120, 23);
            label9.TabIndex = 2;
            label9.Text = "Nacionalidad:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label8.ForeColor = SystemColors.ButtonFace;
            label8.Location = new Point(469, 112);
            label8.Name = "label8";
            label8.Size = new Size(70, 23);
            label8.TabIndex = 1;
            label8.Text = "Cedula:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label7.ForeColor = SystemColors.ButtonFace;
            label7.Location = new Point(55, 109);
            label7.Name = "label7";
            label7.Size = new Size(81, 23);
            label7.TabIndex = 0;
            label7.Text = "Nombre:";
            label7.Click += label7_Click;
            // 
            // Eliminar
            // 
            Eliminar.BackColor = Color.DarkSlateGray;
            Eliminar.Controls.Add(delete_button);
            Eliminar.Controls.Add(cedula_delete);
            Eliminar.Controls.Add(label15);
            Eliminar.Controls.Add(label14);
            Eliminar.Location = new Point(4, 29);
            Eliminar.Name = "Eliminar";
            Eliminar.Size = new Size(871, 485);
            Eliminar.TabIndex = 3;
            Eliminar.Text = "Eliminar";
            Eliminar.Click += Eliminar_Click;
            // 
            // delete_button
            // 
            delete_button.Location = new Point(397, 340);
            delete_button.Name = "delete_button";
            delete_button.Size = new Size(94, 29);
            delete_button.TabIndex = 3;
            delete_button.Text = "Eliminar";
            delete_button.UseVisualStyleBackColor = true;
            delete_button.Click += button3_Click_1;
            // 
            // cedula_delete
            // 
            cedula_delete.Location = new Point(313, 148);
            cedula_delete.Name = "cedula_delete";
            cedula_delete.Size = new Size(329, 27);
            cedula_delete.TabIndex = 2;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label15.ForeColor = SystemColors.ButtonFace;
            label15.Location = new Point(42, 152);
            label15.Name = "label15";
            label15.Size = new Size(191, 23);
            label15.TabIndex = 1;
            label15.Text = "Cudula del presidente:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.ForeColor = SystemColors.ButtonFace;
            label14.Location = new Point(280, 34);
            label14.Name = "label14";
            label14.Size = new Size(311, 28);
            label14.TabIndex = 0;
            label14.Text = "Eliminar un Registro Presidente";
            // 
            // PresidenteView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(866, 505);
            Controls.Add(tabControl1);
            Name = "PresidenteView";
            Text = "Form1";
            Load += PresidenteView_Load;
            tabControl1.ResumeLayout(false);
            Presidentes.ResumeLayout(false);
            Presidentes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPresidentes).EndInit();
            ((System.ComponentModel.ISupportInitialize)presidenteDAOBindingSource).EndInit();
            Crear.ResumeLayout(false);
            Crear.PerformLayout();
            Actualizar.ResumeLayout(false);
            Actualizar.PerformLayout();
            Eliminar.ResumeLayout(false);
            Eliminar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TabControl tabControl1;
        private TabPage Presidentes;
        private TabPage Crear;
        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private TextBox textBox2;
        private Label label3;
        private Button button1;
        private Label label5;
        private TextBox textBox3;
        private Label label4;
        private DateTimePicker dateTimePicker1;
        private DataGridView dataGridViewPresidentes;
        private BindingSource presidenteDAOBindingSource;
        private Label label6;
        private Button button2;
        private TabPage Actualizar;
        private Label label11;
        private Label label10;
        private DateTimePicker fechaNa_update;
        private DateTimePicker fechaFi_update;
        private DateTimePicker fechaIn_update;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label12;
        private Label label13;
        private Button updateButton;
        private TextBox nacionalidad_textbox;
        private TextBox txtCedulaBusqueda;
        private TextBox name_update_textbox;
        private TabPage Eliminar;
        private Label label15;
        private Label label14;
        private Button delete_button;
        private TextBox cedula_delete;
    }
}