using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ChatProgram
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IChatService" in both code and config file together.
    [ServiceContract(CallbackContract = typeof(IChatServiceDuplexCallback), SessionMode =SessionMode.Required)]
    public interface IChatService
    {
        
        [OperationContract(IsOneWay = true)]
        void Connect(string UserName, string IpAdress);

        [OperationContract(IsOneWay = true)]
        void Disconnect(string UserName);

        [OperationContract(IsOneWay = true)]
        void SendMessage(Room client);

        [OperationContract(IsOneWay = true)]
        void ReceiveMessage(string message);

    }
    public interface IChatServiceDuplexCallback
    {
        [OperationContract(IsOneWay = true)]
        void Message(Room client);
    }
}
