using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockCypherPlus
{
    internal class MessageContainer
    {
        public string Message { get; }

        public MessageContainer(string message)
        {
            Message = message;
        }
    }
}
