namespace Borelli_BriscolaClient.view {
    partial class Game {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.bCard3 = new System.Windows.Forms.Button();
            this.bCard1 = new System.Windows.Forms.Button();
            this.bCard2 = new System.Windows.Forms.Button();
            this.lDebug = new System.Windows.Forms.Label();
            this.lBriscola = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bCard3
            // 
            this.bCard3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bCard3.Location = new System.Drawing.Point(304, 55);
            this.bCard3.Name = "bCard3";
            this.bCard3.Size = new System.Drawing.Size(98, 154);
            this.bCard3.TabIndex = 1;
            this.bCard3.UseVisualStyleBackColor = true;
            this.bCard3.Visible = false;
            // 
            // bCard1
            // 
            this.bCard1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bCard1.Location = new System.Drawing.Point(200, 55);
            this.bCard1.Name = "bCard1";
            this.bCard1.Size = new System.Drawing.Size(98, 154);
            this.bCard1.TabIndex = 2;
            this.bCard1.UseVisualStyleBackColor = true;
            this.bCard1.Visible = false;
            // 
            // bCard2
            // 
            this.bCard2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bCard2.Location = new System.Drawing.Point(408, 55);
            this.bCard2.Name = "bCard2";
            this.bCard2.Size = new System.Drawing.Size(98, 154);
            this.bCard2.TabIndex = 3;
            this.bCard2.UseVisualStyleBackColor = true;
            this.bCard2.Visible = false;
            // 
            // lDebug
            // 
            this.lDebug.AutoSize = true;
            this.lDebug.Location = new System.Drawing.Point(12, 9);
            this.lDebug.Name = "lDebug";
            this.lDebug.Size = new System.Drawing.Size(35, 13);
            this.lDebug.TabIndex = 4;
            this.lDebug.Text = "label1";
            // 
            // lBriscola
            // 
            this.lBriscola.AutoSize = true;
            this.lBriscola.Location = new System.Drawing.Point(11, 196);
            this.lBriscola.Name = "lBriscola";
            this.lBriscola.Size = new System.Drawing.Size(35, 13);
            this.lBriscola.TabIndex = 5;
            this.lBriscola.Text = "label2";
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 238);
            this.Controls.Add(this.lBriscola);
            this.Controls.Add(this.lDebug);
            this.Controls.Add(this.bCard2);
            this.Controls.Add(this.bCard1);
            this.Controls.Add(this.bCard3);
            this.Name = "Game";
            this.Text = "Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bCard3;
        private System.Windows.Forms.Button bCard1;
        private System.Windows.Forms.Button bCard2;
        private System.Windows.Forms.Label lDebug;
        private System.Windows.Forms.Label lBriscola;
    }
}