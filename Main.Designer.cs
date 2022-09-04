
namespace AoratosWin
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btn_Commence = new System.Windows.Forms.Button();
            this.lbl_About = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Commence
            // 
            this.btn_Commence.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Commence.Location = new System.Drawing.Point(79, 55);
            this.btn_Commence.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Commence.Name = "btn_Commence";
            this.btn_Commence.Size = new System.Drawing.Size(109, 37);
            this.btn_Commence.TabIndex = 0;
            this.btn_Commence.Text = "Commence";
            this.btn_Commence.UseVisualStyleBackColor = true;
            this.btn_Commence.Click += new System.EventHandler(this.btn_Commence_Click);
            // 
            // lbl_About
            // 
            this.lbl_About.AutoSize = true;
            this.lbl_About.Cursor = System.Windows.Forms.Cursors.Help;
            this.lbl_About.Location = new System.Drawing.Point(216, 130);
            this.lbl_About.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_About.Name = "lbl_About";
            this.lbl_About.Size = new System.Drawing.Size(47, 13);
            this.lbl_About.TabIndex = 1;
            this.lbl_About.Text = "[ About ]";
            this.lbl_About.Click += new System.EventHandler(this.lbl_About_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 154);
            this.Controls.Add(this.lbl_About);
            this.Controls.Add(this.btn_Commence);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(284, 193);
            this.MinimumSize = new System.Drawing.Size(284, 193);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AoratosWin";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Commence;
        private System.Windows.Forms.Label lbl_About;
    }
}

