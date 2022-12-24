namespace SmartHome.MachineControlers
{
    partial class Garage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.m3 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.guna2ToggleSwitch9 = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.guna2PictureBox8 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.m3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox8)).BeginInit();
            this.SuspendLayout();
            // 
            // m3
            // 
            this.m3.BackColor = System.Drawing.Color.Transparent;
            this.m3.Controls.Add(this.label24);
            this.m3.Controls.Add(this.label23);
            this.m3.Controls.Add(this.label21);
            this.m3.Controls.Add(this.label22);
            this.m3.Controls.Add(this.guna2ToggleSwitch9);
            this.m3.Controls.Add(this.guna2PictureBox8);
            this.m3.FillColor = System.Drawing.Color.White;
            this.m3.Location = new System.Drawing.Point(0, 0);
            this.m3.Name = "m3";
            this.m3.Radius = 12;
            this.m3.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(4)))), ((int)(((byte)(83)))));
            this.m3.ShadowDepth = 70;
            this.m3.Size = new System.Drawing.Size(150, 147);
            this.m3.TabIndex = 42;
            this.m3.Paint += new System.Windows.Forms.PaintEventHandler(this.m3_Paint);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(84, 95);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(0, 13);
            this.label24.TabIndex = 18;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Montserrat SemiBold", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(13, 88);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(0, 14);
            this.label23.TabIndex = 17;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Montserrat SemiBold", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(54, 117);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(44, 14);
            this.label21.TabIndex = 16;
            this.label21.Text = "Garage";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Montserrat SemiBold", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(97, 54);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(27, 14);
            this.label22.TabIndex = 2;
            this.label22.Text = "OFF";
            // 
            // guna2ToggleSwitch9
            // 
            this.guna2ToggleSwitch9.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(6)))), ((int)(((byte)(123)))));
            this.guna2ToggleSwitch9.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(6)))), ((int)(((byte)(123)))));
            this.guna2ToggleSwitch9.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.guna2ToggleSwitch9.CheckedState.InnerColor = System.Drawing.Color.White;
            this.guna2ToggleSwitch9.CheckedState.Parent = this.guna2ToggleSwitch9;
            this.guna2ToggleSwitch9.Location = new System.Drawing.Point(90, 22);
            this.guna2ToggleSwitch9.Name = "guna2ToggleSwitch9";
            this.guna2ToggleSwitch9.ShadowDecoration.Parent = this.guna2ToggleSwitch9;
            this.guna2ToggleSwitch9.Size = new System.Drawing.Size(42, 23);
            this.guna2ToggleSwitch9.TabIndex = 15;
            this.guna2ToggleSwitch9.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2ToggleSwitch9.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2ToggleSwitch9.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.guna2ToggleSwitch9.UncheckedState.InnerColor = System.Drawing.Color.White;
            this.guna2ToggleSwitch9.UncheckedState.Parent = this.guna2ToggleSwitch9;
            this.guna2ToggleSwitch9.CheckedChanged += new System.EventHandler(this.guna2ToggleSwitch9_CheckedChanged);
            // 
            // guna2PictureBox8
            // 
            this.guna2PictureBox8.FillColor = System.Drawing.Color.Blue;
            this.guna2PictureBox8.Image = global::SmartHome.Properties.Resources.garage;
            this.guna2PictureBox8.Location = new System.Drawing.Point(7, 13);
            this.guna2PictureBox8.Name = "guna2PictureBox8";
            this.guna2PictureBox8.ShadowDecoration.Parent = this.guna2PictureBox8;
            this.guna2PictureBox8.Size = new System.Drawing.Size(65, 67);
            this.guna2PictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox8.TabIndex = 0;
            this.guna2PictureBox8.TabStop = false;
            // 
            // Garage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m3);
            this.Name = "Garage";
            this.Load += new System.EventHandler(this.Garage_Load);
            this.m3.ResumeLayout(false);
            this.m3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox8)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel m3;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private Guna.UI2.WinForms.Guna2ToggleSwitch guna2ToggleSwitch9;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox8;
    }
}
