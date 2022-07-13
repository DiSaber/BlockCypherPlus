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
        private void Contacs_AddContact_Click(object sender, RoutedEventArgs e)
        {
            publicKey = new byte[0];
            privateKey = new byte[0];

            if (LastScreen != null)
            {
                LastScreen.Visibility = Visibility.Hidden;
            }
            LastScreen = AddContactsScreen;
            LastScreen.Visibility = Visibility.Visible;
        }

        private void Contacts_ReceiveCode_Click(object sender, RoutedEventArgs e)
        {
            publicKey = null;

            if (LastScreen != null)
            {
                LastScreen.Visibility = Visibility.Hidden;
            }
            LastScreen = ReceiveKeyScreen;
            LastScreen.Visibility = Visibility.Visible;
        }

        private void ContactsList_Click(object sender, RoutedEventArgs e)
        {
            if (LastScreen != null)
            {
                LastScreen.Visibility = Visibility.Hidden;
            }
            LastScreen = ContactsScreen;
            LastScreen.Visibility = Visibility.Visible;

            AddContacts_Error.Content = "Failed to add contact!";
            AddContacts_Error.Visibility = Visibility.Hidden;
        }
    }
}
