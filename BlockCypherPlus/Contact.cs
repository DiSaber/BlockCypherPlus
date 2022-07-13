using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
