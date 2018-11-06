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
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple,
    UseSynchronizationContext = false)]
    public class ChatService : IChatService
    {
        private static readonly object syncObj = new object();
        //Dictionary<Room, IChatServiceDuplexCallback> clients = new Dictionary<Room, IChatServiceDuplexCallback>();
        public IChatServiceDuplexCallback Callback
        {
            get
            {
                return OperationContext.Current.GetCallbackChannel<IChatServiceDuplexCallback>();
            }
        }

        public void SendMessage(Room client)
        {
            lock (syncObj)
            {
                Callback.Message(client);
            }
        }

        public void ReceiveMessage(string message)
        {

        }

        public void Connect(string UserName, string IpAdress)
        {
            
        }
       
        public void Disconnect(string UserName)
        {
            Environment.Exit(1);
        }
    }
}

