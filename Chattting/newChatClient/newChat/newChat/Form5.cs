using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace newChat
{
   
    public partial class Form5 : Form
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
        public Form5()
        {
            InitializeComponent();
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form5_MouseDown);
            this.AcceptButton = null;
            
        }
        private void Form5_MouseDown(object sender, MouseEventArgs e)
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
                string Findidname = nametext.Text;
                string userInput = birthtext.Text; // 텍스트박스에서 가져온 값
                DateTime Findidbirth = DateTime.ParseExact(userInput, "yyyyMMdd", CultureInfo.InvariantCulture);
                

                TcpClient client = new TcpClient("192.168.0.57", 8000);
                NetworkStream stream = client.GetStream();

                string FindID = "FiND_iD|" + Findidname + "|" + Findidbirth.ToString("yyyy-MM-dd");
                byte[] FindIDBytes = Encoding.UTF8.GetBytes(FindID);
                stream.Write(FindIDBytes, 0, FindIDBytes.Length);


                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                string[] responseData = response.Split('|');
                if (responseData[0] == "SUCCESS_Find")
                {
                    string userID = responseData[1];

                    MessageBox.Show("ID:" + userID);

                }
                else
                {
                    MessageBox.Show("회원 정보를 확인해 주세요.");

                    stream.Close();
                    client.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Form3 인스턴스 생성 중 에러 발생: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string Findpwid = pwidtext.Text;
                string Findpwname = pwnametext.Text;
                string birth = pwbirthtext.Text;
                DateTime Findpwbirth = DateTime.ParseExact(birth, "yyyyMMdd", CultureInfo.InvariantCulture);
                TcpClient client = new TcpClient("localhost", 8000);
                NetworkStream stream = client.GetStream();
                string FindPW = "FindPW|" + Findpwid + "|" + Findpwname + "|" + Findpwbirth.ToString("yyyy-MM-dd");
                byte[] FindPWBytes = Encoding.UTF8.GetBytes(FindPW);
                stream.Write(FindPWBytes, 0, FindPWBytes.Length);

                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                string[] responseData = response.Split('|');
                if (response == "SUCCESS_Find")
                {
                    Form6 showform6 = new Form6(Findpwid);
                    showform6.ShowDialog();
                }
                else
                {
                    MessageBox.Show("회원 정보를 확인해 주세요.");
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
