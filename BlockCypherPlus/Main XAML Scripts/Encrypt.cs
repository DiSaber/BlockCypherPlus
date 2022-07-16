using Newtonsoft.Json;
using System.Windows;

namespace BlockCypherPlus
{
    public partial class MainWindow : Window
    {
        private void Encrypt_CopyToClipboard_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(Encrypt_Output.Text);
        }

        private void Encrypt_Encrypt_Click(object sender, RoutedEventArgs e)
        {
            if (Encrypt_ContactDropdown.SelectedItem != null)
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                foreach (Contact contact in data.Contacts)
                {
                    if (contact.ContactName == Encrypt_ContactDropdown.SelectedItem.ToString())
                    {
                        try
                        {
                            Encrypt_Output.Text = Encryption.Encrypt(JsonConvert.SerializeObject(new MessageContainer(Encrypt_Input.Text)), contact.SharedSecret);
                            return;
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }
            Encrypt_Output.Text = "Message could not be encrypted";
        }
    }
}
