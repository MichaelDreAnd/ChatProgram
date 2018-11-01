using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ChatProgram
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IChatService" in both code and config file together.
    [ServiceContract]
    public interface IChatService
    {
        
        [OperationContract]
        void Connect(string UserName, string IpAdress);

        [OperationContract]
        void Disconnect(string UserName);

        [OperationContract]
        void SendMessage(string message);

        /*[OperationContract]
        void SendMessage(string message, ref string roomstring);*/

        [OperationContract]
        void ReceiveMessage(string message);

    }
}
