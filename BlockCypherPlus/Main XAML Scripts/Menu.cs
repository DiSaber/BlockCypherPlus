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
        private void Menu_EncryptButton_Click(object sender, RoutedEventArgs e)
        {
            if (LastScreen != null)
            {
                LastScreen.Visibility = Visibility.Hidden;
            }
            LastScreen = EncryptMessagesScreen;
            LastScreen.Visibility = Visibility.Visible;
        }
    }
}
