using BurgerKing_kiosk.model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BurgerKing_kiosk.viewModel
{
    public class ServerViewModel
    {
        TcpClient client;
        NetworkStream stream;
        public void ConnectionServer()
        {
            client = new TcpClient("10.80.162.152", 80);
            //client = new TcpClient("10.80.163.197",80);
            stream = client.GetStream();
        }
        public void ReceiveServer()
        {
            byte[] outbuf = new byte[1024];
            int nbytes = stream.Read(outbuf, 0, outbuf.Length);
            string output = Encoding.ASCII.GetString(outbuf, 0, nbytes);

            Console.WriteLine($"{nbytes} bytes: {output}");
        }
        public void SendServer(JsonModel model)
        {
            string json = JsonConvert.SerializeObject(model);

            byte[] buff = Encoding.UTF8.GetBytes(json);

            stream.Write(buff, 0, buff.Length);

            ReceiveServer();
        }
        public void CloseServer()
        {
            stream.Close();
            client.Close();
        }
    }
}
