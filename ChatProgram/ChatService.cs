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
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class ChatService : IChatService
    {
        IChatServiceDuplexCallback Callback = null;

        public ChatService()
        {
            Callback = OperationContext.Current.GetCallbackChannel<IChatServiceDuplexCallback>();
        }
        public string SendMessage(string message)
        {
            return message;
        }

        public string ReceiveMessage(string message)
        {
            return message;
        }

        public void Connect(string UserName, string IpAdress)
        {
            
        }
       
        public void Disconnect(string UserName)
        {
            Environment.Exit(1);
        }

        //IChatServiceDuplexCallback Callback
        //{
        //    get
        //    {
        //        return OperationContext.Current.GetCallbackChannel<IChatServiceDuplexCallback>();
        //    }
        //}
    }
}

