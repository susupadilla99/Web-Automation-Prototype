namespace Web_Automation_Prototype
{
    partial class InputForm
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
            this.submitBtn = new System.Windows.Forms.Button();
            this.sessionInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.yearInput = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.titleInput = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.contentInput = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // submitBtn
            // 
            this.submitBtn.Location = new System.Drawing.Point(360, 561);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(136, 45);
            this.submitBtn.TabIndex = 0;
            this.submitBtn.Text = "Run";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // sessionInput
            // 
            this.sessionInput.Location = new System.Drawing.Point(105, 89);
            this.sessionInput.Name = "sessionInput";
            this.sessionInput.Size = new System.Drawing.Size(109, 26);
            this.sessionInput.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Session:";
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(110, 9);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(653, 46);
            this.title.TabIndex = 3;
            this.title.Text = "iLearn Posting Automation Program";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(258, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Year:";
            // 
            // yearInput
            // 
            this.yearInput.Location = new System.Drawing.Point(311, 89);
            this.yearInput.Name = "yearInput";
            this.yearInput.Size = new System.Drawing.Size(147, 26);
            this.yearInput.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Post Title:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // titleInput
            // 
            this.titleInput.Location = new System.Drawing.Point(33, 183);
            this.titleInput.Name = "titleInput";
            this.titleInput.Size = new System.Drawing.Size(805, 26);
            this.titleInput.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 232);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Post Content:";
            // 
            // contentInput
            // 
            this.contentInput.Location = new System.Drawing.Point(33, 264);
            this.contentInput.Name = "contentInput";
            this.contentInput.Size = new System.Drawing.Size(805, 281);
            this.contentInput.TabIndex = 10;
            this.contentInput.Text = "";
            // 
            // InputForm
            // 
            this.AcceptButton = this.submitBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 630);
            this.Controls.Add(this.contentInput);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.titleInput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.yearInput);
            this.Controls.Add(this.title);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sessionInput);
            this.Controls.Add(this.submitBtn);
            this.Name = "InputForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.TextBox sessionInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox yearInput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox titleInput;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox contentInput;
    }
}