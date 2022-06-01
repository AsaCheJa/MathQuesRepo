namespace ServerApp
{
    partial class ServerForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Send_Button = new System.Windows.Forms.Button();
            this.SystemMsg_TextBox = new System.Windows.Forms.TextBox();
            this.Send_TextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Receive_TextBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server";
            this.label1.UseWaitCursor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Send_Button);
            this.groupBox1.Controls.Add(this.SystemMsg_TextBox);
            this.groupBox1.Controls.Add(this.Send_TextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(22, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 300);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // Send_Button
            // 
            this.Send_Button.Location = new System.Drawing.Point(13, 154);
            this.Send_Button.Name = "Send_Button";
            this.Send_Button.Size = new System.Drawing.Size(75, 23);
            this.Send_Button.TabIndex = 5;
            this.Send_Button.Text = "SEND";
            this.Send_Button.UseVisualStyleBackColor = true;
            this.Send_Button.Click += new System.EventHandler(this.Send_Button_Click);
            // 
            // SystemMsg_TextBox
            // 
            this.SystemMsg_TextBox.Location = new System.Drawing.Point(11, 208);
            this.SystemMsg_TextBox.Multiline = true;
            this.SystemMsg_TextBox.Name = "SystemMsg_TextBox";
            this.SystemMsg_TextBox.Size = new System.Drawing.Size(245, 76);
            this.SystemMsg_TextBox.TabIndex = 4;
            // 
            // Send_TextBox
            // 
            this.Send_TextBox.Location = new System.Drawing.Point(10, 37);
            this.Send_TextBox.Multiline = true;
            this.Send_TextBox.Name = "Send_TextBox";
            this.Send_TextBox.Size = new System.Drawing.Size(246, 100);
            this.Send_TextBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "System messages:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Enter your message here:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Receive_TextBox);
            this.groupBox2.Location = new System.Drawing.Point(315, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(255, 300);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // Receive_TextBox
            // 
            this.Receive_TextBox.Location = new System.Drawing.Point(16, 18);
            this.Receive_TextBox.Multiline = true;
            this.Receive_TextBox.Name = "Receive_TextBox";
            this.Receive_TextBox.Size = new System.Drawing.Size(228, 266);
            this.Receive_TextBox.TabIndex = 0;
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 353);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "ServerForm";
            this.Text = "Server";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ServerForm_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Send_Button;
        private System.Windows.Forms.TextBox SystemMsg_TextBox;
        private System.Windows.Forms.TextBox Send_TextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox Receive_TextBox;
    }
}

