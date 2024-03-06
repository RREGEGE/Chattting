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
using MySql.Data.MySqlClient;
using System.Runtime.InteropServices;
using System.Reflection;
using Org.BouncyCastle.Utilities;

namespace newChat
{
    public partial class Form3 : Form
    {
        TcpClient client;
        NetworkStream ns;
        private string userId; //
        private Form1 form1;
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        // 드래그 및 이동을 위한 상수들을 정의합니다.
        const int WM_NCLBUTTONDOWN = 0xA1;
        const int HT_CAPTION = 0x2;
        public Form3(string userName, string loginid, Form1 form1)
        {
            try
            {
                InitializeComponent();
                this.client = new TcpClient("localhost", 8000); // 전달받은 TcpClient 사용
                this.ns = client.GetStream(); // 전달받은 NetworkStream 사용
                this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form3_MouseDown);
                this.Load += new EventHandler(Form3_Load); // Form3_Load 이벤트를 수동으로 연결
                this.form1 = form1;
                name_label.Text = userName + " 님의 채팅룸"; //
                userId = loginid;
                dataGridView1.AllowUserToDeleteRows = true;

                this.AcceptButton = null;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Form3 생성 중 에러 발생: " + ex.Message);
            }
        }
        private void Form3_MouseDown(object sender, MouseEventArgs e)
        {
            // 왼쪽 마우스 버튼이 눌렸을 때, 창을 이동합니다.
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void search_txtbox_TextChanged(object sender, EventArgs e)
        {

        }
        private void Form3_Load(object sender, EventArgs e)
        {
        }

        private async void add_button_Click(object sender, EventArgs e)
        {
            try
            {
                string frdID = search_txtbox.Text;

                if (userId == frdID)
                {
                    MessageBox.Show("자기 자신을 친구로 추가할 수 없습니다!");
                    return;
                }

                // 친구 추가 요청을 서버에 전송
                string request = "ADD_FRIEND|" + userId + "|" + frdID;
                byte[] requestData = Encoding.UTF8.GetBytes(request);
                await ns.WriteAsync(requestData, 0, requestData.Length);

                // 서버로부터 응답을 받음
                byte[] buffer = new byte[1024];
                int bytesRead = ns.Read(buffer, 0, buffer.Length);
                string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                if (response == "SELF")
                {
                    MessageBox.Show("자기 자신을 친구로 추가할 수 없습니다!");
                }
                else if (response == "EXISTS")
                {
                    MessageBox.Show("이미 추가된 친구입니다!");
                }
                else if (response.StartsWith("SUCCESS2|"))
                {
                    string[] data = response.Split('|');
                    string roomId = data[1];
                    string frdName = data[2];

                    MessageBox.Show(frdName + "님과 친구가 되었습니다.");

                    int rowIndex = dataGridView1.Rows.Add();
                    DataGridViewRow row = dataGridView1.Rows[rowIndex];

                    row.Cells["frdID"].Value = frdID;
                    //row.Cells["frdID"].Value = search_txtbox.Text; 

                    row.Cells["frdName"].Value = frdName;
                }
                else
                {
                    MessageBox.Show("아이디가 존재하지 않습니다.");

                }
                search_txtbox.Text = "";

            }
            catch { }
        }
        public void AddFriendRow(string friendId, string friendName)
        {
            int rowIndex = dataGridView1.Rows.Add();
            DataGridViewRow row = dataGridView1.Rows[rowIndex];

            row.Cells["frdID"].Value = friendId;
            row.Cells["frdName"].Value = friendName;
        }

        private void chat_button_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                // 선택된 행의 인덱스를 가져옴
                int selectedIndex = dataGridView1.SelectedCells[0].RowIndex;

                // 선택된 행을 가져옴
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedIndex];

                // 선택된 행의 친구 아이디를 가져옴
                string friendId = Convert.ToString(selectedRow.Cells["frdID"].Value);
                string friendname = Convert.ToString(selectedRow.Cells["frdName"].Value);
                string roomId = "";
                byte[] requestData = Encoding.UTF8.GetBytes("get_roomid|" + userId + "|" + friendId);
                ns.Write(requestData, 0, requestData.Length);

                byte[] buffer = new byte[1024];
                int bytesRead = ns.Read(buffer, 0, buffer.Length);
                string data = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                if (data.StartsWith("ROOMID|"))
                {
                    // '|'를 기준으로 응답을 분리하여 roomid를 가져옵니다.
                    string[] parts = data.Split('|');
                    if (parts.Length == 2)
                    {
                        roomId = parts[1]; // 받은 roomid 저장
                    }
                }
                Form4 showform4 = new Form4(userId, friendId, roomId, friendname, client, ns); // 사용자 아이디와 친구 아이디를 전달합니다.
                showform4.ShowDialog();
            }
            else
            {
                MessageBox.Show("친구를 선택하세요."); // 아무것도 선택되지 않았을 때 경고 메시지를 표시합니다.
            }
        }

        private async void remove_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    int selectedIndex = dataGridView1.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedIndex];
                    string frdID = selectedRow.Cells["frdID"].Value.ToString();

                    // 서버에 삭제 요청 보내기
                    string request = "deleteF|" + userId + "|" + frdID;
                    byte[] requestData = Encoding.UTF8.GetBytes(request);
                    await ns.WriteAsync(requestData, 0, requestData.Length);

                    // dataGridView1에서 선택된 행 제거
                    dataGridView1.Rows.RemoveAt(selectedIndex);
                    MessageBox.Show("이제 " + frdID + "님과 더이상 친구가 아닙니다.");
                }
                else
                {
                    MessageBox.Show("삭제할 행을 선택하세요.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("오류 발생: " + ex.Message);
            }
        }


        private void logout_btn_Click(object sender, EventArgs e)
        {
            byte[] requestData = Encoding.UTF8.GetBytes("logout|" + userId);
            ns.Write(requestData, 0, requestData.Length);

            ns.Close();
            client.Close();

            this.Close();

            Form1 showform1 = new Form1(); // 새로운 Form1 인스턴스를 생성
            showform1.Show();
        }

        private void Form3_Load_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            // 프로그램을 종료합니다.
            Application.Exit();

        }

        private void label2_Click(object sender, EventArgs e)
        {
            byte[] requestData = Encoding.UTF8.GetBytes("logout|" + userId);
            ns.Write(requestData, 0, requestData.Length);

            ns.Close();
            client.Close();

            this.Close();

            Form1 showform1 = new Form1(); // 새로운 Form1 인스턴스를 생성
            showform1.Show();
        }
    }

}