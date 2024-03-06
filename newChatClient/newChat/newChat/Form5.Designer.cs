namespace newChat
{
    partial class Form5
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
            this.name = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nametext = new System.Windows.Forms.TextBox();
            this.birthtext = new System.Windows.Forms.TextBox();
            this.find_id_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pwidtext = new System.Windows.Forms.TextBox();
            this.pwnametext = new System.Windows.Forms.TextBox();
            this.pwbirthtext = new System.Windows.Forms.TextBox();
            this.find_pw_btn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
            this.name.Location = new System.Drawing.Point(25, 60);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(44, 23);
            this.name.TabIndex = 0;
            this.name.Text = "이름";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
            this.label2.Location = new System.Drawing.Point(25, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "생년월일(8자리)";
            // 
            // nametext
            // 
            this.nametext.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nametext.Location = new System.Drawing.Point(29, 86);
            this.nametext.Name = "nametext";
            this.nametext.Size = new System.Drawing.Size(216, 30);
            this.nametext.TabIndex = 2;
            // 
            // birthtext
            // 
            this.birthtext.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.birthtext.Location = new System.Drawing.Point(29, 157);
            this.birthtext.Name = "birthtext";
            this.birthtext.Size = new System.Drawing.Size(216, 30);
            this.birthtext.TabIndex = 3;
            // 
            // find_id_btn
            // 
            this.find_id_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(100)))), ((int)(((byte)(254)))));
            this.find_id_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.find_id_btn.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.find_id_btn.ForeColor = System.Drawing.Color.White;
            this.find_id_btn.Location = new System.Drawing.Point(29, 207);
            this.find_id_btn.Name = "find_id_btn";
            this.find_id_btn.Size = new System.Drawing.Size(216, 35);
            this.find_id_btn.TabIndex = 4;
            this.find_id_btn.Text = "ID찾기";
            this.find_id_btn.UseVisualStyleBackColor = false;
            this.find_id_btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(100)))), ((int)(((byte)(254)))));
            this.label1.Location = new System.Drawing.Point(108, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 28);
            this.label1.TabIndex = 5;
            this.label1.Text = "ID찾기";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(100)))), ((int)(((byte)(254)))));
            this.label3.Location = new System.Drawing.Point(55, 262);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 28);
            this.label3.TabIndex = 6;
            this.label3.Text = "비밀번호 재설정";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
            this.label4.Location = new System.Drawing.Point(26, 361);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 23);
            this.label4.TabIndex = 7;
            this.label4.Text = "이름";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
            this.label5.Location = new System.Drawing.Point(26, 432);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "생년월일(8자리)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
            this.label6.Location = new System.Drawing.Point(24, 292);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 23);
            this.label6.TabIndex = 9;
            this.label6.Text = "ID";
            // 
            // pwidtext
            // 
            this.pwidtext.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pwidtext.Location = new System.Drawing.Point(28, 318);
            this.pwidtext.Name = "pwidtext";
            this.pwidtext.Size = new System.Drawing.Size(216, 30);
            this.pwidtext.TabIndex = 10;
            // 
            // pwnametext
            // 
            this.pwnametext.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pwnametext.Location = new System.Drawing.Point(28, 387);
            this.pwnametext.Name = "pwnametext";
            this.pwnametext.Size = new System.Drawing.Size(216, 30);
            this.pwnametext.TabIndex = 11;
            // 
            // pwbirthtext
            // 
            this.pwbirthtext.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pwbirthtext.Location = new System.Drawing.Point(28, 458);
            this.pwbirthtext.Name = "pwbirthtext";
            this.pwbirthtext.Size = new System.Drawing.Size(216, 30);
            this.pwbirthtext.TabIndex = 12;
            // 
            // find_pw_btn
            // 
            this.find_pw_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.find_pw_btn.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.find_pw_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(100)))), ((int)(((byte)(254)))));
            this.find_pw_btn.Location = new System.Drawing.Point(28, 503);
            this.find_pw_btn.Name = "find_pw_btn";
            this.find_pw_btn.Size = new System.Drawing.Size(216, 35);
            this.find_pw_btn.TabIndex = 13;
            this.find_pw_btn.Text = "비밀번호 재설정";
            this.find_pw_btn.UseVisualStyleBackColor = true;
            this.find_pw_btn.Click += new System.EventHandler(this.button2_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(100)))), ((int)(((byte)(254)))));
            this.label7.Location = new System.Drawing.Point(188, 9);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 28);
            this.label7.TabIndex = 22;
            this.label7.Text = "Chatify";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label8.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(100)))), ((int)(((byte)(254)))));
            this.label8.Location = new System.Drawing.Point(12, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 30);
            this.label8.TabIndex = 24;
            this.label8.Text = "⬅️";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(280, 572);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.find_pw_btn);
            this.Controls.Add(this.pwbirthtext);
            this.Controls.Add(this.pwnametext);
            this.Controls.Add(this.pwidtext);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.find_id_btn);
            this.Controls.Add(this.birthtext);
            this.Controls.Add(this.nametext);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.name);
            this.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form5";
            this.Text = "Form5";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nametext;
        private System.Windows.Forms.TextBox birthtext;
        private System.Windows.Forms.Button find_id_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox pwidtext;
        private System.Windows.Forms.TextBox pwnametext;
        private System.Windows.Forms.TextBox pwbirthtext;
        private System.Windows.Forms.Button find_pw_btn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}