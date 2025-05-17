namespace OOAD.View
{
    partial class Layout
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
            this.bLog = new System.Windows.Forms.Button();
            this.bCal = new System.Windows.Forms.Button();
            this.bDash = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bLog
            // 
            this.bLog.BackColor = System.Drawing.Color.Azure;
            this.bLog.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bLog.ForeColor = System.Drawing.SystemColors.Highlight;
            this.bLog.Location = new System.Drawing.Point(3, 437);
            this.bLog.Name = "bLog";
            this.bLog.Size = new System.Drawing.Size(300, 66);
            this.bLog.TabIndex = 3;
            this.bLog.Text = "Logout";
            this.bLog.UseVisualStyleBackColor = false;
            this.bLog.Click += new System.EventHandler(this.bLog_Click);
            // 
            // bCal
            // 
            this.bCal.BackColor = System.Drawing.Color.Azure;
            this.bCal.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bCal.ForeColor = System.Drawing.SystemColors.Highlight;
            this.bCal.Location = new System.Drawing.Point(3, 341);
            this.bCal.Name = "bCal";
            this.bCal.Size = new System.Drawing.Size(300, 66);
            this.bCal.TabIndex = 4;
            this.bCal.Text = "Calendar";
            this.bCal.UseVisualStyleBackColor = false;
            this.bCal.Click += new System.EventHandler(this.bCal_Click);
            // 
            // bDash
            // 
            this.bDash.BackColor = System.Drawing.Color.Azure;
            this.bDash.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bDash.ForeColor = System.Drawing.SystemColors.Highlight;
            this.bDash.Location = new System.Drawing.Point(3, 247);
            this.bDash.Name = "bDash";
            this.bDash.Size = new System.Drawing.Size(300, 66);
            this.bDash.TabIndex = 6;
            this.bDash.Text = "Dashboard";
            this.bDash.UseVisualStyleBackColor = false;
            this.bDash.Click += new System.EventHandler(this.bDash_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(21, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Hello,";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.bLog);
            this.panel1.Controls.Add(this.bDash);
            this.panel1.Controls.Add(this.bCal);
            this.panel1.Location = new System.Drawing.Point(2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(306, 832);
            this.panel1.TabIndex = 7;
            // 
            // contentPanel
            // 
            this.contentPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.contentPanel.Location = new System.Drawing.Point(314, 1);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(1206, 832);
            this.contentPanel.TabIndex = 8;
            // 
            // Layout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1521, 834);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.panel1);
            this.Name = "Layout";
            this.Text = "Layout";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bLog;
        private System.Windows.Forms.Button bCal;
        private System.Windows.Forms.Button bDash;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel contentPanel;
    }
}