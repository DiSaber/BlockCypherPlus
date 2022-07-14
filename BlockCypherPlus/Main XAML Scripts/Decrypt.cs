using System;
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
using Newtonsoft.Json;

namespace BlockCypherPlus
{
    public partial class MainWindow : Window
    {
        private void Decrypt_DecryptButton_Click(object sender, RoutedEventArgs e)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            foreach (Contact contact in data.Contacts)
            {
                try
                {
                    Decrypt_Output.Text = $"Message Author: {contact.ContactName}\n\n{JsonConvert.DeserializeObject<MessageContainer>(Encryption.Decrypt(Decrypt_Input.Text, contact.SharedSecret)).Message}";
                    return;
                }
                catch
                {
                    continue;
                }
            }
            Decrypt_Output.Text = "Message could not be decrypted";
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }
    }
}
