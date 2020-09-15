using System;

namespace CarJasonClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Client client = new Client();
            client.Start();
        }
    }
}
