using System.Security.Cryptography;
using System.Text;

namespace RSATextEncrypter;

public class TextEncrypter
{
    public KeyPair Keys => _keys;

    private RSACryptoServiceProvider _provider = new();
    public KeyPair _keys = new();

    public TextEncrypter() => GenerateKeys();

    public KeyPair GenerateKeys()
    {
        _provider = new();
        _keys = new(_provider);
        return _keys;
    }

    public void SetKeys(KeyPair keys)
    {
        _provider.ImportRSAPublicKey(keys.PublicKey, out int bytesPublic);
        _provider.ImportRSAPrivateKey(keys.PrivateKey, out int bytesPrivate);
    }

    public string Encrypt(string raw)
    {
        var data = Encoding.UTF8.GetBytes(raw);
        var encrypted = _provider.Encrypt(data, false);
        return Convert.ToBase64String(encrypted);
    }

    public string Decrypt(string raw)
    {
        var encrypted = Convert.FromBase64String(raw);
        var data = _provider.Decrypt(encrypted, false);
        return Encoding.UTF8.GetString(data);
    }
}
