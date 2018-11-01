using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ChatProgram;

namespace ChatProgram
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ChatService" in both code and config file together.
    public class ChatService : IChatService
    {
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

        public void SendMessage(string message,ref string roomstring )
        {

            roomstring += message;
        }

        
    }
}
