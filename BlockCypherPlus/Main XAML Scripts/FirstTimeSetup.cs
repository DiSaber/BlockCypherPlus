using System.Windows;

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
