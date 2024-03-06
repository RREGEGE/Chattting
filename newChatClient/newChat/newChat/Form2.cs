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
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace newChat
{
    public partial class Form2 : Form //회원가입
    {
        TcpClient client;
        NetworkStream ns;
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        // 드래그 및 이동을 위한 상수들을 정의합니다.
        const int WM_NCLBUTTONDOWN = 0xA1;
        const int HT_CAPTION = 0x2;
        public Form2()
        {
            InitializeComponent();
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form2_MouseDown);
            client = new TcpClient("192.168.0.57", 8000);
            ns = client.GetStream();
            pwd_txtbox.PasswordChar = '*';
            repwd_txtbox.PasswordChar = '*';
        }
        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            // 왼쪽 마우스 버튼이 눌렸을 때, 창을 이동합니다.
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                string pwd = pwd_txtbox.Text;
                string repwd = repwd_txtbox.Text; // 재입력한 비밀번호
                string id = id_txtbox.Text;
                string name = name_txtbox.Text;
                string birth = birth_txtbox.Text;

                if (pwd != repwd)
                {
                    MessageBox.Show("비밀번호가 일치하지 않습니다. 다시 입력해주세요.");
                    return;
                }
                // 회원가입 정보를 서버에 전송
                string request = "SIGNUP|" + name + "|" + id + "|" + pwd + "|" + birth;
                byte[] requestData = Encoding.UTF8.GetBytes(request);
                ns.Write(requestData, 0, requestData.Length);

                // 서버로부터 응답을 받음
                byte[] buffer = new byte[1024];
                int bytesRead = ns.Read(buffer, 0, buffer.Length);
                string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                string[] responseData = response.Split('|');

                // 응답을 분석하여 회원가입 성공 여부 판단
                if (responseData[0] == "SIGNUP_SUCCESS")
                {
                    MessageBox.Show(responseData[1] + "님 회원가입 완료, 사용할 아이디는 " + responseData[2] + "입니다.");
                    Close();
                }
                else if (responseData[0] == "SIGNUP_FAIL")
                {
                    MessageBox.Show("중복된 아이디 입니다.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void repwd_txtbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
