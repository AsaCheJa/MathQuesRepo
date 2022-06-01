namespace Teacher
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
            this.label1 = new System.Windows.Forms.Label();
            this.insertion_Button = new System.Windows.Forms.Button();
            this.selection_Button = new System.Windows.Forms.Button();
            this.bubble_Button = new System.Windows.Forms.Button();
            this.send_Button = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.postOrderDisp = new System.Windows.Forms.Button();
            this.inOrderDisp = new System.Windows.Forms.Button();
            this.postOrderSave = new System.Windows.Forms.Button();
            this.preOrderSave = new System.Windows.Forms.Button();
            this.inOrderSave = new System.Windows.Forms.Button();
            this.preOrderDisp = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.binaryTree_TextBox = new System.Windows.Forms.TextBox();
            this.search_Button = new System.Windows.Forms.Button();
            this.search_TextBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.linkedList_TextBox = new System.Windows.Forms.TextBox();
            this.linkedList_Button = new System.Windows.Forms.Button();
            this.exit_Button = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.array_DataGridView = new System.Windows.Forms.DataGridView();
            this.LeftOp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MathOp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RightOp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Equal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Answer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.mathOp_ComboBox = new System.Windows.Forms.ComboBox();
            this.answer_TextBox = new System.Windows.Forms.TextBox();
            this.rightOp_TextBox = new System.Windows.Forms.TextBox();
            this.leftOp_TextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.array_DataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.insertion_Button);
            this.panel1.Controls.Add(this.selection_Button);
            this.panel1.Controls.Add(this.bubble_Button);
            this.panel1.Controls.Add(this.send_Button);
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(1, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(943, 709);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Highlight;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(12, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(908, 61);
            this.label1.TabIndex = 9;
            this.label1.Text = "Instructor";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // insertion_Button
            // 
            this.insertion_Button.Location = new System.Drawing.Point(762, 283);
            this.insertion_Button.Name = "insertion_Button";
            this.insertion_Button.Size = new System.Drawing.Size(157, 30);
            this.insertion_Button.TabIndex = 8;
            this.insertion_Button.Text = "Insertion Sort  (asc)";
            this.insertion_Button.UseVisualStyleBackColor = true;
            this.insertion_Button.Click += new System.EventHandler(this.insertion_Button_Click);
            // 
            // selection_Button
            // 
            this.selection_Button.Location = new System.Drawing.Point(568, 283);
            this.selection_Button.Name = "selection_Button";
            this.selection_Button.Size = new System.Drawing.Size(157, 30);
            this.selection_Button.TabIndex = 8;
            this.selection_Button.Text = "Selection Sort  (desc)";
            this.selection_Button.UseVisualStyleBackColor = true;
            this.selection_Button.Click += new System.EventHandler(this.selection_Button_Click);
            // 
            // bubble_Button
            // 
            this.bubble_Button.Location = new System.Drawing.Point(374, 283);
            this.bubble_Button.Name = "bubble_Button";
            this.bubble_Button.Size = new System.Drawing.Size(157, 30);
            this.bubble_Button.TabIndex = 8;
            this.bubble_Button.Text = "Bubble Sort  (asc)";
            this.bubble_Button.UseVisualStyleBackColor = true;
            this.bubble_Button.Click += new System.EventHandler(this.bubble_Button_Click);
            // 
            // send_Button
            // 
            this.send_Button.Location = new System.Drawing.Point(174, 283);
            this.send_Button.Name = "send_Button";
            this.send_Button.Size = new System.Drawing.Size(129, 30);
            this.send_Button.TabIndex = 8;
            this.send_Button.Text = "Send";
            this.send_Button.UseVisualStyleBackColor = true;
            this.send_Button.Click += new System.EventHandler(this.send_Button_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.postOrderDisp);
            this.groupBox5.Controls.Add(this.inOrderDisp);
            this.groupBox5.Controls.Add(this.postOrderSave);
            this.groupBox5.Controls.Add(this.preOrderSave);
            this.groupBox5.Controls.Add(this.inOrderSave);
            this.groupBox5.Controls.Add(this.preOrderDisp);
            this.groupBox5.Location = new System.Drawing.Point(22, 596);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(910, 103);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.Highlight;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.Control;
            this.label8.Location = new System.Drawing.Point(703, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(188, 35);
            this.label8.TabIndex = 1;
            this.label8.Text = "Post-Order";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.Highlight;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Control;
            this.label7.Location = new System.Drawing.Point(355, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(188, 35);
            this.label7.TabIndex = 1;
            this.label7.Text = "In-Order";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.Highlight;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(7, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(188, 35);
            this.label6.TabIndex = 1;
            this.label6.Text = "Pre-Order";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // postOrderDisp
            // 
            this.postOrderDisp.Location = new System.Drawing.Point(703, 68);
            this.postOrderDisp.Name = "postOrderDisp";
            this.postOrderDisp.Size = new System.Drawing.Size(91, 26);
            this.postOrderDisp.TabIndex = 0;
            this.postOrderDisp.Text = "Display";
            this.postOrderDisp.UseVisualStyleBackColor = true;
            this.postOrderDisp.Click += new System.EventHandler(this.postOrderDisp_Click);
            // 
            // inOrderDisp
            // 
            this.inOrderDisp.Location = new System.Drawing.Point(355, 68);
            this.inOrderDisp.Name = "inOrderDisp";
            this.inOrderDisp.Size = new System.Drawing.Size(91, 26);
            this.inOrderDisp.TabIndex = 0;
            this.inOrderDisp.Text = "Display";
            this.inOrderDisp.UseVisualStyleBackColor = true;
            this.inOrderDisp.Click += new System.EventHandler(this.inOrderDisp_Click);
            // 
            // postOrderSave
            // 
            this.postOrderSave.Location = new System.Drawing.Point(800, 68);
            this.postOrderSave.Name = "postOrderSave";
            this.postOrderSave.Size = new System.Drawing.Size(91, 26);
            this.postOrderSave.TabIndex = 0;
            this.postOrderSave.Text = "Save";
            this.postOrderSave.UseVisualStyleBackColor = true;
            this.postOrderSave.Click += new System.EventHandler(this.postOrderSave_Click);
            // 
            // preOrderSave
            // 
            this.preOrderSave.Location = new System.Drawing.Point(104, 68);
            this.preOrderSave.Name = "preOrderSave";
            this.preOrderSave.Size = new System.Drawing.Size(91, 26);
            this.preOrderSave.TabIndex = 0;
            this.preOrderSave.Text = "Save";
            this.preOrderSave.UseVisualStyleBackColor = true;
            this.preOrderSave.Click += new System.EventHandler(this.preOrderSave_Click);
            // 
            // inOrderSave
            // 
            this.inOrderSave.Location = new System.Drawing.Point(452, 68);
            this.inOrderSave.Name = "inOrderSave";
            this.inOrderSave.Size = new System.Drawing.Size(91, 26);
            this.inOrderSave.TabIndex = 0;
            this.inOrderSave.Text = "Save";
            this.inOrderSave.UseVisualStyleBackColor = true;
            this.inOrderSave.Click += new System.EventHandler(this.inOrderSave_Click);
            // 
            // preOrderDisp
            // 
            this.preOrderDisp.Location = new System.Drawing.Point(7, 68);
            this.preOrderDisp.Name = "preOrderDisp";
            this.preOrderDisp.Size = new System.Drawing.Size(91, 26);
            this.preOrderDisp.TabIndex = 0;
            this.preOrderDisp.Text = "Display";
            this.preOrderDisp.UseVisualStyleBackColor = true;
            this.preOrderDisp.Click += new System.EventHandler(this.preOrderDisp_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.binaryTree_TextBox);
            this.groupBox4.Controls.Add(this.search_Button);
            this.groupBox4.Controls.Add(this.search_TextBox);
            this.groupBox4.Location = new System.Drawing.Point(23, 468);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(910, 122);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Binary Tree (of all questions - added in the order asked)";
            // 
            // binaryTree_TextBox
            // 
            this.binaryTree_TextBox.Location = new System.Drawing.Point(7, 36);
            this.binaryTree_TextBox.Multiline = true;
            this.binaryTree_TextBox.Name = "binaryTree_TextBox";
            this.binaryTree_TextBox.Size = new System.Drawing.Size(891, 80);
            this.binaryTree_TextBox.TabIndex = 9;
            // 
            // search_Button
            // 
            this.search_Button.Location = new System.Drawing.Point(740, 0);
            this.search_Button.Name = "search_Button";
            this.search_Button.Size = new System.Drawing.Size(157, 30);
            this.search_Button.TabIndex = 8;
            this.search_Button.Text = "Search";
            this.search_Button.UseVisualStyleBackColor = true;
            this.search_Button.Click += new System.EventHandler(this.search_Button_Click);
            // 
            // search_TextBox
            // 
            this.search_TextBox.Location = new System.Drawing.Point(547, 0);
            this.search_TextBox.Multiline = true;
            this.search_TextBox.Name = "search_TextBox";
            this.search_TextBox.Size = new System.Drawing.Size(157, 30);
            this.search_TextBox.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.linkedList_TextBox);
            this.groupBox3.Controls.Add(this.linkedList_Button);
            this.groupBox3.Controls.Add(this.exit_Button);
            this.groupBox3.Location = new System.Drawing.Point(23, 333);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(910, 122);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Linked List (of all incorrectly answered questions)";
            // 
            // linkedList_TextBox
            // 
            this.linkedList_TextBox.Location = new System.Drawing.Point(6, 36);
            this.linkedList_TextBox.Multiline = true;
            this.linkedList_TextBox.Name = "linkedList_TextBox";
            this.linkedList_TextBox.Size = new System.Drawing.Size(891, 80);
            this.linkedList_TextBox.TabIndex = 9;
            // 
            // linkedList_Button
            // 
            this.linkedList_Button.Location = new System.Drawing.Point(546, 0);
            this.linkedList_Button.Name = "linkedList_Button";
            this.linkedList_Button.Size = new System.Drawing.Size(157, 30);
            this.linkedList_Button.TabIndex = 8;
            this.linkedList_Button.Text = "Display Linked List";
            this.linkedList_Button.UseVisualStyleBackColor = true;
            this.linkedList_Button.Click += new System.EventHandler(this.linkedList_Button_Click);
            // 
            // exit_Button
            // 
            this.exit_Button.Location = new System.Drawing.Point(739, 0);
            this.exit_Button.Name = "exit_Button";
            this.exit_Button.Size = new System.Drawing.Size(157, 30);
            this.exit_Button.TabIndex = 8;
            this.exit_Button.Text = "Exit";
            this.exit_Button.UseVisualStyleBackColor = true;
            this.exit_Button.Click += new System.EventHandler(this.exit_Button_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.array_DataGridView);
            this.groupBox2.Location = new System.Drawing.Point(374, 85);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(558, 186);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Array of questions asked";
            // 
            // array_DataGridView
            // 
            this.array_DataGridView.AllowUserToDeleteRows = false;
            this.array_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.array_DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LeftOp,
            this.MathOp,
            this.RightOp,
            this.Equal,
            this.Answer});
            this.array_DataGridView.Location = new System.Drawing.Point(6, 21);
            this.array_DataGridView.Name = "array_DataGridView";
            this.array_DataGridView.ReadOnly = true;
            this.array_DataGridView.RowHeadersWidth = 51;
            this.array_DataGridView.RowTemplate.Height = 24;
            this.array_DataGridView.Size = new System.Drawing.Size(534, 150);
            this.array_DataGridView.TabIndex = 1;
            // 
            // LeftOp
            // 
            this.LeftOp.HeaderText = "Number 1";
            this.LeftOp.MinimumWidth = 6;
            this.LeftOp.Name = "LeftOp";
            this.LeftOp.ReadOnly = true;
            this.LeftOp.Width = 95;
            // 
            // MathOp
            // 
            this.MathOp.HeaderText = "Math";
            this.MathOp.MinimumWidth = 6;
            this.MathOp.Name = "MathOp";
            this.MathOp.ReadOnly = true;
            this.MathOp.Width = 55;
            // 
            // RightOp
            // 
            this.RightOp.HeaderText = "Number 2";
            this.RightOp.MinimumWidth = 6;
            this.RightOp.Name = "RightOp";
            this.RightOp.ReadOnly = true;
            this.RightOp.Width = 95;
            // 
            // Equal
            // 
            this.Equal.HeaderText = "=";
            this.Equal.MinimumWidth = 6;
            this.Equal.Name = "Equal";
            this.Equal.ReadOnly = true;
            this.Equal.Width = 55;
            // 
            // Answer
            // 
            this.Answer.HeaderText = "Answer";
            this.Answer.MinimumWidth = 6;
            this.Answer.Name = "Answer";
            this.Answer.ReadOnly = true;
            this.Answer.Width = 95;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mathOp_ComboBox);
            this.groupBox1.Controls.Add(this.answer_TextBox);
            this.groupBox1.Controls.Add(this.rightOp_TextBox);
            this.groupBox1.Controls.Add(this.leftOp_TextBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(22, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(304, 192);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Enter question, then click SEND";
            // 
            // mathOp_ComboBox
            // 
            this.mathOp_ComboBox.FormattingEnabled = true;
            this.mathOp_ComboBox.ItemHeight = 16;
            this.mathOp_ComboBox.Items.AddRange(new object[] {
            "+",
            "-",
            "*",
            "/"});
            this.mathOp_ComboBox.Location = new System.Drawing.Point(152, 68);
            this.mathOp_ComboBox.Name = "mathOp_ComboBox";
            this.mathOp_ComboBox.Size = new System.Drawing.Size(129, 24);
            this.mathOp_ComboBox.TabIndex = 2;
            // 
            // answer_TextBox
            // 
            this.answer_TextBox.Location = new System.Drawing.Point(152, 147);
            this.answer_TextBox.Multiline = true;
            this.answer_TextBox.Name = "answer_TextBox";
            this.answer_TextBox.Size = new System.Drawing.Size(129, 34);
            this.answer_TextBox.TabIndex = 1;
            // 
            // rightOp_TextBox
            // 
            this.rightOp_TextBox.Location = new System.Drawing.Point(152, 105);
            this.rightOp_TextBox.Multiline = true;
            this.rightOp_TextBox.Name = "rightOp_TextBox";
            this.rightOp_TextBox.Size = new System.Drawing.Size(129, 34);
            this.rightOp_TextBox.TabIndex = 1;
            // 
            // leftOp_TextBox
            // 
            this.leftOp_TextBox.Location = new System.Drawing.Point(152, 21);
            this.leftOp_TextBox.Multiline = true;
            this.leftOp_TextBox.Name = "leftOp_TextBox";
            this.leftOp_TextBox.Size = new System.Drawing.Size(129, 34);
            this.leftOp_TextBox.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Answer:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Second number:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Operator:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "First number:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 714);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Instructor";
            this.panel1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.array_DataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView array_DataGridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button insertion_Button;
        private System.Windows.Forms.Button selection_Button;
        private System.Windows.Forms.Button bubble_Button;
        private System.Windows.Forms.Button send_Button;
        private System.Windows.Forms.Button postOrderDisp;
        private System.Windows.Forms.Button inOrderDisp;
        private System.Windows.Forms.Button inOrderSave;
        private System.Windows.Forms.Button preOrderDisp;
        private System.Windows.Forms.Button search_Button;
        private System.Windows.Forms.TextBox answer_TextBox;
        private System.Windows.Forms.TextBox rightOp_TextBox;
        private System.Windows.Forms.TextBox leftOp_TextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button postOrderSave;
        private System.Windows.Forms.Button preOrderSave;
        private System.Windows.Forms.TextBox search_TextBox;
        private System.Windows.Forms.Button linkedList_Button;
        private System.Windows.Forms.Button exit_Button;
        private System.Windows.Forms.TextBox binaryTree_TextBox;
        private System.Windows.Forms.TextBox linkedList_TextBox;
        private System.Windows.Forms.ComboBox mathOp_ComboBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn LeftOp;
        private System.Windows.Forms.DataGridViewTextBoxColumn MathOp;
        private System.Windows.Forms.DataGridViewTextBoxColumn RightOp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Equal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Answer;
    }
}

