namespace Student
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.exit_Button = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.submit_Button = new System.Windows.Forms.Button();
            this.stuAns_textBox = new System.Windows.Forms.TextBox();
            this.ques_TextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.exit_Button);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(593, 451);
            this.panel1.TabIndex = 0;
            // 
            // exit_Button
            // 
            this.exit_Button.Location = new System.Drawing.Point(444, 392);
            this.exit_Button.Name = "exit_Button";
            this.exit_Button.Size = new System.Drawing.Size(113, 30);
            this.exit_Button.TabIndex = 2;
            this.exit_Button.Text = "Exit";
            this.exit_Button.UseVisualStyleBackColor = true;
            this.exit_Button.Click += new System.EventHandler(this.exit_Button_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.submit_Button);
            this.groupBox1.Controls.Add(this.stuAns_textBox);
            this.groupBox1.Controls.Add(this.ques_TextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(16, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(562, 294);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Enter your answer and click SUBMIT";
            // 
            // submit_Button
            // 
            this.submit_Button.Location = new System.Drawing.Point(428, 184);
            this.submit_Button.Name = "submit_Button";
            this.submit_Button.Size = new System.Drawing.Size(113, 30);
            this.submit_Button.TabIndex = 2;
            this.submit_Button.Text = "Submit";
            this.submit_Button.UseVisualStyleBackColor = true;
            this.submit_Button.Click += new System.EventHandler(this.submit_Button_Click);
            // 
            // stuAns_textBox
            // 
            this.stuAns_textBox.Location = new System.Drawing.Point(208, 113);
            this.stuAns_textBox.Multiline = true;
            this.stuAns_textBox.Name = "stuAns_textBox";
            this.stuAns_textBox.Size = new System.Drawing.Size(333, 35);
            this.stuAns_textBox.TabIndex = 1;
            // 
            // ques_TextBox
            // 
            this.ques_TextBox.Location = new System.Drawing.Point(208, 46);
            this.ques_TextBox.Multiline = true;
            this.ques_TextBox.Name = "ques_TextBox";
            this.ques_TextBox.Size = new System.Drawing.Size(333, 35);
            this.ques_TextBox.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Your Answer:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Question:";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Highlight;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(15, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(563, 53);
            this.label1.TabIndex = 0;
            this.label1.Text = "Student";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 450);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Student";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button exit_Button;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button submit_Button;
        private System.Windows.Forms.TextBox stuAns_textBox;
        private System.Windows.Forms.TextBox ques_TextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}

