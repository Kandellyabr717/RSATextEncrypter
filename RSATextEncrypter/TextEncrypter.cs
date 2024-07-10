using System.Security.Cryptography;
using System.Text;

namespace RSATextEncrypter
{
    public class TextEncrypter
    {
        public KeyPair Keys
        {
            get => _keys;
        }

        private RSACryptoServiceProvider _provider = new();
        private KeyPair _keys;

        public TextEncrypter() => GenerateKeys();

        public void GenerateKeys() => _keys = new KeyPair(_provider);

        public string EncryptText(string raw)
        {
            _provider.ImportRSAPublicKey(_keys.PublicKey, out int bytesRead);
            var data = Encoding.UTF8.GetBytes(raw);
            var encrypted = _provider.Encrypt(data, false);
            return Convert.ToBase64String(encrypted);
        }

        public string DecryptText(string raw)
        {
            _provider.ImportRSAPrivateKey(_keys.PrivateKey, out int bytesRead);
            var encrypted = Convert.FromBase64String(raw);
            var data = _provider.Decrypt(encrypted, false);
            return Encoding.UTF8.GetString(data);
        }
    }
}
