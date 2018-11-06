using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace ChatProgram
{
    [DataContract]
    public class Room
    {
        private string _message;
    
        [DataMember]
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
            }
        }
        private string _userName;

        [DataMember]
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
            }
        }
    }
}
