namespace SmartHome.MachineControlers
{
    partial class SimpleMachine
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
            this.m4 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.label16 = new System.Windows.Forms.Label();
            this.lampe_lab = new System.Windows.Forms.Label();
            this.guna2ToggleSwitch5 = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.lampe = new Guna.UI2.WinForms.Guna2PictureBox();
            this.m4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lampe)).BeginInit();
            this.SuspendLayout();
            // 
            // m4
            // 
            this.m4.BackColor = System.Drawing.Color.Transparent;
            this.m4.Controls.Add(this.label16);
            this.m4.Controls.Add(this.lampe_lab);
            this.m4.Controls.Add(this.guna2ToggleSwitch5);
            this.m4.Controls.Add(this.lampe);
            this.m4.FillColor = System.Drawing.Color.White;
            this.m4.Location = new System.Drawing.Point(3, 4);
            this.m4.Name = "m4";
            this.m4.Radius = 12;
            this.m4.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(4)))), ((int)(((byte)(83)))));
            this.m4.ShadowDepth = 70;
            this.m4.Size = new System.Drawing.Size(147, 133);
            this.m4.TabIndex = 34;
            this.m4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m4_MouseDown);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Montserrat SemiBold", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(18, 109);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(0, 14);
            this.label16.TabIndex = 16;
            // 
            // lampe_lab
            // 
            this.lampe_lab.AutoSize = true;
            this.lampe_lab.Font = new System.Drawing.Font("Montserrat SemiBold", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lampe_lab.Location = new System.Drawing.Point(97, 54);
            this.lampe_lab.Name = "lampe_lab";
            this.lampe_lab.Size = new System.Drawing.Size(27, 14);
            this.lampe_lab.TabIndex = 2;
            this.lampe_lab.Text = "OFF";
            // 
            // guna2ToggleSwitch5
            // 
            this.guna2ToggleSwitch5.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(6)))), ((int)(((byte)(123)))));
            this.guna2ToggleSwitch5.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(6)))), ((int)(((byte)(123)))));
            this.guna2ToggleSwitch5.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.guna2ToggleSwitch5.CheckedState.InnerColor = System.Drawing.Color.White;
            this.guna2ToggleSwitch5.CheckedState.Parent = this.guna2ToggleSwitch5;
            this.guna2ToggleSwitch5.Location = new System.Drawing.Point(90, 22);
            this.guna2ToggleSwitch5.Name = "guna2ToggleSwitch5";
            this.guna2ToggleSwitch5.ShadowDecoration.Parent = this.guna2ToggleSwitch5;
            this.guna2ToggleSwitch5.Size = new System.Drawing.Size(42, 23);
            this.guna2ToggleSwitch5.TabIndex = 15;
            this.guna2ToggleSwitch5.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2ToggleSwitch5.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2ToggleSwitch5.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.guna2ToggleSwitch5.UncheckedState.InnerColor = System.Drawing.Color.White;
            this.guna2ToggleSwitch5.UncheckedState.Parent = this.guna2ToggleSwitch5;
            this.guna2ToggleSwitch5.CheckedChanged += new System.EventHandler(this.guna2ToggleSwitch5_CheckedChanged);
            // 
            // lampe
            // 
            this.lampe.FillColor = System.Drawing.Color.Blue;
            this.lampe.Image = global::SmartHome.Properties.Resources.lampe;
            this.lampe.Location = new System.Drawing.Point(21, 20);
            this.lampe.Name = "lampe";
            this.lampe.ShadowDecoration.Parent = this.lampe;
            this.lampe.Size = new System.Drawing.Size(47, 48);
            this.lampe.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.lampe.TabIndex = 0;
            this.lampe.TabStop = false;
            // 
            // SimpleMachine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m4);
            this.Name = "SimpleMachine";
            this.Size = new System.Drawing.Size(154, 141);
            this.Load += new System.EventHandler(this.SimpleMachine_Load);
            this.m4.ResumeLayout(false);
            this.m4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lampe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel m4;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lampe_lab;
        private Guna.UI2.WinForms.Guna2ToggleSwitch guna2ToggleSwitch5;
        private Guna.UI2.WinForms.Guna2PictureBox lampe;
    }
}
