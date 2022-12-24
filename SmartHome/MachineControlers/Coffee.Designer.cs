namespace SmartHome.MachineControlers
{
    partial class Coffee
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
            this.components = new System.ComponentModel.Container();
            this.m10 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.label29 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.guna2ToggleSwitch10 = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.guna2PictureBox10 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.m10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox10)).BeginInit();
            this.SuspendLayout();
            // 
            // m10
            // 
            this.m10.BackColor = System.Drawing.Color.Transparent;
            this.m10.Controls.Add(this.label29);
            this.m10.Controls.Add(this.label25);
            this.m10.Controls.Add(this.label27);
            this.m10.Controls.Add(this.guna2ToggleSwitch10);
            this.m10.Controls.Add(this.guna2PictureBox10);
            this.m10.FillColor = System.Drawing.Color.White;
            this.m10.Location = new System.Drawing.Point(0, 0);
            this.m10.Name = "m10";
            this.m10.Radius = 12;
            this.m10.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(4)))), ((int)(((byte)(83)))));
            this.m10.ShadowDepth = 70;
            this.m10.Size = new System.Drawing.Size(150, 150);
            this.m10.TabIndex = 44;
            this.m10.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m10_MouseDown);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Montserrat SemiBold", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(81, 68);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(27, 14);
            this.label29.TabIndex = 17;
            this.label29.Text = "OFF";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Montserrat SemiBold", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(34, 114);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(75, 14);
            this.label25.TabIndex = 16;
            this.label25.Text = "Coffee Maker";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Montserrat SemiBold", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(82, 54);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(27, 14);
            this.label27.TabIndex = 2;
            this.label27.Text = "OFF";
            // 
            // guna2ToggleSwitch10
            // 
            this.guna2ToggleSwitch10.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(6)))), ((int)(((byte)(123)))));
            this.guna2ToggleSwitch10.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(6)))), ((int)(((byte)(123)))));
            this.guna2ToggleSwitch10.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.guna2ToggleSwitch10.CheckedState.InnerColor = System.Drawing.Color.White;
            this.guna2ToggleSwitch10.CheckedState.Parent = this.guna2ToggleSwitch10;
            this.guna2ToggleSwitch10.Location = new System.Drawing.Point(90, 22);
            this.guna2ToggleSwitch10.Name = "guna2ToggleSwitch10";
            this.guna2ToggleSwitch10.ShadowDecoration.Parent = this.guna2ToggleSwitch10;
            this.guna2ToggleSwitch10.Size = new System.Drawing.Size(42, 23);
            this.guna2ToggleSwitch10.TabIndex = 15;
            this.guna2ToggleSwitch10.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2ToggleSwitch10.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2ToggleSwitch10.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.guna2ToggleSwitch10.UncheckedState.InnerColor = System.Drawing.Color.White;
            this.guna2ToggleSwitch10.UncheckedState.Parent = this.guna2ToggleSwitch10;
            this.guna2ToggleSwitch10.CheckedChanged += new System.EventHandler(this.guna2ToggleSwitch10_CheckedChanged);
            // 
            // guna2PictureBox10
            // 
            this.guna2PictureBox10.FillColor = System.Drawing.Color.Blue;
            this.guna2PictureBox10.Image = global::SmartHome.Properties.Resources.cofee;
            this.guna2PictureBox10.Location = new System.Drawing.Point(7, 13);
            this.guna2PictureBox10.Name = "guna2PictureBox10";
            this.guna2PictureBox10.ShadowDecoration.Parent = this.guna2PictureBox10;
            this.guna2PictureBox10.Size = new System.Drawing.Size(65, 67);
            this.guna2PictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox10.TabIndex = 0;
            this.guna2PictureBox10.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Coffee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m10);
            this.Name = "Coffee";
            this.Load += new System.EventHandler(this.Coffee_Load);
            this.m10.ResumeLayout(false);
            this.m10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox10)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel m10;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label27;
        private Guna.UI2.WinForms.Guna2ToggleSwitch guna2ToggleSwitch10;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox10;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
    }
}
