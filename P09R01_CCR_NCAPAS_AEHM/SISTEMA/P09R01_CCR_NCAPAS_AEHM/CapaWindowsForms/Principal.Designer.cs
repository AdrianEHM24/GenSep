namespace CapaWindowsForms
{
    partial class Principal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cHOFERESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cAMIONESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rUTASToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cHOFERESToolStripMenuItem,
            this.cAMIONESToolStripMenuItem,
            this.rUTASToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(918, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cHOFERESToolStripMenuItem
            // 
            this.cHOFERESToolStripMenuItem.Name = "cHOFERESToolStripMenuItem";
            this.cHOFERESToolStripMenuItem.Size = new System.Drawing.Size(94, 24);
            this.cHOFERESToolStripMenuItem.Text = "CHOFERES";
            this.cHOFERESToolStripMenuItem.Click += new System.EventHandler(this.cHOFERESToolStripMenuItem_Click);
            // 
            // cAMIONESToolStripMenuItem
            // 
            this.cAMIONESToolStripMenuItem.Name = "cAMIONESToolStripMenuItem";
            this.cAMIONESToolStripMenuItem.Size = new System.Drawing.Size(97, 24);
            this.cAMIONESToolStripMenuItem.Text = "CAMIONES";
            this.cAMIONESToolStripMenuItem.Click += new System.EventHandler(this.cAMIONESToolStripMenuItem_Click);
            // 
            // rUTASToolStripMenuItem
            // 
            this.rUTASToolStripMenuItem.Name = "rUTASToolStripMenuItem";
            this.rUTASToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.rUTASToolStripMenuItem.Text = "RUTAS";
            this.rUTASToolStripMenuItem.Click += new System.EventHandler(this.rUTASToolStripMenuItem_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 487);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Principal";
            this.Text = "Principal";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cHOFERESToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cAMIONESToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rUTASToolStripMenuItem;
    }
}

