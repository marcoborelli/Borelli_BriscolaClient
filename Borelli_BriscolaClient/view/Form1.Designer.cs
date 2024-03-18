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
            this.bUpdateList = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bJoinRoom = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(9, 393);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(42, 13);
            this.labelName.TabIndex = 4;
            this.labelName.Text = "NOME:";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(126, 390);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(100, 20);
            this.tbName.TabIndex = 2;
            // 
            // lvTables
            // 
            this.lvTables.FullRowSelect = true;
            this.lvTables.HideSelection = false;
            this.lvTables.Location = new System.Drawing.Point(9, 36);
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
            this.labelInfo.Location = new System.Drawing.Point(9, 12);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(47, 13);
            this.labelInfo.TabIndex = 1;
            this.labelInfo.Text = "labelInfo";
            // 
            // labelDebug
            // 
            this.labelDebug.AutoSize = true;
            this.labelDebug.Location = new System.Drawing.Point(12, 503);
            this.labelDebug.Name = "labelDebug";
            this.labelDebug.Size = new System.Drawing.Size(37, 13);
            this.labelDebug.TabIndex = 3;
            this.labelDebug.Text = "debug";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "CREA LA TUA STANZA";
            // 
            // tbRoomName
            // 
            this.tbRoomName.Location = new System.Drawing.Point(12, 23);
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
            this.cbRoomNum.Location = new System.Drawing.Point(188, 23);
            this.cbRoomNum.Name = "cbRoomNum";
            this.cbRoomNum.Size = new System.Drawing.Size(59, 21);
            this.cbRoomNum.TabIndex = 7;
            // 
            // bCreateRoom
            // 
            this.bCreateRoom.Location = new System.Drawing.Point(253, 21);
            this.bCreateRoom.Name = "bCreateRoom";
            this.bCreateRoom.Size = new System.Drawing.Size(25, 22);
            this.bCreateRoom.TabIndex = 8;
            this.bCreateRoom.Text = "+";
            this.bCreateRoom.UseVisualStyleBackColor = true;
            this.bCreateRoom.Click += new System.EventHandler(this.bCreateRoom_Click);
            // 
            // bUpdateList
            // 
            this.bUpdateList.Location = new System.Drawing.Point(232, 7);
            this.bUpdateList.Name = "bUpdateList";
            this.bUpdateList.Size = new System.Drawing.Size(46, 23);
            this.bUpdateList.TabIndex = 9;
            this.bUpdateList.Text = "UPD";
            this.bUpdateList.UseVisualStyleBackColor = true;
            this.bUpdateList.Click += new System.EventHandler(this.bUpdateList_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.bJoinRoom);
            this.panel1.Controls.Add(this.lvTables);
            this.panel1.Controls.Add(this.bUpdateList);
            this.panel1.Controls.Add(this.labelInfo);
            this.panel1.Controls.Add(this.tbName);
            this.panel1.Controls.Add(this.labelName);
            this.panel1.Location = new System.Drawing.Point(15, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(290, 430);
            this.panel1.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.tbRoomName);
            this.panel2.Controls.Add(this.bCreateRoom);
            this.panel2.Controls.Add(this.cbRoomNum);
            this.panel2.Location = new System.Drawing.Point(15, 446);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(290, 50);
            this.panel2.TabIndex = 11;
            // 
            // bJoinRoom
            // 
            this.bJoinRoom.Location = new System.Drawing.Point(232, 390);
            this.bJoinRoom.Name = "bJoinRoom";
            this.bJoinRoom.Size = new System.Drawing.Size(46, 23);
            this.bJoinRoom.TabIndex = 10;
            this.bJoinRoom.Text = "JOIN";
            this.bJoinRoom.UseVisualStyleBackColor = true;
            this.bJoinRoom.Click += new System.EventHandler(this.bJoinRoom_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 539);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelDebug);
            this.Name = "Form1";
            this.Text = "Borelli Marco";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
        private System.Windows.Forms.Button bUpdateList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button bJoinRoom;
    }
}

