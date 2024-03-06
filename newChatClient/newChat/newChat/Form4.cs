using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace newChat
{
    delegate void SetTextDelegate(string s);

    public partial class Form4 : Form
    {
        TcpClient client;
        NetworkStream ns;
        Thread receiveThread;
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        // 드래그 및 이동을 위한 상수들을 정의합니다.
        const int WM_NCLBUTTONDOWN = 0xA1;
        const int HT_CAPTION = 0x2;

        private string loginId;
        private string roomId;
        private string friendId;
        private string friendName;
        ChatHandler chatHandler = new ChatHandler();
        public Form4(string loginid, string friendId, string roomId, string friendname, TcpClient client, NetworkStream ns)
        {
            InitializeComponent();
            this.client = client; // 전달받은 TcpClient 사용
            this.ns = ns; // 전달받은 NetworkStream 사용
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form4_MouseDown);

            this.loginId = loginid;
            this.friendId = friendId;
            this.roomId = roomId;
            this.friendName = friendname;
            fname.Text = friendName + "님과의 채팅방";
            chatHandler.Setup(this, ns, this.chatBox);
            Thread chatThread = new Thread(new ThreadStart(async () => await chatHandler.ChatProcess()));
            chatThread.Start();
            byte[] requestData = Encoding.UTF8.GetBytes("set_roomid|" + roomId);
            ns.Write(requestData, 0, requestData.Length);
            requestData = Encoding.UTF8.GetBytes("load_chat|" + roomId);
            ns.Write(requestData, 0, requestData.Length);

            byte[] buffer = new byte[1024];
            int bytesRead = ns.Read(buffer, 0, buffer.Length);
            string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            string[] responseData = response.Split('|');
            if (responseData[0] == "SUCCESS")
            {
                for (int i = 2; i < responseData.Length; i++)
                {
                    this.chatBox.AppendText(responseData[i] + Environment.NewLine + Environment.NewLine);
                }
            }
            
        }
        
        private void Form4_Load(object sender, EventArgs e)
        {
            // chatBox에 있는 제일 마지막 메시지로 스크롤합니다.
            chatBox.SelectionStart = chatBox.TextLength;
            chatBox.ScrollToCaret();
        }
        
        private void Form4_MouseDown(object sender, MouseEventArgs e)
        {
            // 왼쪽 마우스 버튼이 눌렸을 때, 창을 이동합니다.
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private async void send_btn_Click(object sender, EventArgs e)
        {
            string content = chat_send.Text.Trim();
            if (!string.IsNullOrEmpty(content)) // 입력된 문자열이 비어있지 않은 경우에만 처리합니다.
            {
                byte[] requestData = Encoding.UTF8.GetBytes("send_chat|" + loginId + "|" + friendId + "|" + content);
                await ns.WriteAsync(requestData, 0, requestData.Length);

                //chatBox.AppendText(loginId + ": " + content + Environment.NewLine);
                chat_send.Clear();
            }

        }
        private void chat_send_TextChanged(object sender, EventArgs e)
        {

        }

        private void chatBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            byte[] requestData = Encoding.UTF8.GetBytes("chat_out|" + roomId);
            ns.Write(requestData, 0, requestData.Length);
            this.Close();
        }

        private void send_btn_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void chat_send_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                // 엔터 키가 눌렸을 때 줄바꿈을 막습니다.
                e.Handled = true;
                e.SuppressKeyPress = true;

                // send_btn_Click 이벤트를 호출합니다.
                send_btn_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Enter && e.Shift)
            {
                // Shift + 엔터 키가 눌렸을 때는 줄을 띄웁니다.
                if (chat_send.Lines.Length > 1 && string.IsNullOrWhiteSpace(chat_send.Lines[chat_send.Lines.Length - 1]))
                {
                    // 이미 두 번 줄 바꿈이 되어있는 경우
                    chat_send.AppendText(Environment.NewLine);
                }
                else
                {
                    chat_send.AppendText("\n"); // 줄바꿈 추가
                }
            }
        }
        public void SetText(string text)
        {
            if (this.chatBox.InvokeRequired)
            {
                SetTextDelegate d = new SetTextDelegate(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.chatBox.AppendText(text);
            }
        }

        private void chatBox_TextChanged_1(object sender, EventArgs e)
        {
        }
    }

    public class ChatHandler
    {
        private TextBox chatBox;
        private NetworkStream ns;
        private StreamReader strReader;
        private Form4 form4;

        public void Setup(Form4 form4, NetworkStream netStream, TextBox textBox)
        {
            this.chatBox = textBox;
            this.ns = netStream;
            this.form4 = form4;
            this.ns = netStream;
            this.strReader = new StreamReader(netStream);
        }

        private void CloseForm4()
        {
            // Form4가 열려 있는지 확인
            if (form4 != null)
            {
                // Form4를 숨김
                form4.Hide();
            }
        }

        public async Task ChatProcess()
        {
            while (true)
            {
                try
                {
                    //문자열을 받음
                    byte[] buffer = new byte[1024];
                    int bytesRead = await ns.ReadAsync(buffer, 0, buffer.Length);
                    string lstMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    if (lstMessage != null && lstMessage != "")
                    {
                        //SetText 메서드에서 델리게이트를 이용하여 서버에서 넘어오는 메시지를 쓴다.
                        form4.SetText(lstMessage + "\r\n");
                    }
                }
                catch (System.Exception)
                {
                    break;
                }
            }
        }
    }

}