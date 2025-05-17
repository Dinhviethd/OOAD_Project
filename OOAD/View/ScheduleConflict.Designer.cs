namespace OOAD
{
    partial class ScheduleConflict
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
            this.bCreate = new System.Windows.Forms.Button();
            this.bOverwrite = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // bCreate
            // 
            this.bCreate.Location = new System.Drawing.Point(357, 359);
            this.bCreate.Name = "bCreate";
            this.bCreate.Size = new System.Drawing.Size(200, 48);
            this.bCreate.TabIndex = 17;
            this.bCreate.Text = "Create";
            this.bCreate.UseVisualStyleBackColor = true;
            this.bCreate.Click += new System.EventHandler(this.bCreate_Click);
            // 
            // bOverwrite
            // 
            this.bOverwrite.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.bOverwrite.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.bOverwrite.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.bOverwrite.Location = new System.Drawing.Point(45, 359);
            this.bOverwrite.Name = "bOverwrite";
            this.bOverwrite.Size = new System.Drawing.Size(200, 48);
            this.bOverwrite.TabIndex = 16;
            this.bOverwrite.Text = "Overwrite";
            this.bOverwrite.UseVisualStyleBackColor = false;
            this.bOverwrite.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(40, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(517, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "There is alrealy an appointment scheduled for this time slot";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(291, 37);
            this.label1.TabIndex = 9;
            this.label1.Text = "Scheduling Conflict";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(45, 182);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(513, 117);
            this.panel1.TabIndex = 18;
            // 
            // ScheduleConflict
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 445);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bCreate);
            this.Controls.Add(this.bOverwrite);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ScheduleConflict";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bCreate;
        private System.Windows.Forms.Button bOverwrite;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}