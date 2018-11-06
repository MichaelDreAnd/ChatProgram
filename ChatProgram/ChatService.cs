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
        //Dictionary to callback messages from each client
        Dictionary<Room, IChatServiceDuplexCallback> clients =
             new Dictionary<Room, IChatServiceDuplexCallback>();
        public IChatServiceDuplexCallback Callback
        {
            get
            {
                return OperationContext.Current.GetCallbackChannel<IChatServiceDuplexCallback>();
            }
        }

        object syncObj = new object();
        public void SendMessage(Room msg)
        {
            lock (syncObj)
            {
                clients.Add(msg, Callback);
                // So the message shown on each client does not repeat more than once
                if (clients.Count > 2)
                {
                    clients.Remove(msg);
                }
                
                foreach (IChatServiceDuplexCallback callback in clients.Values)
                {
                    callback.Message(msg);
                }
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

