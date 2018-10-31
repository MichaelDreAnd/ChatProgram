using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;
using 

namespace ChatProgram
{
    [DataContract]
    public class User
    {
        public string Name { get; set; }

        public string IpAdress { get; set; }


    }
}
