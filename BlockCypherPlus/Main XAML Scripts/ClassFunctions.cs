﻿using Newtonsoft.Json;
using System.IO;
using System.Windows;

namespace BlockCypherPlus
{
    public partial class MainWindow : Window
    {
        private void SaveData()
        {
            if (!Directory.Exists(userFolderPath))
            {
                Directory.CreateDirectory(userFolderPath);
            }

            using (StreamWriter sw = File.CreateText(userDataPath))
            {
                sw.WriteLine(Encryption.Encrypt(JsonConvert.SerializeObject(data), sessionKey));
            }
        }

        private void LoadData()
        {
            string cryptoData = "";
            using (StreamReader sr = File.OpenText(userDataPath))
            {
                cryptoData = sr.ReadToEnd();
            }
            data = JsonConvert.DeserializeObject<ProgramData>(Encryption.Decrypt(cryptoData, sessionKey));
        }

        private void SetupContacts()
        {
            Encrypt_ContactDropdown.Items.Clear();
            Contacts_ContactsDropdown.Items.Clear();

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            foreach (Contact contact in data.Contacts)
            {
                Encrypt_ContactDropdown.Items.Add(contact.ContactName);
                Contacts_ContactsDropdown.Items.Add(contact.ContactName);
            }
#pragma warning restore CS8602 // Dereference of a possibly null reference.

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
        }
    }
}
