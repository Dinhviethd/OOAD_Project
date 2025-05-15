namespace OOAD
{
    partial class MeetingConflict
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.bJoin = new System.Windows.Forms.Button();
            this.bCreate = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(406, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Similar Group Meeting Found";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(98, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(490, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "We found an existing group meeting with similar details:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(98, 264);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(481, 25);
            this.label6.TabIndex = 3;
            this.label6.Text = "Would you like to join this meeting or create a new one";
            // 
            // bJoin
            // 
            this.bJoin.BackColor = System.Drawing.SystemColors.ControlLight;
            this.bJoin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.bJoin.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bJoin.Location = new System.Drawing.Point(102, 307);
            this.bJoin.Name = "bJoin";
            this.bJoin.Size = new System.Drawing.Size(277, 57);
            this.bJoin.TabIndex = 4;
            this.bJoin.Text = "Join";
            this.bJoin.UseVisualStyleBackColor = false;
            this.bJoin.Click += new System.EventHandler(this.bJoin_Click);
            // 
            // bCreate
            // 
            this.bCreate.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.bCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.bCreate.ForeColor = System.Drawing.SystemColors.Highlight;
            this.bCreate.Location = new System.Drawing.Point(390, 307);
            this.bCreate.Name = "bCreate";
            this.bCreate.Size = new System.Drawing.Size(277, 57);
            this.bCreate.TabIndex = 4;
            this.bCreate.Text = "Cancel";
            this.bCreate.UseVisualStyleBackColor = false;
            this.bCreate.Click += new System.EventHandler(this.bCreate_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(103, 118);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(513, 117);
            this.panel1.TabIndex = 19;
            // 
            // MeetingConflict
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(753, 403);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bCreate);
            this.Controls.Add(this.bJoin);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MeetingConflict";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MeetingConflict_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bJoin;
        private System.Windows.Forms.Button bCreate;
        private System.Windows.Forms.Panel panel1;
    }
}

