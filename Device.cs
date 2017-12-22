using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace ClassLibrary1
{
    // Тип устройства, состояние, 2 метода
    
    public class Device : ISwitchContract
    {
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);


        public string Name { get; set; }
        private int a = 1;
        public bool State{ get; set; }
        public void SwitchOn()
        {
            State = true;
            if (a==1)
            {
                socket.Connect("10.3.6.80", 80);
                a++;
            }
            
            string message = "$1";
            byte[] bytes = Encoding.UTF8.GetBytes(message);
            socket.Send(bytes);
           
        }
        public void SwitchOff() 
        {
            State = false ;
            //socket.Connect("10.3.6.80", 80);
            string message = "$2";
            byte[] bytes = Encoding.UTF8.GetBytes(message);
            socket.Send(bytes);
        
            //socket.Disconnect(true);
        }
    
    }
}
