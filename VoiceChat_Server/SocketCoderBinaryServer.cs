using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace SocketCoder
{
   class  SockCoderBinServer
    {
        public static ArrayList arrayClient = new ArrayList();
        static Socket socketListener;
        static SocketCoderClient nClient; //новый клиент
        // 1. Создать сервер
        public static string StartServer(int portNum)
        {
            try
            {
                IPAddress[] IPaddressMas = null;  // Массив IP-адресов
                String hostNameServ = String.Empty; //Имя узла локального компьютера
                try
                {
                    hostNameServ = Dns.GetHostName();
                    IPHostEntry ipHost = Dns.GetHostByName(hostNameServ);
                    IPaddressMas = ipHost.AddressList;
                }
                catch (Exception) {}

                if (IPaddressMas == null || IPaddressMas.Length < 1)
                {
                    return "Ошибка! Невозможно получить локальный адрес.";  
                }

                socketListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                socketListener.Bind(new IPEndPoint(IPaddressMas[0], portNum));
                socketListener.Listen(10);

                socketListener.BeginAccept(new AsyncCallback(ClientConncetion), socketListener);

                return ("Прослушивание порта: " + portNum + " OK"); 

            }
            catch (Exception exception)
                { return exception.Message; }
        }

        // 2. Принять подключение клиентов
        private static void ClientConncetion(IAsyncResult ar)
        {
            try
            {
                socketListener = (Socket)ar.AsyncState;
                AddNewClient(socketListener.EndAccept(ar));
                socketListener.BeginAccept(new AsyncCallback(ClientConncetion), socketListener);
            }
            catch (Exception) { }
        }

        // 3. Создайте Socket для каждого клиента и добавьте его в Socket ArrayList
        private static void AddNewClient(Socket socket)
        {
            nClient = new SocketCoderClient(socket);
            arrayClient.Add(nClient);

            nClient.acceptCallback();
        }

        // 4. Отправить полученные данные всем клиентам в комнате
        private static void SendData(IAsyncResult ar)
        {
            SocketCoderClient socketCoderClient = (SocketCoderClient)ar.AsyncState;
            byte[] masRecData = socketCoderClient.GetRecievedData(ar);

            if (masRecData.Length < 1)
            {
                socketCoderClient.ReadOnlySocket.Close();
                arrayClient.Remove(socketCoderClient);
                return;
            }
            foreach (SocketCoderClient clnt in arrayClient)
            {
                if (socketCoderClient != clnt)
                try
                {
                    clnt.ReadOnlySocket.Send(masRecData);
                }
                catch
                {
                    clnt.ReadOnlySocket.Close();
                    arrayClient.Remove(socketCoderClient);
                    return;
                }
            }
            socketCoderClient.acceptCallback();
        }

        public static string Disconnection()
        {
            try
            {
                socketListener.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                return ("Разъединение: OK"); 
            }
            catch (Exception exception) { return (exception.Message); }

        }

        internal class SocketCoderClient
        {
            // создать новый сокет для каждого клиента

            private Socket newSock;
            private byte[] bfr = null; //буфер

            public SocketCoderClient(Socket socket)
            {
                newSock = socket;
            }

            public Socket ReadOnlySocket
            {
                get { return newSock; }
            }

            public void acceptCallback()
            {
                try
                {
                    bfr = new byte[2205];
                    AsyncCallback getData = new AsyncCallback(SockCoderBinServer.SendData);
                    newSock.BeginReceive(bfr, 0, bfr.Length, SocketFlags.None, getData, this);
                    //Начинает асинхронный прием данных из подключенного Socket
                }
                catch (Exception)
                {
                }
            }
            public  byte[] GetRecievedData(IAsyncResult ar)
            {
                int lenToRec = 0;
                try
                {
                    lenToRec = newSock.EndReceive(ar);
                }
                catch { }
                byte[] byteReturn = new byte[lenToRec];
                Array.Copy(bfr, byteReturn, lenToRec);
                return byteReturn;
            }
        }

    }
}
