using ChatClient.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ChatProgram;
using System.ServiceModel;

namespace ChatClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Step 1: Create an instance of the WCF proxy.   
        // Create a client, construct InstanceContext to handle messages on callback interface.  
        ChatServiceClient client = new ChatServiceClient(new InstanceContext(new CallbackHandler()));

        private User user;

        public MainWindow(User user)
        {
            InitializeComponent();
            this.user = user;           
        }

        private void Send()
        {
            // Step 2: Call the service operations --> client.SendMessage.
            ChatTextBlock.Inlines.Add(new Run { Text = user.UserName + ": " + client.SendMessage(MessageTextBox.Text) });
            // To add a new line each time a message is send
            ChatTextBlock.Inlines.Add(new LineBreak());
            // Clears the messagebox
            MessageTextBox.Text = "";
        }
        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            Send();
        }
        private void SendEnterKey(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Send();
            }
        }
        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            //Step 3: Closing the client gracefully closes the connection and cleans up resources.
            client.Close();
            Close();
        }
    }
    public class CallbackHandler : IChatServiceCallback
    {
        public IAsyncResult BeginMessage(string message, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public string EndMessage(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public string Message(string message)
        {
            return message;
        }
    }
}
