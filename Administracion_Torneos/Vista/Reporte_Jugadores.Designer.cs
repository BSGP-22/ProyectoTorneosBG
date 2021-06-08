
namespace Administracion_Torneos.Vista
{
    partial class Reporte_Jugadores
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
            this.reporteJugadores = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.reporteJugadores)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(300, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "REPORTE JUGADORES";
            // 
            // reporteJugadores
            // 
            this.reporteJugadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reporteJugadores.Location = new System.Drawing.Point(31, 95);
            this.reporteJugadores.Name = "reporteJugadores";
            this.reporteJugadores.Size = new System.Drawing.Size(757, 259);
            this.reporteJugadores.TabIndex = 22;
            // 
            // Reporte_Jugadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reporteJugadores);
            this.Controls.Add(this.label1);
            this.Name = "Reporte_Jugadores";
            this.Text = "Reporte_Jugadores";
            this.Load += new System.EventHandler(this.Reporte_Jugadores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.reporteJugadores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView reporteJugadores;
    }
}