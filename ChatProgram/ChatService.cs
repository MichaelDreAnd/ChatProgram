using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ChatProgram;


namespace ChatProgram
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ChatService" in both code and config file together.
    public class ChatService : IChatService
    {
        static Room room = new Room();
        public void Connect(string UserName, string IpAdress)
        {
            
        }
       
        public void Disconnect(string UserName)
        {
            Environment.Exit(1);
        }

        public void ReceiveMessage(string message)
        {
            
        }

        public string SendMessage(string message)
        {
            return message;
            //room.RoomString += message;
            //return room.Message = room.RoomString;
        }

        
        /*public void SendMessage(string message,ref string roomstring )
        {

        roomstring += message;
        }*/


    }
}

