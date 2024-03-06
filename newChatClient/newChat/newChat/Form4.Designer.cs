namespace newChat
{
    partial class Form4
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
            this.send_btn = new System.Windows.Forms.Button();
            this.fname = new System.Windows.Forms.Label();
            this.chat_send = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chatBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // send_btn
            // 
            this.send_btn.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.send_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(100)))), ((int)(((byte)(254)))));
            this.send_btn.Location = new System.Drawing.Point(348, 534);
            this.send_btn.Name = "send_btn";
            this.send_btn.Size = new System.Drawing.Size(40, 41);
            this.send_btn.TabIndex = 0;
            this.send_btn.Text = "✉️";
            this.send_btn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.send_btn.UseVisualStyleBackColor = true;
            this.send_btn.Click += new System.EventHandler(this.send_btn_Click);
            this.send_btn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.send_btn_KeyDown);
            // 
            // fname
            // 
            this.fname.AutoSize = true;
            this.fname.Font = new System.Drawing.Font("Nirmala UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(100)))), ((int)(((byte)(254)))));
            this.fname.Location = new System.Drawing.Point(20, 28);
            this.fname.Name = "fname";
            this.fname.Size = new System.Drawing.Size(63, 25);
            this.fname.TabIndex = 1;
            this.fname.Text = "label1";
            // 
            // chat_send
            // 
            this.chat_send.Location = new System.Drawing.Point(25, 534);
            this.chat_send.Multiline = true;
            this.chat_send.Name = "chat_send";
            this.chat_send.Size = new System.Drawing.Size(317, 41);
            this.chat_send.TabIndex = 2;
            this.chat_send.TextChanged += new System.EventHandler(this.chat_send_TextChanged);
            this.chat_send.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chat_send_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(100)))), ((int)(((byte)(254)))));
            this.label4.Location = new System.Drawing.Point(368, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 23);
            this.label4.TabIndex = 14;
            this.label4.Text = "❌";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // chatBox
            // 
            this.chatBox.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chatBox.Location = new System.Drawing.Point(25, 72);
            this.chatBox.Multiline = true;
            this.chatBox.Name = "chatBox";
            this.chatBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.chatBox.Size = new System.Drawing.Size(363, 444);
            this.chatBox.TabIndex = 15;
            this.chatBox.TextChanged += new System.EventHandler(this.chatBox_TextChanged_1);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(414, 604);
            this.Controls.Add(this.chatBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chat_send);
            this.Controls.Add(this.fname);
            this.Controls.Add(this.send_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form4";
            this.Text = "Form4";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button send_btn;
        private System.Windows.Forms.Label fname;
        private System.Windows.Forms.TextBox chat_send;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox chatBox;
    }
}