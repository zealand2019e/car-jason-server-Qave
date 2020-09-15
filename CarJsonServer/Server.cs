using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CarJasonClient
{
    public class Server
    {
        public void Start()
        {
            TcpListener listener = new TcpListener(IPAddress.Loopback, 10001);
            listener.Start();
            Console.WriteLine("Listening for clients");

            while (true)
            {
                TcpClient Clientsocket = listener.AcceptTcpClient();
                Console.WriteLine("Client found");

                // For every new client, run a new task so they run simultaneously
                Task.Run(() =>
                {
                    // create a temp socket for the new client
                    TcpClient tempSocket = Clientsocket;
                    DoClient(tempSocket);
                });

            }
        }
        public void DoClient(TcpClient socket)
        {
            using (socket)
            {
                NetworkStream ns = socket.GetStream();
                StreamReader streamReader = new StreamReader(ns);
                StreamWriter streamWriter = new StreamWriter(ns);
                while (true)
                {
                    // Word recieved from the client
                    try
                    {
                        // Word read from the client
                        string line = streamReader.ReadLine();
                        // Write the line to the server that is read from the client
                        Console.WriteLine(line);
                        streamWriter.Flush();
                    }
                    catch (IOException)
                    {
                        socket.Dispose();
                        Console.WriteLine("Client disconnected");
                        return;
                    }
                }
            }
        }
    }
}
