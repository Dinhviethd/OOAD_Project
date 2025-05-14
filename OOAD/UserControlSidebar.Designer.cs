namespace OOAD
{
    partial class UserControlSidebar
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
            this.bDashboard = new System.Windows.Forms.Button();
            this.bCalendar = new System.Windows.Forms.Button();
            this.bLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bDashboard
            // 
            this.bDashboard.Font = new System.Drawing.Font("Yu Gothic", 12F);
            this.bDashboard.Location = new System.Drawing.Point(3, 259);
            this.bDashboard.Name = "bDashboard";
            this.bDashboard.Size = new System.Drawing.Size(179, 45);
            this.bDashboard.TabIndex = 0;
            this.bDashboard.Text = "Dashboard";
            this.bDashboard.UseVisualStyleBackColor = true;
            this.bDashboard.Click += new System.EventHandler(this.bDashboard_Click);
            // 
            // bCalendar
            // 
            this.bCalendar.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bCalendar.Location = new System.Drawing.Point(3, 329);
            this.bCalendar.Name = "bCalendar";
            this.bCalendar.Size = new System.Drawing.Size(179, 45);
            this.bCalendar.TabIndex = 0;
            this.bCalendar.Text = "Calendar";
            this.bCalendar.UseVisualStyleBackColor = true;
            this.bCalendar.Click += new System.EventHandler(this.bCalendar_Click);
            // 
            // bLogout
            // 
            this.bLogout.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bLogout.Location = new System.Drawing.Point(3, 399);
            this.bLogout.Name = "bLogout";
            this.bLogout.Size = new System.Drawing.Size(179, 45);
            this.bLogout.TabIndex = 0;
            this.bLogout.Text = "Logout";
            this.bLogout.UseVisualStyleBackColor = true;
            // 
            // UserControlSidebar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bLogout);
            this.Controls.Add(this.bCalendar);
            this.Controls.Add(this.bDashboard);
            this.Name = "UserControlSidebar";
            this.Size = new System.Drawing.Size(185, 811);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bDashboard;
        private System.Windows.Forms.Button bCalendar;
        private System.Windows.Forms.Button bLogout;
    }
}
