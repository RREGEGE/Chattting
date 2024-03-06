namespace newChat
{
    partial class Form3
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
            this.search_txtbox = new System.Windows.Forms.TextBox();
            this.add_button = new System.Windows.Forms.Button();
            this.name_label = new System.Windows.Forms.Label();
            this.chat_button = new System.Windows.Forms.Button();
            this.remove_btn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.frdID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.frdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(100)))), ((int)(((byte)(254)))));
            this.label1.Location = new System.Drawing.Point(33, 91);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "친구 검색";
            // 
            // search_txtbox
            // 
            this.search_txtbox.Location = new System.Drawing.Point(127, 92);
            this.search_txtbox.Margin = new System.Windows.Forms.Padding(2);
            this.search_txtbox.Name = "search_txtbox";
            this.search_txtbox.Size = new System.Drawing.Size(162, 25);
            this.search_txtbox.TabIndex = 1;
            this.search_txtbox.TextChanged += new System.EventHandler(this.search_txtbox_TextChanged);
            // 
            // add_button
            // 
            this.add_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add_button.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(100)))), ((int)(((byte)(254)))));
            this.add_button.Location = new System.Drawing.Point(304, 86);
            this.add_button.Margin = new System.Windows.Forms.Padding(2);
            this.add_button.Name = "add_button";
            this.add_button.Size = new System.Drawing.Size(81, 35);
            this.add_button.TabIndex = 2;
            this.add_button.Text = "추가하기";
            this.add_button.UseVisualStyleBackColor = true;
            this.add_button.Click += new System.EventHandler(this.add_button_Click);
            // 
            // name_label
            // 
            this.name_label.AutoSize = true;
            this.name_label.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(100)))), ((int)(((byte)(254)))));
            this.name_label.Location = new System.Drawing.Point(132, 25);
            this.name_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.name_label.Name = "name_label";
            this.name_label.Size = new System.Drawing.Size(70, 28);
            this.name_label.TabIndex = 4;
            this.name_label.Text = "label2";
            // 
            // chat_button
            // 
            this.chat_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(100)))), ((int)(((byte)(254)))));
            this.chat_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chat_button.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chat_button.ForeColor = System.Drawing.Color.White;
            this.chat_button.Location = new System.Drawing.Point(206, 520);
            this.chat_button.Margin = new System.Windows.Forms.Padding(2);
            this.chat_button.Name = "chat_button";
            this.chat_button.Size = new System.Drawing.Size(163, 35);
            this.chat_button.TabIndex = 5;
            this.chat_button.Text = "채팅하기";
            this.chat_button.UseVisualStyleBackColor = false;
            this.chat_button.Click += new System.EventHandler(this.chat_button_Click);
            // 
            // remove_btn
            // 
            this.remove_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.remove_btn.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remove_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(100)))), ((int)(((byte)(254)))));
            this.remove_btn.Location = new System.Drawing.Point(52, 520);
            this.remove_btn.Margin = new System.Windows.Forms.Padding(2);
            this.remove_btn.Name = "remove_btn";
            this.remove_btn.Size = new System.Drawing.Size(150, 35);
            this.remove_btn.TabIndex = 6;
            this.remove_btn.Text = "삭제하기";
            this.remove_btn.UseVisualStyleBackColor = true;
            this.remove_btn.Click += new System.EventHandler(this.remove_btn_Click);
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
            this.label4.TabIndex = 13;
            this.label4.Text = "❌";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.frdID,
            this.frdName});
            this.dataGridView1.Location = new System.Drawing.Point(52, 147);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(318, 358);
            this.dataGridView1.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(100)))), ((int)(((byte)(254)))));
            this.label2.Location = new System.Drawing.Point(10, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "로그아웃";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // frdID
            // 
            this.frdID.HeaderText = "친구ID";
            this.frdID.MinimumWidth = 6;
            this.frdID.Name = "frdID";
            this.frdID.Width = 120;
            // 
            // frdName
            // 
            this.frdName.HeaderText = "친구이름";
            this.frdName.MinimumWidth = 6;
            this.frdName.Name = "frdName";
            this.frdName.Width = 120;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(414, 604);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.remove_btn);
            this.Controls.Add(this.chat_button);
            this.Controls.Add(this.name_label);
            this.Controls.Add(this.add_button);
            this.Controls.Add(this.search_txtbox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox search_txtbox;
        private System.Windows.Forms.Button add_button;
        private System.Windows.Forms.Label name_label;
        private System.Windows.Forms.Button chat_button;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader friendList;
        private System.Windows.Forms.Button remove_btn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn frdID;
        private System.Windows.Forms.DataGridViewTextBoxColumn frdName;
    }
}