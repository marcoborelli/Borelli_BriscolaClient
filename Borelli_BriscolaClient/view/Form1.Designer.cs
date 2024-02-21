namespace Borelli_BriscolaClient.view {
    partial class Form1 {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent() {
            this.labelName = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lvTables = new System.Windows.Forms.ListView();
            this.labelInfo = new System.Windows.Forms.Label();
            this.labelDebug = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(12, 390);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(42, 13);
            this.labelName.TabIndex = 4;
            this.labelName.Text = "NOME:";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(181, 387);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(100, 20);
            this.tbName.TabIndex = 2;
            // 
            // lvTables
            // 
            this.lvTables.FullRowSelect = true;
            this.lvTables.HideSelection = false;
            this.lvTables.Location = new System.Drawing.Point(12, 33);
            this.lvTables.Name = "lvTables";
            this.lvTables.Size = new System.Drawing.Size(269, 348);
            this.lvTables.TabIndex = 0;
            this.lvTables.UseCompatibleStateImageBehavior = false;
            this.lvTables.View = System.Windows.Forms.View.Details;
            this.lvTables.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvTables_MouseDoubleClick);
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Location = new System.Drawing.Point(12, 9);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(47, 13);
            this.labelInfo.TabIndex = 1;
            this.labelInfo.Text = "labelInfo";
            // 
            // labelDebug
            // 
            this.labelDebug.AutoSize = true;
            this.labelDebug.Location = new System.Drawing.Point(12, 425);
            this.labelDebug.Name = "labelDebug";
            this.labelDebug.Size = new System.Drawing.Size(42, 13);
            this.labelDebug.TabIndex = 3;
            this.labelDebug.Text = "NOME:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 495);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelDebug);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.lvTables);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.ListView lvTables;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Label labelDebug;
    }
}

