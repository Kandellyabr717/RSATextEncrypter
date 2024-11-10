namespace RSATextEncrypter.Tests
{
    [TestClass]
    public class Tests
    {
        private void EncryptionTest(string text)
        {
            var encrypter = new TextEncrypter();
            var encrypted = encrypter.Encrypt(text);
            var decrypted = encrypter.Decrypt(encrypted);
            Assert.AreEqual(text, decrypted);
        }

        [TestMethod]
        public void EncryptionTests()
        {
            EncryptionTest("Ajefimakpfjiwj[mJFIOamefppf9o304-9-fpikmq23jpcmw");
            EncryptionTest("AEFMIONAEIOGNKOAEFIOAHpamfkphwoafvjksmfvkorjf");
            EncryptionTest("pJQPIFJ#Ifo--r0=123ldqx[q/[2op-efkml,v;[lpkf");
            EncryptionTest("(_!U(fjpqkp[efo0-ifoj2konfk;,d[lvlp=-=1lpfniqOKifj)");
            EncryptionTest("Q+UFI)EJFo0-9qi3rf9jf1293r2fnnvm=23=09348npjaoef");
        }

        private void KeysChangeTest(string text)
        {
            var encrypter = new TextEncrypter();
            var keys = encrypter.GenerateKeys();
            var encrypted = encrypter.Encrypt(text);
            encrypter = new TextEncrypter();
            encrypter.SetKeys(keys);
            var decrypted = encrypter.Decrypt(encrypted);
            Assert.AreEqual(text, decrypted);
        }

        [TestMethod]
        public void KeysChangeTests()
        {
            KeysChangeTest("Ajefimakpfjiwj[mJFIOamefppf9o304-9-fpikmq23jpcmw");
            KeysChangeTest("AEFMIONAEIOGNKOAEFIOAHpamfkphwoafvjksmfvkorjf");
            KeysChangeTest("pJQPIFJ#Ifo--r0=123ldqx[q/[2op-efkml,v;[lpkf");
            KeysChangeTest("(_!U(fjpqkp[efo0-ifoj2konfk;,d[lvlp=-=1lpfniqOKifj)");
            KeysChangeTest("Q+UFI)EJFo0-9qi3rf9jf1293r2fnnvm=23=09348npjaoef");
        }
    }
}
