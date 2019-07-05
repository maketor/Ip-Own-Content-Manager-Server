using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Mi_Ip_Global_Servidor_Content_Manager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = GetGLobalIP();
            textBox1.Text = LocalServer();
        }

        static string LocalServer()
        {
           
            return "https://acstuff.ru/s/q:race/online/join?ip="+GetGLobalIP()+"&httpPort=8081";
        }

        public static string GetGLobalIP()
        {
            return new WebClient().DownloadString("http://icanhazip.com");
           
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}
