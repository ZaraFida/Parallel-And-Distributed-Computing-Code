﻿using System;
using System.Net.Sockets;
using System.Text;
class Client
{
    static void Main()
    {
      
            var c = new TcpClient("10.10.20.18", 5000);
            var ns = c.GetStream();
            Console.Write("Enter file Name:");
            string name = Console.ReadLine();
            ns.Write(Encoding.UTF8.GetBytes(name));
            byte[] buf= new byte[8192];
            using var fs = new FileStream("Received_" + name, FileMode.Create);
            int bytes;
            while((bytes = ns.Read(buf))>0)fs.Write(buf, 0, bytes);
            Console.WriteLine($"File saved as Received_{name}");
            ns.Close();
            c.Close();
        
    }
}
