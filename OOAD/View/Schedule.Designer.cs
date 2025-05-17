namespace OOAD.View
{
    partial class Schedule
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
            System.Windows.Forms.Button ok;
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.reminder = new System.Windows.Forms.CheckBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.location1 = new System.Windows.Forms.TextBox();
            this.title1 = new System.Windows.Forms.TextBox();
            this.groupmeeting = new System.Windows.Forms.CheckBox();
            this.start = new System.Windows.Forms.Label();
            this.end = new System.Windows.Forms.Label();
            this.location = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.Label();
            ok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ok
            // 
            ok.BackColor = System.Drawing.SystemColors.Highlight;
            ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ok.ForeColor = System.Drawing.SystemColors.Control;
            ok.Location = new System.Drawing.Point(333, 558);
            ok.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            ok.Name = "ok";
            ok.Size = new System.Drawing.Size(102, 52);
            ok.TabIndex = 33;
            ok.Text = "OK";
            ok.UseVisualStyleBackColor = false;
            ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(78, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(293, 38);
            this.label2.TabIndex = 42;
            this.label2.Text = "Schedule Meeting";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(82, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(315, 26);
            this.label1.TabIndex = 41;
            this.label1.Text = "Fill in the meeting details below";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(497, 558);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 52);
            this.button1.TabIndex = 40;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // reminder
            // 
            this.reminder.AutoSize = true;
            this.reminder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reminder.Location = new System.Drawing.Point(88, 529);
            this.reminder.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.reminder.Name = "reminder";
            this.reminder.Size = new System.Drawing.Size(130, 29);
            this.reminder.TabIndex = 39;
            this.reminder.Text = "Reminder";
            this.reminder.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker2.Location = new System.Drawing.Point(496, 422);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.ShowUpDown = true;
            this.dateTimePicker2.Size = new System.Drawing.Size(384, 35);
            this.dateTimePicker2.TabIndex = 38;
            this.dateTimePicker2.Value = new System.DateTime(2025, 5, 14, 0, 0, 0, 0);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker1.Location = new System.Drawing.Point(85, 422);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(378, 35);
            this.dateTimePicker1.TabIndex = 37;
            // 
            // location1
            // 
            this.location1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.location1.Location = new System.Drawing.Point(85, 306);
            this.location1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.location1.Name = "location1";
            this.location1.Size = new System.Drawing.Size(796, 39);
            this.location1.TabIndex = 35;
            // 
            // title1
            // 
            this.title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title1.Location = new System.Drawing.Point(85, 203);
            this.title1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.title1.Name = "title1";
            this.title1.Size = new System.Drawing.Size(796, 39);
            this.title1.TabIndex = 36;
            // 
            // groupmeeting
            // 
            this.groupmeeting.AutoSize = true;
            this.groupmeeting.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupmeeting.Location = new System.Drawing.Point(88, 492);
            this.groupmeeting.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupmeeting.Name = "groupmeeting";
            this.groupmeeting.Size = new System.Drawing.Size(179, 29);
            this.groupmeeting.TabIndex = 34;
            this.groupmeeting.Text = "Group meeting";
            this.groupmeeting.UseVisualStyleBackColor = true;
            // 
            // start
            // 
            this.start.AutoSize = true;
            this.start.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start.Location = new System.Drawing.Point(82, 387);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(112, 26);
            this.start.TabIndex = 32;
            this.start.Text = "Start Time";
            // 
            // end
            // 
            this.end.AutoSize = true;
            this.end.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.end.Location = new System.Drawing.Point(491, 387);
            this.end.Name = "end";
            this.end.Size = new System.Drawing.Size(105, 26);
            this.end.TabIndex = 31;
            this.end.Text = "End Time";
            // 
            // location
            // 
            this.location.AutoSize = true;
            this.location.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.location.Location = new System.Drawing.Point(83, 262);
            this.location.Name = "location";
            this.location.Size = new System.Drawing.Size(94, 26);
            this.location.TabIndex = 30;
            this.location.Text = "Location";
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(82, 153);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(135, 26);
            this.title.TabIndex = 29;
            this.title.Text = "Meeting Title";
            // 
            // Schedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 639);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.reminder);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.location1);
            this.Controls.Add(this.title1);
            this.Controls.Add(this.groupmeeting);
            this.Controls.Add(ok);
            this.Controls.Add(this.start);
            this.Controls.Add(this.end);
            this.Controls.Add(this.location);
            this.Controls.Add(this.title);
            this.Name = "Schedule";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Schedule_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox reminder;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox location1;
        private System.Windows.Forms.TextBox title1;
        private System.Windows.Forms.CheckBox groupmeeting;
        private System.Windows.Forms.Label start;
        private System.Windows.Forms.Label end;
        private System.Windows.Forms.Label location;
        private System.Windows.Forms.Label title;
    }
}