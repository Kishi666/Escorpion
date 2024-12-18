namespace Escorpion.InterfazesPrincipales
{
    partial class InterfazProduccion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InterfazProduccion));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.proyectoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listaDeCurpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rutaDeProduccionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarPiezaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 24);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(588, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.proyectoToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(588, 24);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // proyectoToolStripMenuItem
            // 
            this.proyectoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listaDeCurpToolStripMenuItem,
            this.rutaDeProduccionToolStripMenuItem,
            this.registrarPiezaToolStripMenuItem});
            this.proyectoToolStripMenuItem.Name = "proyectoToolStripMenuItem";
            this.proyectoToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.proyectoToolStripMenuItem.Text = "Proyecto";
            // 
            // listaDeCurpToolStripMenuItem
            // 
            this.listaDeCurpToolStripMenuItem.Name = "listaDeCurpToolStripMenuItem";
            this.listaDeCurpToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.listaDeCurpToolStripMenuItem.Text = "Lista de Curp";
            this.listaDeCurpToolStripMenuItem.Click += new System.EventHandler(this.listaDeCurpToolStripMenuItem_Click_1);
            // 
            // rutaDeProduccionToolStripMenuItem
            // 
            this.rutaDeProduccionToolStripMenuItem.Name = "rutaDeProduccionToolStripMenuItem";
            this.rutaDeProduccionToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.rutaDeProduccionToolStripMenuItem.Text = "Ruta de Produccion";
            this.rutaDeProduccionToolStripMenuItem.Click += new System.EventHandler(this.rutaDeProduccionToolStripMenuItem_Click_1);
            // 
            // registrarPiezaToolStripMenuItem
            // 
            this.registrarPiezaToolStripMenuItem.Name = "registrarPiezaToolStripMenuItem";
            this.registrarPiezaToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.registrarPiezaToolStripMenuItem.Text = "Registrar pieza";
            this.registrarPiezaToolStripMenuItem.Click += new System.EventHandler(this.registrarPiezaToolStripMenuItem_Click_1);
            // 
            // InterfazProduccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(588, 357);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "InterfazProduccion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem proyectoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listaDeCurpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rutaDeProduccionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarPiezaToolStripMenuItem;
    }
}