using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace BlockCypherPlus
{
    internal static class Encryption
    {
        public static string Encrypt(string input, string key)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(input);
            byte[] bytes = Encoding.Unicode.GetBytes("70BDGYcJz|xb%31#0n#QizwDq$krwRwUVwUiG!BfiyN!7KofNq");

            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(key, bytes, 10000);
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    input = Convert.ToBase64String(ms.ToArray());
                }
            }
            return input;
        }

        public static string Decrypt(string input, string key)
        {
            input = input.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(input);
            byte[] bytes = Encoding.Unicode.GetBytes("70BDGYcJz|xb%31#0n#QizwDq$krwRwUVwUiG!BfiyN!7KofNq");

            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(key, bytes, 10000);
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    input = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return input;
        }

        public static string Encrypt(string input, byte[] sharedSecret)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(input);
            byte[] bytes = Encoding.Unicode.GetBytes("70BDGYcJz|xb%31#0n#QizwDq$krwRwUVwUiG!BfiyN!7KofNq");

            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(sharedSecret, bytes, 10000);
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    input = Convert.ToBase64String(ms.ToArray());
                }
            }
            return input;
        }

        public static string Decrypt(string input, byte[] sharedSecret)
        {
            input = input.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(input);
            byte[] bytes = Encoding.Unicode.GetBytes("70BDGYcJz|xb%31#0n#QizwDq$krwRwUVwUiG!BfiyN!7KofNq");

            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(sharedSecret, bytes, 10000);
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    input = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return input;
        }
    }
}
