using OpenQuantumSafe;
using System.Windows;

namespace BlockCypherPlus
{
    public partial class MainWindow : Window
    {
        private void Contacs_AddContact_Click(object sender, RoutedEventArgs e)
        {
            using (KEM kem = new KEM("Kyber1024"))
            {
                kem.keypair(out publicKey, out privateKey);
            }

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

        private void Contacts_RemoveContact_Click(object sender, RoutedEventArgs e)
        {
            if (Encrypt_ContactDropdown.SelectedItem != null)
            {
                foreach (Contact contact in data.Contacts)
                {
                    if (contact.ContactName == Encrypt_ContactDropdown.SelectedItem.ToString())
                    {
                        data.Contacts.Remove(contact);
                        SaveData();
                        SetupContacts();
                        break;
                    }
                }
            }
        }

        private void ContactsList_Click(object sender, RoutedEventArgs e)
        {
            ToContactsScreen();
        }

        private void ToContactsScreen()
        {
            if (LastScreen != null)
            {
                LastScreen.Visibility = Visibility.Hidden;
            }
            LastScreen = ContactsScreen;
            LastScreen.Visibility = Visibility.Visible;

            AddContacts_Error.Content = "Failed to add contact!";
            AddContacts_Error.Visibility = Visibility.Hidden;

            ReceiveKey_Error.Content = "Failed to add contact!";
            ReceiveKey_Error.Visibility = Visibility.Hidden;


            if (data.Contacts.Count > 0)
            {
                Encrypt_ContactDropdown.SelectedIndex = 0;
                Contacts_ContactsDropdown.SelectedIndex = 0;
            }
            else
            {
                Encrypt_ContactDropdown.SelectedIndex = -1;
                Contacts_ContactsDropdown.SelectedIndex = -1;
            }

            AddContacts_CipherTextInput.Text = "";
            AddContacts_Name.Text = "";
            ReceiveKey_Name.Text = "";
            ReceiveKey_PublicKeyInput.Text = "";
        }
    }
}
