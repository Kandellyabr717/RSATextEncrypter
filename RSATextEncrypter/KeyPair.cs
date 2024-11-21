using System.Security.Cryptography;

namespace RSATextEncrypter;

public struct KeyPair
{
    public byte[] PublicKey => _publicKey;
    public byte[] PrivateKey => _privateKey;
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

    public KeyPair(string publicKey, string privateKey)
    {
        _publicKey = Convert.FromBase64String(publicKey);
        _privateKey = Convert.FromBase64String(privateKey);
    }

    public override string ToString() => $"{PublicKeyString}\n\n{PrivateKeyString}";
}
