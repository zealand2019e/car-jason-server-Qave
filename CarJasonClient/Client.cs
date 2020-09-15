using ModelLib;
using Newtonsoft.Json;
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
            AutoSale dealer = new AutoSale() {Name="Kasper", Address="Roskilde", Cars = new List<Car>() };
            dealer.Cars.Add(new Car() { Model = "Tesla", Color = "Blue", RegistrationNo = "abc123" });
            dealer.Cars.Add(new Car() { Model = "Ford", Color = "Black", RegistrationNo = "321cba" });
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

                        //// Plain Text
                        //// Send the car in plaintext to the server
                        //streamWriter.WriteLine(dealer);

                        //// JSON Format
                        //// serialize the dealer AutoSale object "Dealer" into JSON format, and send it to the server
                        //streamWriter.WriteLine(JsonConvert.SerializeObject(dealer));

                        //XML Format


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
