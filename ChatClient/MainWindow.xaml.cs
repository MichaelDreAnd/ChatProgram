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

namespace ChatClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Step 1: Create an instance of the WCF proxy.
        ChatServiceClient client = new ChatServiceClient();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = client;
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            // Step 2: Call the service operations.
            client.SendMessage(MessageTextBox.Text);
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            //Step 3: Closing the client gracefully closes the connection and cleans up resources.
            client.Close();
            Close();
        }
    }
}
