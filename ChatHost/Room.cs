﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ChatProgram;

namespace ChatHost
{
    class Room :  INotifyPropertyChanged
    {
        
        [DataMember]
        public string RoomString { get; set; }
      
        private string _message;
        [DataMember]
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                NotifyPropertyChanged();
            }
        }

        public List<User> UserList { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.  
        // The CallerMemberName attribute that is applied to the optional propertyName  
        // parameter causes the property name of the caller to be substituted as an argument.  
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
