using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Ocsp;

namespace ChatServer
{
    class Program
    {
        static TcpListener listener;
        static Mutex mutex = new Mutex();
        static bool isRunning = true;
        static Dictionary<string, List<TcpClient>> chatRoomClients = new Dictionary<string, List<TcpClient>>();
        static int count = 0;

        static void Main(string[] args)
        {
            StartServer();
        }

        static void StartServer()
        {
            try
            {
                listener = new TcpListener(IPAddress.Any, 8000);
                listener.Start();
                Console.WriteLine("서버 시작...");

                while (isRunning)
                {
                    TcpClient client = listener.AcceptTcpClient();
                    Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClient));
                    clientThread.Start(client);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("에러: " + ex.Message);
            }
        }

        static void HandleClient(object obj)
        {
            
            TcpClient currentClient = obj as TcpClient;
            NetworkStream stream = currentClient.GetStream();


            byte[] buffer = new byte[1024];
            int bytesRead;

            try
            {
                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    string data = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    string response = ProcessRequest(data, currentClient);
                    byte[] responseData = Encoding.UTF8.GetBytes(response);
                    stream.Write(responseData, 0, responseData.Length);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("에러: " + ex.Message);
            }
            finally
            {
                stream.Close();
                currentClient.Close();
            }
        }

        static string ProcessRequest(string request, TcpClient currentClient)
        {
            string response = "";
            mutex.WaitOne();

            try
            {
                string[] requestData = request.Split('|');
                string userId = requestData[1];
                
                if (requestData[0] == "LOGIN")
                {
                    string loginid = requestData[1];
                    string loginpwd = requestData[2];

                    MySqlConnection connection = new MySqlConnection("Server = 192.168.0.57;Database=chat;Uid=root;Pwd=qq112233;");
                    connection.Open();

                    string selectQuery = "SELECT name FROM info WHERE id = @loginId AND pwd = @loginPwd;";
                    MySqlCommand selectCommand = new MySqlCommand(selectQuery, connection);
                    selectCommand.Parameters.AddWithValue("@loginId", loginid);
                    selectCommand.Parameters.AddWithValue("@loginPwd", loginpwd);

                    object result = selectCommand.ExecuteScalar();
                    string userName = result != null ? result.ToString() : null;

                    if (userName != null)
                    {
                        // 친구 목록을 불러오는 쿼리
                        string query = "SELECT user1id, user2id, user1name, user2name FROM friend WHERE user1id = @userId OR user2id = @userId;";
                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.Parameters.AddWithValue("@userId", loginid);

                        MySqlDataReader reader = command.ExecuteReader();

                        // 친구 목록을 문자열로 만들어 응답에 추가
                        string friends = "";
                        while (reader.Read())
                        {
                            string friendId = reader["user1id"].ToString() == loginid ? reader["user2id"].ToString() : reader["user1id"].ToString();
                            string friendName = reader["user1id"].ToString() == loginid ? reader["user2name"].ToString() : reader["user1name"].ToString();
                            friends += "|" + friendId + ":" + friendName;
                        }
                       
                        response = "SUCCESS|" + userName + friends ;
                        Console.WriteLine(response);
                        Console.WriteLine("ID:" + loginid + " 로그인");
                    }
                    else
                    {
                        response = "FAIL";
                    }
                    connection.Close();
                }
                else if (requestData[0] == "friend_name")
                {
                    string id = requestData[1];
                    MySqlConnection connection = new MySqlConnection("Server = 192.168.0.57;Database=chat;Uid=root;Pwd=qq112233;");
                    connection.Open();
                    string selectQuery = "SELECT name FROM info WHERE id = @loginId ;";
                    MySqlCommand selectCommand = new MySqlCommand(selectQuery, connection);
                    selectCommand.Parameters.AddWithValue("@loginId", id);

                    object result = selectCommand.ExecuteScalar();
                    string userName = result != null ? result.ToString() : null;

                    if (userName != null)
                    {
                        // 친구 목록을 불러오는 쿼리
                        string query = "SELECT user1id, user2id, user1name, user2name FROM friend WHERE user1id = @userId OR user2id = @userId;";
                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.Parameters.AddWithValue("@userId", id);
                        MySqlDataReader reader = command.ExecuteReader();

                        // 친구 목록을 문자열로 만들어 응답에 추가
                        string friendname = "";
                        while (reader.Read())
                        {
                            string friendName = reader["user1id"].ToString() == id ? reader["user2name"].ToString() : reader["user1name"].ToString();
                            friendname += "|" + friendName;
                        }

                        response = "SUCCESS|" + friendname;
                        Console.WriteLine(response);
                    }
                    else
                    {
                        response = "FAIL";
                    }
                    connection.Close();
                }
                else if (requestData[0] == "chat_out")
                {
                    // 로그아웃 로직 생략
                    // 로그아웃 시 클라이언트를 채팅방에서 제거해야 함


                    string roomId = requestData[1];
                    if (chatRoomClients.ContainsKey(roomId))
                    {
                        chatRoomClients[roomId].Remove(currentClient);
                        Console.WriteLine();
                        count--;
                        Console.WriteLine("채팅 클라이언트 수: " + count);
                    }
                    
                }

                else if (requestData[0] == "SIGNUP")
                {
                    string name = requestData[1];
                    string id = requestData[2];
                    string pwd = requestData[3];
                    string birth = requestData[4];

                    MySqlConnection connection = new MySqlConnection("Server = 192.168.0.57;Database=chat;Uid=root;Pwd=qq112233;");
                    connection.Open();

                    string selectQuery = "SELECT id FROM info WHERE id = \'" + id + "\' ";
                    MySqlCommand Selectcommand = new MySqlCommand(selectQuery, connection);
                    MySqlDataReader userAccount = Selectcommand.ExecuteReader();

                    if (userAccount.Read())
                    {
                        response = "SIGNUP_FAIL";
                    }
                    else
                    {
                        userAccount.Close();

                        string insertQuery = "INSERT INTO info (name, id, pwd, birth) VALUES ('" + name + "', '" + id + "', '" + pwd + "', '" + birth + "')";
                        MySqlCommand Insertcommand = new MySqlCommand(insertQuery, connection);
                        Insertcommand.ExecuteNonQuery();

                        response = "SIGNUP_SUCCESS|" + name + "|" + id;
                    }
                    connection.Close();
                }
                else if (requestData[0] == "ADD_FRIEND")
                {
                    string frdID = requestData[2];

                    if (userId == frdID)
                    {
                        response = "SELF";
                    }
                    else
                    {
                        MySqlConnection connection = new MySqlConnection("Server = 192.168.0.57;Database=chat;Uid=root;Pwd=qq112233;");
                        connection.Open();

                        string checkQuery = "SELECT COUNT(*) FROM friend WHERE (user1id = @userId AND user2id = @frdID) OR (user1id = @frdID AND user2id = @userId);";
                        MySqlCommand checkCommand = new MySqlCommand(checkQuery, connection);
                        checkCommand.Parameters.AddWithValue("@userId", userId);
                        checkCommand.Parameters.AddWithValue("@frdID", frdID);

                        int count = Convert.ToInt32(checkCommand.ExecuteScalar());

                        if (count > 0)
                        {
                            response = "EXISTS";
                        }
                        else
                        {
                            string insertQuery = "insert into friend (user1id, user2id) values (@userId, @frdID);";
                            MySqlCommand command = new MySqlCommand(insertQuery, connection);
                            command.Parameters.AddWithValue("@userId", userId);
                            command.Parameters.AddWithValue("@frdID", frdID);

                            command.ExecuteNonQuery();

                            string roomId = "";
                            string selectRoomIdQuery = "SELECT roomid FROM friend WHERE (user1id = @userId AND user2id = @frdID) OR (user1id = @frdID AND user2id = @userId) ORDER BY roomid DESC LIMIT 1;";
                            MySqlCommand selectRoomIdCommand = new MySqlCommand(selectRoomIdQuery, connection);
                            selectRoomIdCommand.Parameters.AddWithValue("@userId", userId);
                            selectRoomIdCommand.Parameters.AddWithValue("@frdID", frdID);
                            MySqlDataReader roomIdReader = selectRoomIdCommand.ExecuteReader();

                            if (roomIdReader.Read())
                            {
                                roomId = roomIdReader.GetInt32("roomid").ToString();
                                List<TcpClient> clientsInRoom = new List<TcpClient>();
                                chatRoomClients[roomId] = clientsInRoom;
                            }
                            roomIdReader.Close();

                            string getNameQuery = "SELECT name FROM info WHERE id = @frdID;";
                            MySqlCommand getNameCommand = new MySqlCommand(getNameQuery, connection);
                            getNameCommand.Parameters.AddWithValue("@frdID", frdID);

                            string frdName = getNameCommand.ExecuteScalar().ToString();

                            response = "SUCCESS2|" + frdID + "|" + frdName;
                        }
                        Console.WriteLine(response);
                        connection.Close();

                    }

                }
                else if (requestData[0] == "deleteF")
                {
                    userId = requestData[1];
                    string frdID = requestData[2];
                    MySqlConnection connection = new MySqlConnection("Server = 192.168.0.57;Database=chat;Uid=root;Pwd=qq112233;");
                    connection.Open();

                    try
                    {
                        int roomId = 0;

                        string selectRoomIdQuery = "SELECT roomid FROM friend WHERE (user1id = @userId AND user2id = @frdID) OR (user1id = @frdID AND user2id = @userId);";
                        MySqlCommand selectRoomIdCommand = new MySqlCommand(selectRoomIdQuery, connection);
                        selectRoomIdCommand.Parameters.AddWithValue("@userId", userId);
                        selectRoomIdCommand.Parameters.AddWithValue("@frdID", frdID);
                        using (MySqlDataReader roomIdReader = selectRoomIdCommand.ExecuteReader())
                        {
                            if (roomIdReader.Read())
                            {
                                roomId = roomIdReader.GetInt32(0);
                            }
                        }

                        string countChatQuery = "SELECT COUNT(*) FROM chat WHERE roomid = @roomId";
                        MySqlCommand countChatCommand = new MySqlCommand(countChatQuery, connection);
                        countChatCommand.Parameters.AddWithValue("@roomId", roomId);
                        object result = countChatCommand.ExecuteScalar();
                        int count = Convert.ToInt32(result);

                        if (count > 0)
                        {
                            string deleteChatQuery = "DELETE FROM chat WHERE roomid = @roomId";
                            MySqlCommand deleteChatCommand = new MySqlCommand(deleteChatQuery, connection);
                            deleteChatCommand.Parameters.AddWithValue("@roomId", roomId);
                            deleteChatCommand.ExecuteNonQuery();
                        }

                        string deleteFriendQuery = "DELETE FROM friend WHERE roomid = @roomId";
                        MySqlCommand deleteFriendCommand = new MySqlCommand(deleteFriendQuery, connection);
                        deleteFriendCommand.Parameters.AddWithValue("@roomId", roomId);
                        deleteFriendCommand.ExecuteNonQuery();
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine("MySQL 에러: " + ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }


                else if (requestData[0] == "get_roomid")
                {
                    string loginId = requestData[1];
                    string friendId = requestData[2];

                    MySqlConnection connection = new MySqlConnection("Server = 192.168.0.57;Database=chat;Uid=root;Pwd=qq112233;");
                    connection.Open();

                    string selectRoomIdQuery = "SELECT roomid FROM friend WHERE user1id = @loginId AND user2id = @friendId OR user1id = @friendId AND user2id = @loginId";
                    MySqlCommand selectRoomIdCommand = new MySqlCommand(selectRoomIdQuery, connection);
                    selectRoomIdCommand.Parameters.AddWithValue("@loginId", loginId);
                    selectRoomIdCommand.Parameters.AddWithValue("@friendId", friendId);

                    MySqlDataReader roomIdReader;
                    try
                    {
                        roomIdReader = selectRoomIdCommand.ExecuteReader();
                        if (roomIdReader.Read()) // 검색 결과가 있는 경우
                        {
                            string roomId = roomIdReader["roomid"].ToString();
                            response = "ROOMID|" + roomId; // 클라이언트로 전송할 응답
                        }
                        else // 검색 결과가 없는 경우
                        {
                            response = "ROOMID|"; // 빈 응답 전송
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("roomIdReader 생성 실패: " + e.Message);
                        throw new Exception("roomIdReader 생성 실패"); // 예외 발생
                    }

                    Console.WriteLine(response);
                    
                    roomIdReader.Close();
                    connection.Close();
                }
                
                else if (requestData[0] == "set_roomid")
                {
                    string roomId = requestData[1];
                    if (!chatRoomClients.ContainsKey(roomId))
                    {
                        chatRoomClients.Add(roomId, new List<TcpClient>());
                        count++;
                        Console.WriteLine("채팅 클라이언트 수: " + count);
                    }
                    chatRoomClients[roomId].Add(currentClient);
                }
                else if (requestData[0] == "FiND_iD")
                {
                    string name = requestData[1];
                    string birth = requestData[2];
                    MySqlConnection connection = new MySqlConnection("Server = 192.168.0.57;Database=chat;Uid=root;Pwd=qq112233;");
                    connection.Open();

                    string selectQuery = "SELECT id FROM info WHERE name = @name AND birth = @birth;";
                    MySqlCommand command = new MySqlCommand(selectQuery, connection);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@birth", birth);

                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string foundId = reader["id"].ToString();
                        response = "SUCCESS_Find|" + foundId;
                    }
                    else
                    {
                        response = "ID_NOT_FOUND";
                    }

                    reader.Close();
                    connection.Close();
                }
                else if (requestData[0] == "FindPW")
                {
                    string id = requestData[1];
                    string name = requestData[2];
                    string birth = requestData[3];
                    MySqlConnection connection = new MySqlConnection("Server = 192.168.0.57;Database=chat;Uid=root;Pwd=qq112233;");
                    connection.Open();

                    string selectQuery = "SELECT * FROM info WHERE id = @id AND name = @name AND birth = @birth;";
                    MySqlCommand command = new MySqlCommand(selectQuery, connection);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@birth", birth);
                    command.Parameters.AddWithValue("@id", id);
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {

                        response = "SUCCESS_Find";
                    }
                    else
                    {
                        response = "ID_NOT_FOUND";
                    }

                    reader.Close();
                    connection.Close();
                }
                else if (requestData[0] == "load_chat")
                {
                    string roomid = requestData[1];
                    MySqlConnection connection = new MySqlConnection("Server = 192.168.0.57;Database=chat;Uid=root;Pwd=qq112233;");
                    connection.Open();
                    string selectQuery = "SELECT senderid, content, chattime  FROM chat WHERE roomid = @roomid;";
                    MySqlCommand selectCommand = new MySqlCommand(selectQuery, connection);
                    selectCommand.Parameters.AddWithValue("@roomid", roomid);
                    MySqlDataReader reader = selectCommand.ExecuteReader();

                    // 채팅 내역이 있는지 확인
                    if (!reader.HasRows)
                    {
                        response = "FAIL|No chat history found.";
                    }
                    else
                    {
                        // 친구 목록을 문자열로 만들어 응답에 추가
                        string chat = "";
                        while (reader.Read())
                        {
                            DateTime chatTime = Convert.ToDateTime(reader["chattime"]);
                            string formattedTime = chatTime.ToString("yyyy-MM-dd HH:mm:ss");
                            string chat_ = reader["senderid"].ToString() + ": " + reader["content"] + " (" + formattedTime + ")";
                            chat += "|" + chat_;
                        }

                        response = "SUCCESS|" + chat;
                    }

                    reader.Close();
                    connection.Close();
                }
                else if (requestData[0] == "ChangePW")
                {
                    string password = requestData[1];
                    string id = requestData[2];

                    MySqlConnection connection = new MySqlConnection("Server = 192.168.0.57;Database=chat;Uid=root;Pwd=qq112233;");
                    connection.Open();

                    string updateQuery = "UPDATE info SET pwd = @password WHERE id = @id;";
                    MySqlCommand command = new MySqlCommand(updateQuery, connection);
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters.AddWithValue("@id", id);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        response = "SUCCESS_PasswordChanged";
                    }
                    else
                    {
                        response = "FAIL_PasswordChange";
                    }

                    connection.Close();
                }
                else if (requestData[0] == "logout")
                {
                    
                    string id = requestData[1];
                    Console.WriteLine("ID:" + id + " 로그아웃");
                }
                else if (requestData[0] == "send_chat")
                {
                    string senderId = requestData[1];
                    string friendId = requestData[2];
                    string content = requestData[3];

                    MySqlConnection connection = new MySqlConnection("Server = 192.168.0.57;Database=chat;Uid=root;Pwd=qq112233;");
                    connection.Open();

                    // 로그인한 사용자와 친구의 ID를 사용해 채팅방 ID를 찾음
                    string selectQuery = "SELECT roomid FROM friend WHERE (user1id = @senderId AND user2id = @friendId) OR (user1id = @friendId AND user2id = @senderId)";
                    MySqlCommand selectCommand = new MySqlCommand(selectQuery, connection);
                    selectCommand.Parameters.AddWithValue("@senderId", senderId);
                    selectCommand.Parameters.AddWithValue("@friendId", friendId);

                    int roomId = Convert.ToInt32(selectCommand.ExecuteScalar());

                    // 찾은 채팅방 ID를 사용해 채팅 내용을 저장
                    string insertQuery = "INSERT INTO chat (roomid, chattime, senderid, content) VALUES (@roomId, NOW(), @senderId, @content)";
                    MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection);
                    insertCommand.Parameters.AddWithValue("@roomId", roomId);
                    insertCommand.Parameters.AddWithValue("@senderId", senderId);
                    insertCommand.Parameters.AddWithValue("@content", content);

                    insertCommand.ExecuteNonQuery();
                    Console.WriteLine("메시지 전송 시도: " + content + ", 방 ID: " + roomId); // 채팅방에 메시지 전송을 시도하는 로그 출력
                    
                    // 해당 채팅방에 있는 모든 클라이언트에게 메시지 전달
                    if (chatRoomClients.TryGetValue(roomId.ToString(), out List<TcpClient> clientsInRoom))
                    {
                        string currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        byte[] messageBytes = Encoding.UTF8.GetBytes(senderId + ": " +content + " (" + currentTime + ")");
                        foreach (TcpClient clientInRoom in clientsInRoom)
                        {
                            NetworkStream clientStream = clientInRoom.GetStream();
                            clientStream.Write(messageBytes, 0, messageBytes.Length);
                            clientStream.Write(Encoding.UTF8.GetBytes(Environment.NewLine), 0, Encoding.UTF8.GetBytes(Environment.NewLine).Length); // 개행 문자 추가

                            Console.WriteLine("메시지 전송: " + content); // 콘솔에 로그 출력
                        }
                    }
                    else
                    {
                        Console.WriteLine("채팅방 목록에서 해당 채팅방을 찾지 못함: " + roomId); // 채팅방을 찾지 못했을 때의 로그 출력
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                response = "ERROR|" + ex.Message;
            }

            mutex.ReleaseMutex();
            return response;
        }

        static void StopServer()
        {
            isRunning = false;
            listener.Stop();
            Console.WriteLine("서버 종료");
        }
    }
}