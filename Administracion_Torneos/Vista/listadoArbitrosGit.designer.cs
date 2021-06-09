
namespace Administracion_Torneos.Vista
{
    partial class listadoArbitrosGit
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
            this.listArbitros = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.listArbitros)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(313, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Listado de Árbitros";
            // 
            // listArbitros
            // 
            this.listArbitros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listArbitros.Location = new System.Drawing.Point(29, 74);
            this.listArbitros.Name = "listArbitros";
            this.listArbitros.Size = new System.Drawing.Size(673, 216);
            this.listArbitros.TabIndex = 36;
            // 
            // listadoArbitrosGit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(730, 324);
            this.Controls.Add(this.listArbitros);
            this.Controls.Add(this.label1);
            this.Name = "listadoArbitrosGit";
            this.Text = "Listado Arbitros";
            ((System.ComponentModel.ISupportInitialize)(this.listArbitros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView listArbitros;
    }
}