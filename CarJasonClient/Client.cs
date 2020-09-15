using ModelLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace CarJasonClient
{
    public class Client
    {
        public void Start()
        {
            Car tesla = new Car() { Model = "Tesla", Color = "Blue", RegistrationNo = "abc123" };
            try
            {
                TcpClient socket = new TcpClient("localhost", 10001);
                using (socket)
                {
                    NetworkStream ns = socket.GetStream();
                    StreamReader streamReader = new StreamReader(ns);
                    StreamWriter streamWriter = new StreamWriter(ns);

                    try
                    {
                        //// Word sent to the server
                        //string LineToBeSentToServer = Console.ReadLine();
                        //// Send the line to the server
                        //streamWriter.WriteLine(LineToBeSentToServer);

                        streamWriter.WriteLine(tesla);
                        // flush the streamWriter
                        streamWriter.Flush();

                        string line = streamReader.ReadLine();
                        Console.WriteLine(line);
                    }
                    catch (IOException)
                    {
                        Console.WriteLine("Connection to the server cannot be made, is it running?");
                        return;
                    }

                }
            }
            catch (SocketException)
            {
                Console.WriteLine("No connection could be made to the server.");
                return;
            }
        }
    }
}
