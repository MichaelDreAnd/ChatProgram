using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
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

namespace ChatHost
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        // Step 1 of the address configuration procedure: Create a URI to serve as the base address.
        static Uri baseAddress = new Uri("http://localhost:8000/ChatProgram/ChatService");

        // Step 2 of the hosting procedure: Create ServiceHost
        static ServiceHost selfHost = new ServiceHost(typeof(ChatService), baseAddress);
        public MainWindow()
        {
            InitializeComponent();
           
           
            try
            {
                // Step 3 of the hosting procedure: Add a service endpoint.
                selfHost.AddServiceEndpoint(typeof(IChatService), new WSHttpBinding(), "ChatService");

                // Step 4 of the hosting procedure: Enable metadata exchange.
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                selfHost.Description.Behaviors.Add(smb);

                // Step 5 of the hosting procedure: Start the service.
                selfHost.Open();

            }
            catch (CommunicationException ce)
            {
                //MessageBox.Show("An exception occurred: {0}", ce.Message);
                selfHost.Abort();
            }
        }

        private void ShutDownButton_Click(object sender, RoutedEventArgs e)
        {
            // Close the ServiceHostBase to shutdown the service.
            selfHost.Close();
            Close();
        }
    }
}
