namespace CTeiler
{
    partial class CTeiler
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtEingabe = new System.Windows.Forms.TextBox();
            this.lblEingabe = new System.Windows.Forms.Label();
            this.lblResultat = new System.Windows.Forms.Label();
            this.btnBerechne = new System.Windows.Forms.Button();
            this.btnSchliessen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtEingabe
            // 
            this.txtEingabe.Location = new System.Drawing.Point(150, 10);
            this.txtEingabe.Name = "txtEingabe";
            this.txtEingabe.Size = new System.Drawing.Size(100, 20);
            this.txtEingabe.TabIndex = 0;
            // 
            // lblEingabe
            // 
            this.lblEingabe.Location = new System.Drawing.Point(15, 10);
            this.lblEingabe.Name = "lblEingabe";
            this.lblEingabe.Size = new System.Drawing.Size(100, 20);
            this.lblEingabe.TabIndex = 1;
            this.lblEingabe.Text = "Eingabe";
            // 
            // lblResultat
            // 
            this.lblResultat.AutoSize = true;
            this.lblResultat.Location = new System.Drawing.Point(15, 35);
            this.lblResultat.Name = "lblResultat";
            this.lblResultat.Size = new System.Drawing.Size(0, 13);
            this.lblResultat.TabIndex = 2;
            // 
            // btnBerechne
            // 
            this.btnBerechne.Location = new System.Drawing.Point(260, 10);
            this.btnBerechne.Name = "btnBerechne";
            this.btnBerechne.Size = new System.Drawing.Size(75, 20);
            this.btnBerechne.TabIndex = 3;
            this.btnBerechne.Text = "Berechnen";
            this.btnBerechne.UseVisualStyleBackColor = true;
            this.btnBerechne.Click += new System.EventHandler(this.btnBerechne_Click);
            // 
            // btnSchliessen
            // 
            this.btnSchliessen.Location = new System.Drawing.Point(260, 35);
            this.btnSchliessen.Name = "btnSchliessen";
            this.btnSchliessen.Size = new System.Drawing.Size(75, 20);
            this.btnSchliessen.TabIndex = 4;
            this.btnSchliessen.Text = "Schliessen";
            this.btnSchliessen.UseVisualStyleBackColor = true;
            this.btnSchliessen.Click += new System.EventHandler(this.btnSchliessen_Click);
            // 
            // CTeiler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 211);
            this.Controls.Add(this.btnSchliessen);
            this.Controls.Add(this.btnBerechne);
            this.Controls.Add(this.lblResultat);
            this.Controls.Add(this.lblEingabe);
            this.Controls.Add(this.txtEingabe);
            this.Name = "CTeiler";
            this.RightToLeftLayout = true;
            this.Text = "Teiler bestimmen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEingabe;
        private System.Windows.Forms.Label lblEingabe;
        private System.Windows.Forms.Label lblResultat;
        private System.Windows.Forms.Button btnBerechne;
        private System.Windows.Forms.Button btnSchliessen;
    }
}

