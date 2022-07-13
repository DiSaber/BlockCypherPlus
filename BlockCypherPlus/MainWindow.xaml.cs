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

        private void SaveData()
        {
            if (!Directory.Exists(userFolderPath))
            {
                Directory.CreateDirectory(userFolderPath);
            }

            using (StreamWriter sw = File.CreateText(userDataPath))
            {
                sw.WriteLine(Encryption.Encrypt(JsonSerializer.Serialize(data), sessionKey));
            }
        }

        private void LoadData()
        {
            string cryptoData = "";
            using (StreamReader sr = File.OpenText(userDataPath))
            {
                cryptoData = sr.ReadToEnd();
            }
            data = JsonSerializer.Deserialize<ProgramData>(Encryption.Decrypt(cryptoData, sessionKey));
        }

        private void FirstTime_PasswordButton_Click(object sender, RoutedEventArgs e)
        {
            if (FirstTime_PasswordField.Password == FirstTime_PasswordFieldConfirm.Password)
            {
                sessionKey = FirstTime_PasswordField.Password;
                data = new ProgramData();
                SaveData();
            } 
            else
            {
                FirstTime_Error.Visibility = Visibility.Visible;
            }
        }

        private void Login_PasswordButton_Click(object sender, RoutedEventArgs e)
        {
            sessionKey = Login_PasswordField.Password;
            try
            {
                LoadData();
            } catch
            {
                Login_Error.Visibility = Visibility.Visible;
            }
        }
    }
}
