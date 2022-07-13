using System;
using System.Text.Json;
using System.IO;
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

namespace BlockCypherPlus
{
    public partial class MainWindow : Window
    {
        private void Login_PasswordButton_Click(object sender, RoutedEventArgs e)
        {
            if (LoginScreen.Visibility == Visibility.Visible)
            {
                sessionKey = Login_PasswordField.Password;
                try
                {
                    LoadData();
                    SetupContacts();

                    if (LastScreen != null)
                    {
                        LastScreen.Visibility = Visibility.Hidden;
                    }
                    LastScreen = MenuScreen;
                    LastScreen.Visibility = Visibility.Visible;
                }
                catch
                {
                    Login_Error.Visibility = Visibility.Visible;
                }
            }
        }

        private void Login_PasswordField_KeyDown(object sender, KeyEventArgs e)
        {
            if (LoginScreen.Visibility == Visibility.Visible && (e.Key == Key.Return || e.Key == Key.Enter))
            {
                sessionKey = Login_PasswordField.Password;
                try
                {
                    LoadData();
                    SetupContacts();

                    if (LastScreen != null)
                    {
                        LastScreen.Visibility = Visibility.Hidden;
                    }
                    LastScreen = MenuScreen;
                    LastScreen.Visibility = Visibility.Visible;
                }
                catch
                {
                    Login_Error.Visibility = Visibility.Visible;
                }
            }
        }
    }
}
