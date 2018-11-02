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
    public class ChatService : IChatService, INotifyPropertyChanged

       

    {

        Room room = new Room();

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

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

        public void SendMessage(string message)
        {
            room.RoomString += message + "\n";
            NotifyPropertyChanged();

        }

        
        /*public void SendMessage(string message,ref string roomstring )
{

   roomstring += message;
}*/


    }
}

