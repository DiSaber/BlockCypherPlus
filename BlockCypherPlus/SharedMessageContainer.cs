namespace BlockCypherPlus
{
    internal class SharedMessageContainer
    {
        public string Ciphertext { get; }
        public byte[] IV { get; }

        public SharedMessageContainer(string ciphertext, byte[] iv)
        {
            Ciphertext = ciphertext;
            IV = iv;
        }
    }
}
