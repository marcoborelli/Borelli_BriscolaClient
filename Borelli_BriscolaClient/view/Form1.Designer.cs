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
            this.label1 = new System.Windows.Forms.Label();
            this.tbRoomName = new System.Windows.Forms.TextBox();
            this.cbRoomNum = new System.Windows.Forms.ComboBox();
            this.bCreateRoom = new System.Windows.Forms.Button();
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
            this.labelDebug.Location = new System.Drawing.Point(9, 473);
            this.labelDebug.Name = "labelDebug";
            this.labelDebug.Size = new System.Drawing.Size(37, 13);
            this.labelDebug.TabIndex = 3;
            this.labelDebug.Text = "debug";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 421);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "CREA LA TUA STANZA";
            // 
            // tbRoomName
            // 
            this.tbRoomName.Location = new System.Drawing.Point(15, 437);
            this.tbRoomName.Name = "tbRoomName";
            this.tbRoomName.Size = new System.Drawing.Size(170, 20);
            this.tbRoomName.TabIndex = 6;
            // 
            // cbRoomNum
            // 
            this.cbRoomNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRoomNum.FormattingEnabled = true;
            this.cbRoomNum.Items.AddRange(new object[] {
            "2",
            "4"});
            this.cbRoomNum.Location = new System.Drawing.Point(191, 437);
            this.cbRoomNum.Name = "cbRoomNum";
            this.cbRoomNum.Size = new System.Drawing.Size(59, 21);
            this.cbRoomNum.TabIndex = 7;
            // 
            // bCreateRoom
            // 
            this.bCreateRoom.Location = new System.Drawing.Point(256, 435);
            this.bCreateRoom.Name = "bCreateRoom";
            this.bCreateRoom.Size = new System.Drawing.Size(25, 22);
            this.bCreateRoom.TabIndex = 8;
            this.bCreateRoom.Text = "+";
            this.bCreateRoom.UseVisualStyleBackColor = true;
            this.bCreateRoom.Click += new System.EventHandler(this.bCreateRoom_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 495);
            this.Controls.Add(this.bCreateRoom);
            this.Controls.Add(this.cbRoomNum);
            this.Controls.Add(this.tbRoomName);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbRoomName;
        private System.Windows.Forms.ComboBox cbRoomNum;
        private System.Windows.Forms.Button bCreateRoom;
    }
}

