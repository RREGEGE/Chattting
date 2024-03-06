using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.InteropServices;
namespace newChat
{
    public partial class Form1 : Form //로그인창
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
        public Form1()
        {
            InitializeComponent();
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.AcceptButton = null;
            client = new TcpClient("192.168.0.57", 8000);
            ns = client.GetStream();
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
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                string loginid = textBox1.Text;
                string loginpwd = textBox2.Text;



                string request = "LOGIN|" + loginid + "|" + loginpwd;
                byte[] requestData = Encoding.UTF8.GetBytes(request);
                ns.Write(requestData, 0, requestData.Length);

                byte[] buffer = new byte[1024];
                int bytesRead = ns.Read(buffer, 0, buffer.Length);
                string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                string[] responseData = response.Split('|');

                if (responseData[0] == "SUCCESS")
                {
                    string userName = responseData[1];
                    
                    MessageBox.Show("로그인 완료");
                    this.Hide();

                    Form3 showform3 = new Form3(responseData[1], loginid, this);
                    for (int i = 2; i < responseData.Length; i++) // 친구 목록을 DataGridView에 추가
                    {
                        string[] friendInfo = responseData[i].Split(':');
                        showform3.AddFriendRow(friendInfo[0], friendInfo[1]); // friendId와 friendName을 전달
                       
                    }
                    ns.Close();
                    client.Close();
                    showform3.ShowDialog();
                }
                else
                {
                    MessageBox.Show("회원 정보를 확인해 주세요.");
                    


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Form3 인스턴스 생성 중 에러 발생: " + ex.Message);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 showform2 = new Form2();
            showform2.ShowDialog();
        }

        private void Find_id_btn_Click(object sender, EventArgs e)
        {
            Form5 showform5 = new Form5();
            showform5.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            // 프로그램을 종료합니다.
            Application.Exit();

        }
    }
}