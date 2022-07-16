using System.Windows;

namespace BlockCypherPlus
{
    public partial class MainWindow : Window
    {
        private void Menu_EncryptButton_Click(object sender, RoutedEventArgs e)
        {
            if (LastScreen != null)
            {
                LastScreen.Visibility = Visibility.Hidden;
            }
            LastScreen = EncryptMessagesScreen;
            LastScreen.Visibility = Visibility.Visible;
        }

        private void Menu_DecryptButton_Click(object sender, RoutedEventArgs e)
        {
            if (LastScreen != null)
            {
                LastScreen.Visibility = Visibility.Hidden;
            }
            LastScreen = DecryptMessagesScreen;
            LastScreen.Visibility = Visibility.Visible;
        }
    }
}
