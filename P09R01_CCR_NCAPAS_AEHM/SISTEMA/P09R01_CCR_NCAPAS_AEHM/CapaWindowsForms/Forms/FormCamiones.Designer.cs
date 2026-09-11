namespace CapaWindowsForms.Forms
{
    partial class FormCamiones
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
            this.GuardarButton = new System.Windows.Forms.Button();
            this.ModificarButton = new System.Windows.Forms.Button();
            this.EliminarButton = new System.Windows.Forms.Button();
            this.LimpiarButton = new System.Windows.Forms.Button();
            this.dataGridViewCamiones = new System.Windows.Forms.DataGridView();
            this.checkBoxDisponibilidad = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxMatricula = new System.Windows.Forms.TextBox();
            this.textBoxMarca = new System.Windows.Forms.TextBox();
            this.textBoxUrlFoto = new System.Windows.Forms.TextBox();
            this.numericUpDownModelo = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCapacidad = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownKilometraje = new System.Windows.Forms.NumericUpDown();
            this.comboBoxTipoCamion = new System.Windows.Forms.ComboBox();
            this.comboBoxFiltrarPor = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCamiones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownModelo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCapacidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKilometraje)).BeginInit();
            this.SuspendLayout();
            // 
            // GuardarButton
            // 
            this.GuardarButton.Location = new System.Drawing.Point(77, 440);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(164, 42);
            this.GuardarButton.TabIndex = 0;
            this.GuardarButton.Text = "GUARDAR";
            this.GuardarButton.UseVisualStyleBackColor = true;
            this.GuardarButton.Click += new System.EventHandler(this.GuardarButton_Click);
            // 
            // ModificarButton
            // 
            this.ModificarButton.Location = new System.Drawing.Point(284, 440);
            this.ModificarButton.Name = "ModificarButton";
            this.ModificarButton.Size = new System.Drawing.Size(164, 42);
            this.ModificarButton.TabIndex = 1;
            this.ModificarButton.Text = "MODIFICAR";
            this.ModificarButton.UseVisualStyleBackColor = true;
            this.ModificarButton.Click += new System.EventHandler(this.ModificarButton_Click);
            // 
            // EliminarButton
            // 
            this.EliminarButton.Location = new System.Drawing.Point(494, 440);
            this.EliminarButton.Name = "EliminarButton";
            this.EliminarButton.Size = new System.Drawing.Size(164, 42);
            this.EliminarButton.TabIndex = 2;
            this.EliminarButton.Text = "ELIMINAR";
            this.EliminarButton.UseVisualStyleBackColor = true;
            this.EliminarButton.Click += new System.EventHandler(this.EliminarButton_Click);
            // 
            // LimpiarButton
            // 
            this.LimpiarButton.Location = new System.Drawing.Point(711, 440);
            this.LimpiarButton.Name = "LimpiarButton";
            this.LimpiarButton.Size = new System.Drawing.Size(164, 42);
            this.LimpiarButton.TabIndex = 3;
            this.LimpiarButton.Text = "LIMPIAR CAMPOS";
            this.LimpiarButton.UseVisualStyleBackColor = true;
            this.LimpiarButton.Click += new System.EventHandler(this.LimpiarButton_Click);
            // 
            // dataGridViewCamiones
            // 
            this.dataGridViewCamiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCamiones.Location = new System.Drawing.Point(494, 12);
            this.dataGridViewCamiones.Name = "dataGridViewCamiones";
            this.dataGridViewCamiones.RowHeadersWidth = 51;
            this.dataGridViewCamiones.RowTemplate.Height = 24;
            this.dataGridViewCamiones.Size = new System.Drawing.Size(848, 406);
            this.dataGridViewCamiones.TabIndex = 4;
            this.dataGridViewCamiones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCamiones_CellContentClick);
            // 
            // checkBoxDisponibilidad
            // 
            this.checkBoxDisponibilidad.AutoSize = true;
            this.checkBoxDisponibilidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxDisponibilidad.Location = new System.Drawing.Point(32, 346);
            this.checkBoxDisponibilidad.Name = "checkBoxDisponibilidad";
            this.checkBoxDisponibilidad.Size = new System.Drawing.Size(169, 29);
            this.checkBoxDisponibilidad.TabIndex = 5;
            this.checkBoxDisponibilidad.Text = "Disponibilidad";
            this.checkBoxDisponibilidad.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Matricula";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tipo de Camion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Modelo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(29, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "Marca";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(29, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 25);
            this.label5.TabIndex = 10;
            this.label5.Text = "Capacidad";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(31, 249);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 25);
            this.label6.TabIndex = 11;
            this.label6.Text = "Kilometraje";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(31, 293);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 25);
            this.label7.TabIndex = 12;
            this.label7.Text = "UrlFoto";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(973, 449);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 25);
            this.label8.TabIndex = 13;
            this.label8.Text = "Filtrar por";
            // 
            // textBoxMatricula
            // 
            this.textBoxMatricula.Location = new System.Drawing.Point(229, 37);
            this.textBoxMatricula.Name = "textBoxMatricula";
            this.textBoxMatricula.Size = new System.Drawing.Size(236, 22);
            this.textBoxMatricula.TabIndex = 14;
            // 
            // textBoxMarca
            // 
            this.textBoxMarca.Location = new System.Drawing.Point(229, 169);
            this.textBoxMarca.Name = "textBoxMarca";
            this.textBoxMarca.Size = new System.Drawing.Size(236, 22);
            this.textBoxMarca.TabIndex = 15;
            // 
            // textBoxUrlFoto
            // 
            this.textBoxUrlFoto.Location = new System.Drawing.Point(229, 296);
            this.textBoxUrlFoto.Name = "textBoxUrlFoto";
            this.textBoxUrlFoto.Size = new System.Drawing.Size(236, 22);
            this.textBoxUrlFoto.TabIndex = 16;
            // 
            // numericUpDownModelo
            // 
            this.numericUpDownModelo.Location = new System.Drawing.Point(229, 125);
            this.numericUpDownModelo.Name = "numericUpDownModelo";
            this.numericUpDownModelo.Size = new System.Drawing.Size(236, 22);
            this.numericUpDownModelo.TabIndex = 17;
            // 
            // numericUpDownCapacidad
            // 
            this.numericUpDownCapacidad.Location = new System.Drawing.Point(229, 209);
            this.numericUpDownCapacidad.Name = "numericUpDownCapacidad";
            this.numericUpDownCapacidad.Size = new System.Drawing.Size(236, 22);
            this.numericUpDownCapacidad.TabIndex = 18;
            // 
            // numericUpDownKilometraje
            // 
            this.numericUpDownKilometraje.Location = new System.Drawing.Point(229, 252);
            this.numericUpDownKilometraje.Name = "numericUpDownKilometraje";
            this.numericUpDownKilometraje.Size = new System.Drawing.Size(236, 22);
            this.numericUpDownKilometraje.TabIndex = 19;
            // 
            // comboBoxTipoCamion
            // 
            this.comboBoxTipoCamion.FormattingEnabled = true;
            this.comboBoxTipoCamion.Location = new System.Drawing.Point(229, 79);
            this.comboBoxTipoCamion.Name = "comboBoxTipoCamion";
            this.comboBoxTipoCamion.Size = new System.Drawing.Size(236, 24);
            this.comboBoxTipoCamion.TabIndex = 20;
            // 
            // comboBoxFiltrarPor
            // 
            this.comboBoxFiltrarPor.FormattingEnabled = true;
            this.comboBoxFiltrarPor.Location = new System.Drawing.Point(1110, 450);
            this.comboBoxFiltrarPor.Name = "comboBoxFiltrarPor";
            this.comboBoxFiltrarPor.Size = new System.Drawing.Size(232, 24);
            this.comboBoxFiltrarPor.TabIndex = 21;
            this.comboBoxFiltrarPor.SelectedIndexChanged += new System.EventHandler(this.comboBoxFiltrarPor_SelectedIndexChanged);
            // 
            // FormCamiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 640);
            this.Controls.Add(this.comboBoxFiltrarPor);
            this.Controls.Add(this.comboBoxTipoCamion);
            this.Controls.Add(this.numericUpDownKilometraje);
            this.Controls.Add(this.numericUpDownCapacidad);
            this.Controls.Add(this.numericUpDownModelo);
            this.Controls.Add(this.textBoxUrlFoto);
            this.Controls.Add(this.textBoxMarca);
            this.Controls.Add(this.textBoxMatricula);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxDisponibilidad);
            this.Controls.Add(this.dataGridViewCamiones);
            this.Controls.Add(this.LimpiarButton);
            this.Controls.Add(this.EliminarButton);
            this.Controls.Add(this.ModificarButton);
            this.Controls.Add(this.GuardarButton);
            this.Name = "FormCamiones";
            this.Text = "FormCamiones";
            this.Load += new System.EventHandler(this.FormCamiones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCamiones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownModelo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCapacidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKilometraje)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GuardarButton;
        private System.Windows.Forms.Button ModificarButton;
        private System.Windows.Forms.Button EliminarButton;
        private System.Windows.Forms.Button LimpiarButton;
        private System.Windows.Forms.DataGridView dataGridViewCamiones;
        private System.Windows.Forms.CheckBox checkBoxDisponibilidad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxMatricula;
        private System.Windows.Forms.TextBox textBoxMarca;
        private System.Windows.Forms.TextBox textBoxUrlFoto;
        private System.Windows.Forms.NumericUpDown numericUpDownModelo;
        private System.Windows.Forms.NumericUpDown numericUpDownCapacidad;
        private System.Windows.Forms.NumericUpDown numericUpDownKilometraje;
        private System.Windows.Forms.ComboBox comboBoxTipoCamion;
        private System.Windows.Forms.ComboBox comboBoxFiltrarPor;
    }
}