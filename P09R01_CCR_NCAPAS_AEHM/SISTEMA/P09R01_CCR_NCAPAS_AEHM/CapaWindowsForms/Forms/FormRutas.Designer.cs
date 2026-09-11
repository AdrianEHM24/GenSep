namespace CapaWindowsForms.Forms
{
    partial class FormRutas
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBoxATiempo = new System.Windows.Forms.CheckBox();
            this.comboBoxCamion = new System.Windows.Forms.ComboBox();
            this.comboBoxChofer = new System.Windows.Forms.ComboBox();
            this.textBoxOrigen = new System.Windows.Forms.TextBox();
            this.textBoxDestino = new System.Windows.Forms.TextBox();
            this.dateTimePickerFeSalida = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFeLlegada = new System.Windows.Forms.DateTimePicker();
            this.numericUpDownDistancia = new System.Windows.Forms.NumericUpDown();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.buttonModificar = new System.Windows.Forms.Button();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.buttonLimpiar = new System.Windows.Forms.Button();
            this.dataGridViewRutas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDistancia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRutas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Camion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Chofer";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Origen";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Destino";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(25, 259);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(169, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Fecha de Salida";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(25, 314);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(185, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "Fecha de Llegada";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(25, 371);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 25);
            this.label7.TabIndex = 6;
            this.label7.Text = "Distancia";
            // 
            // checkBoxATiempo
            // 
            this.checkBoxATiempo.AutoSize = true;
            this.checkBoxATiempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxATiempo.Location = new System.Drawing.Point(28, 444);
            this.checkBoxATiempo.Name = "checkBoxATiempo";
            this.checkBoxATiempo.Size = new System.Drawing.Size(119, 29);
            this.checkBoxATiempo.TabIndex = 7;
            this.checkBoxATiempo.Text = "A tiempo";
            this.checkBoxATiempo.UseVisualStyleBackColor = true;
            // 
            // comboBoxCamion
            // 
            this.comboBoxCamion.FormattingEnabled = true;
            this.comboBoxCamion.Location = new System.Drawing.Point(263, 45);
            this.comboBoxCamion.Name = "comboBoxCamion";
            this.comboBoxCamion.Size = new System.Drawing.Size(200, 24);
            this.comboBoxCamion.TabIndex = 8;
            // 
            // comboBoxChofer
            // 
            this.comboBoxChofer.FormattingEnabled = true;
            this.comboBoxChofer.Location = new System.Drawing.Point(263, 102);
            this.comboBoxChofer.Name = "comboBoxChofer";
            this.comboBoxChofer.Size = new System.Drawing.Size(200, 24);
            this.comboBoxChofer.TabIndex = 9;
            // 
            // textBoxOrigen
            // 
            this.textBoxOrigen.Location = new System.Drawing.Point(263, 159);
            this.textBoxOrigen.Name = "textBoxOrigen";
            this.textBoxOrigen.Size = new System.Drawing.Size(200, 22);
            this.textBoxOrigen.TabIndex = 10;
            // 
            // textBoxDestino
            // 
            this.textBoxDestino.Location = new System.Drawing.Point(263, 212);
            this.textBoxDestino.Name = "textBoxDestino";
            this.textBoxDestino.Size = new System.Drawing.Size(200, 22);
            this.textBoxDestino.TabIndex = 11;
            // 
            // dateTimePickerFeSalida
            // 
            this.dateTimePickerFeSalida.Location = new System.Drawing.Point(263, 261);
            this.dateTimePickerFeSalida.Name = "dateTimePickerFeSalida";
            this.dateTimePickerFeSalida.Size = new System.Drawing.Size(200, 22);
            this.dateTimePickerFeSalida.TabIndex = 12;
            // 
            // dateTimePickerFeLlegada
            // 
            this.dateTimePickerFeLlegada.Location = new System.Drawing.Point(263, 317);
            this.dateTimePickerFeLlegada.Name = "dateTimePickerFeLlegada";
            this.dateTimePickerFeLlegada.Size = new System.Drawing.Size(200, 22);
            this.dateTimePickerFeLlegada.TabIndex = 13;
            // 
            // numericUpDownDistancia
            // 
            this.numericUpDownDistancia.Location = new System.Drawing.Point(263, 376);
            this.numericUpDownDistancia.Name = "numericUpDownDistancia";
            this.numericUpDownDistancia.Size = new System.Drawing.Size(200, 22);
            this.numericUpDownDistancia.TabIndex = 14;
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.Location = new System.Drawing.Point(28, 592);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(179, 48);
            this.buttonGuardar.TabIndex = 17;
            this.buttonGuardar.Text = "GUARDAR";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // buttonModificar
            // 
            this.buttonModificar.Location = new System.Drawing.Point(249, 592);
            this.buttonModificar.Name = "buttonModificar";
            this.buttonModificar.Size = new System.Drawing.Size(179, 48);
            this.buttonModificar.TabIndex = 18;
            this.buttonModificar.Text = "MODIFICAR";
            this.buttonModificar.UseVisualStyleBackColor = true;
            this.buttonModificar.Click += new System.EventHandler(this.buttonModificar_Click);
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.Location = new System.Drawing.Point(473, 592);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(179, 48);
            this.buttonEliminar.TabIndex = 19;
            this.buttonEliminar.Text = "ELIMINAR";
            this.buttonEliminar.UseVisualStyleBackColor = true;
            this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // buttonLimpiar
            // 
            this.buttonLimpiar.Location = new System.Drawing.Point(698, 592);
            this.buttonLimpiar.Name = "buttonLimpiar";
            this.buttonLimpiar.Size = new System.Drawing.Size(179, 48);
            this.buttonLimpiar.TabIndex = 20;
            this.buttonLimpiar.Text = "LIMPIAR CAMPOS";
            this.buttonLimpiar.UseVisualStyleBackColor = true;
            this.buttonLimpiar.Click += new System.EventHandler(this.buttonLimpiar_Click);
            // 
            // dataGridViewRutas
            // 
            this.dataGridViewRutas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRutas.Location = new System.Drawing.Point(502, 22);
            this.dataGridViewRutas.Name = "dataGridViewRutas";
            this.dataGridViewRutas.RowHeadersWidth = 51;
            this.dataGridViewRutas.RowTemplate.Height = 24;
            this.dataGridViewRutas.Size = new System.Drawing.Size(824, 533);
            this.dataGridViewRutas.TabIndex = 21;
            this.dataGridViewRutas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewRutas_CellContentClick);
            // 
            // FormRutas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1358, 705);
            this.Controls.Add(this.dataGridViewRutas);
            this.Controls.Add(this.buttonLimpiar);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.buttonModificar);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.numericUpDownDistancia);
            this.Controls.Add(this.dateTimePickerFeLlegada);
            this.Controls.Add(this.dateTimePickerFeSalida);
            this.Controls.Add(this.textBoxDestino);
            this.Controls.Add(this.textBoxOrigen);
            this.Controls.Add(this.comboBoxChofer);
            this.Controls.Add(this.comboBoxCamion);
            this.Controls.Add(this.checkBoxATiempo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormRutas";
            this.Text = "FormRutas";
            this.Load += new System.EventHandler(this.FormRutas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDistancia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRutas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBoxATiempo;
        private System.Windows.Forms.ComboBox comboBoxCamion;
        private System.Windows.Forms.ComboBox comboBoxChofer;
        private System.Windows.Forms.TextBox textBoxOrigen;
        private System.Windows.Forms.TextBox textBoxDestino;
        private System.Windows.Forms.DateTimePicker dateTimePickerFeSalida;
        private System.Windows.Forms.DateTimePicker dateTimePickerFeLlegada;
        private System.Windows.Forms.NumericUpDown numericUpDownDistancia;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.Button buttonModificar;
        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.Button buttonLimpiar;
        private System.Windows.Forms.DataGridView dataGridViewRutas;
    }
}