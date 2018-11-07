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
using System.Windows.Threading;

namespace ChatClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IChatServiceDuplexCallback, IChatServiceCallback
    {
        //Step 1: Create an instance of the WCF proxy.   
        ChatServiceClient proxy = null;
        Room localClient = null;
        private Room user;
        
        //ListBoxItem for each online client for adding and removing clients when they join or sign out
        Dictionary<string, Room> OnlineClients =
                      new Dictionary<string, Room>();

        public MainWindow(Room user)
        {
            InitializeComponent();
            this.user = user;
            User_label.Content = "User: " + user.UserName;
            WSDualHttpBinding binding = new WSDualHttpBinding();
            EndpointAddress endptadr = new EndpointAddress("http://localhost:8000/ChatProgram/ChatService/ChatHost");
            binding.ClientBaseAddress = new Uri("http://localhost:8000/myChatClient/");

            // Create Room instance to store client userName and Message
            this.localClient = new Room();
            this.localClient.UserName = user.UserName;
            this.localClient.Message = ChatTextBlock.Text;

            // Adding client to OnlineClients list
            OnlineClients.Add(localClient.UserName, user);

            //Construct InstanceContext to handle messages on callback interface.
            InstanceContext context = new InstanceContext(this);
            proxy = new ChatServiceClient(context);

            //Show client joined on UI
            proxy.SendMessageAsync(localClient);
            // Show timestamp on UI
            ChatTextBlock.Text = "Connected at: " + DateTime.Now;
            // To add a new line
            ChatTextBlock.Inlines.Add(new LineBreak());
            //proxy.Open();
        }

        private void Send()
        {
            //Create message, assign its properties            
            Room msg = new ChatProgram.Room();
            msg.UserName = this.localClient.UserName.ToString();
            msg.Message = MessageTextBox.Text;
            
            // Step 2: Call the service operation
            proxy.SendMessageAsync(msg);
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
            proxy.Close();
            Close(); 
        }

        public void Message(Room message)
        {
            // Show message on UI
            ChatTextBlock.Inlines.Add(new Run { Text = message.UserName + ": " + message.Message });
            // To add a new line each time a message is send
            ChatTextBlock.Inlines.Add(new LineBreak());
            // Clears the messagebox
            MessageTextBox.Text = "";
        }

        public IAsyncResult BeginMessage(Room client, AsyncCallback callback, object asyncState)
        {
            //From IChatServiceCallback, has to be there or else the proxy InstanceContext won't work
            throw new NotImplementedException();
        }

        public void EndMessage(IAsyncResult result)
        {
            //From IChatServiceCallback, has to be there or else the proxy InstanceContext won't work
            throw new NotImplementedException();
        }
    }
}
