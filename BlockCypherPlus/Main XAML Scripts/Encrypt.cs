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
