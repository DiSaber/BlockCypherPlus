using Newtonsoft.Json;
using System.Windows;

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
