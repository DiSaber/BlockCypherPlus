using System;

namespace BlockCypherPlus
{
    [Serializable]
    internal class Contact
    {
        public string ContactName { get; }
        public byte[] SharedSecret { get; }

        public Contact(string contactName, byte[] sharedSecret)
        {
            ContactName = contactName;
            SharedSecret = sharedSecret;
        }
    }
}
