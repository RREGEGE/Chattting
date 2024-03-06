using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace newChat
{
    public partial class Form6 : Form
    {
        private string id;
        TcpClient client;
        NetworkStream ns;
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        const int WM_NCLBUTTONDOWN = 0xA1;
        const int HT_CAPTION = 0x2;
        public Form6(string Findpwid)
        {
            InitializeComponent();
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            id = Findpwid;
            textBox1.PasswordChar = '*';
            textBox2.PasswordChar = '*';
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            // 왼쪽 마우스 버튼이 눌렸을 때, 창을 이동합니다.
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (TcpClient client = new TcpClient("192.168.0.57", 8000))
                {
                    using (NetworkStream ns = client.GetStream())
                    {
                        string new_pwd = textBox1.Text;
                        string renew_pwd = textBox2.Text;
                        if (new_pwd != renew_pwd)
                        {
                            MessageBox.Show("비밀번호가 일치하지 않습니다.");
                        }
                        else
                        {

                            string change_pwd = "ChangePW|" + textBox1.Text + "|" + id;
                            byte[] change_pwdBytes = Encoding.UTF8.GetBytes(change_pwd);
                            ns.Write(change_pwdBytes, 0, change_pwdBytes.Length);
                            MessageBox.Show("비밀번호가 변경되었습니다.");
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
