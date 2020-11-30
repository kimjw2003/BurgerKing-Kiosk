using BurgerKing_kiosk.model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BurgerKing_kiosk.viewModel
{
    public class ServerViewModel
    {
        private Socket clientSocket = null;
        private Socket cbSocket;
        private String host = "10.80.162.152";
        private int port = 80;
        byte[] outbuf = new byte[1024];

        public void ConnectionServer()
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.BeginConnect();
        }

        public void BeginConnect()
        {
            try
            {
                clientSocket.BeginConnect(host, port, new AsyncCallback(ConnectCallback), clientSocket);
            }
            catch (SocketException se)
            {
                //서버접속 실패
                Console.WriteLine("서버 접속 실패하셨습니다.");
                this.ConnectionServer();
            }
        }

        public void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                //보류중인 연결을 완성
                Socket tempSocket = (Socket)ar.AsyncState;
                IPEndPoint svrEP = (IPEndPoint)tempSocket.RemoteEndPoint;

                tempSocket.EndConnect(ar);
                cbSocket = tempSocket;
                cbSocket.BeginReceive(this.outbuf, 0, outbuf.Length,
                    SocketFlags.None, new AsyncCallback(ReceiveCallback), cbSocket);
            }
            catch(SocketException se)
            {
                if(se.SocketErrorCode == SocketError.NotConnected)
                {
                    Console.WriteLine("서버 접속 실패");
                    this.BeginConnect();//서버연결 실패시 다시 접속 시도
                }
            }
        }
        public void SendServer(JsonModel model)
        {
            try
            {
                if (CheckClient())
                {
                    string json = JsonConvert.SerializeObject(model);
                    byte[] buff = Encoding.UTF8.GetBytes(json);
                    clientSocket.BeginSend(buff, 0, buff.Length, SocketFlags.None,
                        new AsyncCallback(SendCallback), json);
                    ReceiveServer();
                }
            }
            catch (SocketException se)
            {
                Console.WriteLine("전송오류");
            }
        }
        private void SendCallback(IAsyncResult ar)
        {
            JsonModel json = (JsonModel)ar.AsyncState;
            Console.WriteLine("서버 전송완료");
        }
        public void ReceiveServer()
        {
            cbSocket.BeginReceive(outbuf, 0, outbuf.Length, SocketFlags.None,
                new AsyncCallback(ReceiveCallback), cbSocket);
        }
        private void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                Socket tempSocket = (Socket)ar.AsyncState;
                int readSize = tempSocket.EndReceive(ar);
                if (readSize != 0)
                {
                    string data = Encoding.UTF8.GetString(outbuf, 0, readSize);
                    Console.WriteLine(data);
                }
            }
            catch(SocketException se)
            {
                if (se.SocketErrorCode == SocketError.ConnectionReset)
                {
                    this.BeginConnect();
                }
            }
        }
        public void CloseServer()
        {
            if (CheckClient())
            {
                clientSocket.Close();
                cbSocket.Close();
            }
        }
        private bool CheckClient()
        {
            return clientSocket.Connected;
        }
    }
}
