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
using System.Windows.Shapes;
using ChatProgram;

namespace ChatClient
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        Room user = new Room();
        public Login()
        {
            InitializeComponent();
        }
        private void SignIn()
        {
            user.UserName = UsernameTextBox.Text;
            MainWindow mw = new MainWindow(user);
            mw.Show();
            // Close login screen
            Close();
        }
        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            SignIn();
        }
        private void SignInEnterKey(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SignIn();
            }
        }
    }
}
  