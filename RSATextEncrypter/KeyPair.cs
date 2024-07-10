using System.Security.Cryptography;

namespace RSATextEncrypter
{
    public struct KeyPair
    {
        public byte[] PublicKey
        {
            get => _publicKey;
        }
        public byte[] PrivateKey
        {
            get => _privateKey;
        }
        public string PublicKeyString
        {
            get => Convert.ToBase64String(_publicKey);
        }
        public string PrivateKeyString
        {
            get => Convert.ToBase64String(_privateKey);
        }

        private byte[] _publicKey;
        private byte[] _privateKey;

        public KeyPair(RSACryptoServiceProvider provider)
        {
            _publicKey = provider.ExportRSAPublicKey();
            _privateKey = provider.ExportRSAPrivateKey();
        }

        public override string ToString() =>
            $"public key: {PublicKeyString}\n\nprivate key: {PrivateKeyString}";
    }
}
