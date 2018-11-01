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

namespace ChatHost
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MessageViewModel messageViewModel = new MessageViewModel();
        public string text;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = messageViewModel;
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            List<string> test = new List<string>();
            test.Add(text);
            foreach (var item in test)
            {
                ChatTextBlock.Text = item;
            }
            
        }

        private void MessageTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            text = messageViewModel.MessageInput;
        }
    }
}
