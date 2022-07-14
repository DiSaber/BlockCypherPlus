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
using OpenQuantumSafe;

namespace BlockCypherPlus
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Canvas? LastScreen = null;

        private ProgramData? data = null;
        private string sessionKey = "";
        private readonly static string userFolderPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BlockCypher");
        private readonly string userDataPath = System.IO.Path.Combine(userFolderPath, "BlockCypher.dat");

        public MainWindow()
        {
            InitializeComponent();
            if (File.Exists(userDataPath))
            {
                LastScreen = LoginScreen;
                LastScreen.Visibility = Visibility.Visible;
            } 
            else
            {
                LoginScreen.Visibility = Visibility.Hidden;
                LastScreen = FirstTimeScreen;
                LastScreen.Visibility = Visibility.Visible;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (LastScreen != null)
            {
                LastScreen.Visibility = Visibility.Hidden;
            }
            LastScreen = MenuScreen;
            LastScreen.Visibility = Visibility.Visible;

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
            Encrypt_Input.Text = "";
            Encrypt_Output.Text = "";

            Decrypt_Input.Text = "";
            Decrypt_Output.Text = "";
        }

        private byte[]? publicKey = null;
        private byte[]? privateKey = null;
        private byte[]? sharedSecret = null;

        private void AddContacts_CopyPublicKey_Click(object sender, RoutedEventArgs e)
        {
            if (publicKey != null)
            {
                Clipboard.SetText(Convert.ToBase64String(publicKey));
            }
        }

        private void AddContacts_AddContact_Click(object sender, RoutedEventArgs e)
        {
            if (!data.Contacts.Exists(contact => contact.ContactName == AddContacts_Name.Text))
            {
                try
                {
                    byte[] cipherText = Convert.FromBase64String(AddContacts_CipherTextInput.Text);

                    using (KEM kem = new KEM("Kyber1024"))
                    {
                        kem.decaps(out sharedSecret, cipherText, privateKey);
                    }

                    data.Contacts.Add(new Contact(AddContacts_Name.Text, sharedSecret));
                    publicKey = null;
                    privateKey = null;
                    sharedSecret = null;

                    SaveData();
                    SetupContacts();
                    ToContactsScreen();
                }
                catch
                {
                    AddContacts_Error.Content = "Failed to add contact!";
                    AddContacts_Error.Visibility = Visibility.Visible;
                }
            } else
            {
                AddContacts_Error.Content = "Contact name already exists!";
                AddContacts_Error.Visibility = Visibility.Visible;
            }
        }

        private void ReceiveKey_CopyCipherText_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ReceiveKey_PublicKeyInput.Text.Length > 0)
                {
                    publicKey = Convert.FromBase64String(ReceiveKey_PublicKeyInput.Text);
                    byte[] cipherText;

                    using (KEM kem = new KEM("Kyber1024"))
                    {
                        kem.encaps(out cipherText, out sharedSecret, publicKey);
                    }

                    Clipboard.SetText(Convert.ToBase64String(cipherText));
                }
                else
                {
                    ReceiveKey_Error.Content = "Failed to add contact!";
                    ReceiveKey_Error.Visibility = Visibility.Visible;
                }
            } 
            catch
            {
                ReceiveKey_Error.Content = "Failed to add contact!";
                ReceiveKey_Error.Visibility = Visibility.Visible;
            }
        }

        private void ReceiveKey_AddContact_Click(object sender, RoutedEventArgs e)
        {
            if (!data.Contacts.Exists(contact => contact.ContactName == ReceiveKey_Name.Text))
            {
                if (sharedSecret != null)
                {
                    data.Contacts.Add(new Contact(ReceiveKey_Name.Text, sharedSecret));
                    SaveData();
                    SetupContacts();
                    ToContactsScreen();
                } 
                else
                {
                    ReceiveKey_Error.Content = "Failed to add contact!";
                    ReceiveKey_Error.Visibility = Visibility.Visible;
                }
            }
            else
            {
                ReceiveKey_Error.Content = "Contact name already exists!";
                ReceiveKey_Error.Visibility = Visibility.Visible;
            }
        }
    }
}
