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
        private void FirstTime_PasswordButton_Click(object sender, RoutedEventArgs e)
        {
            if (FirstTime_PasswordField.Password == FirstTime_PasswordFieldConfirm.Password)
            {
                sessionKey = FirstTime_PasswordField.Password;
                data = new ProgramData();
                SaveData();

                if (LastScreen != null)
                {
                    LastScreen.Visibility = Visibility.Hidden;
                }
                LastScreen = MenuScreen;
                LastScreen.Visibility = Visibility.Visible;
            }
            else
            {
                FirstTime_Error.Visibility = Visibility.Visible;
            }
        }
    }
}
