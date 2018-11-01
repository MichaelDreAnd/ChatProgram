using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatProgram;

namespace ChatHost
{
    class Room :  INotifyPropertyChanged
    {

        public string RoomString { get; set; }

        public string Message { get; set; }

        public List<User> UserList { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
