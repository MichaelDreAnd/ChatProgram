using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ChatHost
{
    class MessageViewModel : INotifyPropertyChanged
    {

        
        private string _messageInput;

        public string MessageInput
        {
            get { return _messageInput; }
            set
            {
                _messageInput = value;
                NotifyPropertyChanged();
            }
        }

        private string _sendMessage;

        public string SendMessage
        {
            get { return _sendMessage; }
            set
            {
                _sendMessage = value;
                NotifyPropertyChanged();
            }
        }

        private string _listMessages;

        public string ListMessages
        {
            get { return _listMessages; }
            set
            {
                _listMessages = value;
                NotifyPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
