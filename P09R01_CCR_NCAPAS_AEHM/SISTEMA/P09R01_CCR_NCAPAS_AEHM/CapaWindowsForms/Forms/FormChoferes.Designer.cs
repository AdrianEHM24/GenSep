namespace CapaWindowsForms.Forms
{
    partial class FormChoferes
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
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.FiltrarComboBox = new System.Windows.Forms.ComboBox();
            this.choferesGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.NombreTextBox = new System.Windows.Forms.TextBox();
            this.ApPatTextBox = new System.Windows.Forms.TextBox();
            this.ApMatTextBox = new System.Windows.Forms.TextBox();
            this.TelefonoTextBox = new System.Windows.Forms.TextBox();
            this.LicenciaTextBox = new System.Windows.Forms.TextBox();
            this.UrlFotoTextBox = new System.Windows.Forms.TextBox();
            this.birthdayTimePicker = new System.Windows.Forms.DateTimePicker();
            this.DisponibilidadCheckBox = new System.Windows.Forms.CheckBox();
            this.Modificarbutton = new System.Windows.Forms.Button();
            this.LimpiarButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.choferesGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.Location = new System.Drawing.Point(21, 589);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(186, 45);
            this.buttonGuardar.TabIndex = 0;
            this.buttonGuardar.Text = "GUARDAR";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(432, 589);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(186, 45);
            this.button3.TabIndex = 2;
            this.button3.Text = "ELIMINAR";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // FiltrarComboBox
            // 
            this.FiltrarComboBox.FormattingEnabled = true;
            this.FiltrarComboBox.Location = new System.Drawing.Point(981, 518);
            this.FiltrarComboBox.Name = "FiltrarComboBox";
            this.FiltrarComboBox.Size = new System.Drawing.Size(254, 24);
            this.FiltrarComboBox.TabIndex = 3;
            this.FiltrarComboBox.SelectedIndexChanged += new System.EventHandler(this.FiltrarComboBox_SelectedIndexChanged);
            // 
            // choferesGridView
            // 
            this.choferesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.choferesGridView.Location = new System.Drawing.Point(507, 39);
            this.choferesGridView.Name = "choferesGridView";
            this.choferesGridView.RowHeadersWidth = 51;
            this.choferesGridView.RowTemplate.Height = 24;
            this.choferesGridView.Size = new System.Drawing.Size(826, 437);
            this.choferesGridView.TabIndex = 4;
            this.choferesGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Apellido Paterno";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Apellido Materno";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "Telefono";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 215);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(215, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "Fecha de Nacimiento";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(26, 255);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 25);
            this.label6.TabIndex = 10;
            this.label6.Text = "Licencia";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(26, 306);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 25);
            this.label7.TabIndex = 11;
            this.label7.Text = "Url Foto";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(781, 518);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 25);
            this.label9.TabIndex = 13;
            this.label9.Text = "Filtrar por:";
            // 
            // NombreTextBox
            // 
            this.NombreTextBox.Location = new System.Drawing.Point(246, 43);
            this.NombreTextBox.Name = "NombreTextBox";
            this.NombreTextBox.Size = new System.Drawing.Size(184, 22);
            this.NombreTextBox.TabIndex = 14;
            // 
            // ApPatTextBox
            // 
            this.ApPatTextBox.Location = new System.Drawing.Point(246, 85);
            this.ApPatTextBox.Name = "ApPatTextBox";
            this.ApPatTextBox.Size = new System.Drawing.Size(184, 22);
            this.ApPatTextBox.TabIndex = 15;
            // 
            // ApMatTextBox
            // 
            this.ApMatTextBox.Location = new System.Drawing.Point(246, 128);
            this.ApMatTextBox.Name = "ApMatTextBox";
            this.ApMatTextBox.Size = new System.Drawing.Size(184, 22);
            this.ApMatTextBox.TabIndex = 16;
            // 
            // TelefonoTextBox
            // 
            this.TelefonoTextBox.Location = new System.Drawing.Point(246, 175);
            this.TelefonoTextBox.Name = "TelefonoTextBox";
            this.TelefonoTextBox.Size = new System.Drawing.Size(184, 22);
            this.TelefonoTextBox.TabIndex = 17;
            // 
            // LicenciaTextBox
            // 
            this.LicenciaTextBox.Location = new System.Drawing.Point(246, 259);
            this.LicenciaTextBox.Name = "LicenciaTextBox";
            this.LicenciaTextBox.Size = new System.Drawing.Size(184, 22);
            this.LicenciaTextBox.TabIndex = 18;
            // 
            // UrlFotoTextBox
            // 
            this.UrlFotoTextBox.Location = new System.Drawing.Point(246, 310);
            this.UrlFotoTextBox.Name = "UrlFotoTextBox";
            this.UrlFotoTextBox.Size = new System.Drawing.Size(184, 22);
            this.UrlFotoTextBox.TabIndex = 19;
            // 
            // birthdayTimePicker
            // 
            this.birthdayTimePicker.Location = new System.Drawing.Point(247, 215);
            this.birthdayTimePicker.Name = "birthdayTimePicker";
            this.birthdayTimePicker.Size = new System.Drawing.Size(194, 22);
            this.birthdayTimePicker.TabIndex = 20;
            // 
            // DisponibilidadCheckBox
            // 
            this.DisponibilidadCheckBox.AutoSize = true;
            this.DisponibilidadCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DisponibilidadCheckBox.Location = new System.Drawing.Point(31, 400);
            this.DisponibilidadCheckBox.Name = "DisponibilidadCheckBox";
            this.DisponibilidadCheckBox.Size = new System.Drawing.Size(169, 29);
            this.DisponibilidadCheckBox.TabIndex = 21;
            this.DisponibilidadCheckBox.Text = "Disponibilidad";
            this.DisponibilidadCheckBox.UseVisualStyleBackColor = true;
            // 
            // Modificarbutton
            // 
            this.Modificarbutton.Location = new System.Drawing.Point(225, 589);
            this.Modificarbutton.Name = "Modificarbutton";
            this.Modificarbutton.Size = new System.Drawing.Size(186, 45);
            this.Modificarbutton.TabIndex = 22;
            this.Modificarbutton.Text = "MODIFICAR";
            this.Modificarbutton.UseVisualStyleBackColor = true;
            this.Modificarbutton.Click += new System.EventHandler(this.Modificarbutton_Click);
            // 
            // LimpiarButton
            // 
            this.LimpiarButton.Location = new System.Drawing.Point(662, 589);
            this.LimpiarButton.Name = "LimpiarButton";
            this.LimpiarButton.Size = new System.Drawing.Size(186, 45);
            this.LimpiarButton.TabIndex = 23;
            this.LimpiarButton.Text = "LIMPIAR CAMPOS";
            this.LimpiarButton.UseVisualStyleBackColor = true;
            this.LimpiarButton.Click += new System.EventHandler(this.LimpiarButton_Click);
            // 
            // FormChoferes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1345, 683);
            this.Controls.Add(this.LimpiarButton);
            this.Controls.Add(this.Modificarbutton);
            this.Controls.Add(this.DisponibilidadCheckBox);
            this.Controls.Add(this.birthdayTimePicker);
            this.Controls.Add(this.UrlFotoTextBox);
            this.Controls.Add(this.LicenciaTextBox);
            this.Controls.Add(this.TelefonoTextBox);
            this.Controls.Add(this.ApMatTextBox);
            this.Controls.Add(this.ApPatTextBox);
            this.Controls.Add(this.NombreTextBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.choferesGridView);
            this.Controls.Add(this.FiltrarComboBox);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.buttonGuardar);
            this.Name = "FormChoferes";
            this.Text = "FormChoferes";
            this.Load += new System.EventHandler(this.FormChoferes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.choferesGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGuardar;
        
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox FiltrarComboBox;
        private System.Windows.Forms.DataGridView choferesGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox NombreTextBox;
        private System.Windows.Forms.TextBox ApPatTextBox;
        private System.Windows.Forms.TextBox ApMatTextBox;
        private System.Windows.Forms.TextBox TelefonoTextBox;
        private System.Windows.Forms.TextBox LicenciaTextBox;
        private System.Windows.Forms.TextBox UrlFotoTextBox;
        private System.Windows.Forms.DateTimePicker birthdayTimePicker;
        private System.Windows.Forms.CheckBox DisponibilidadCheckBox;
        private System.Windows.Forms.Button Modificarbutton;
        private System.Windows.Forms.Button LimpiarButton;
    }
}