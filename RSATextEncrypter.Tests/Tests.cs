namespace RSATextEncrypter.Tests
{
    [TestClass]
    public class Tests
    {
        private void EncryptionTest(string text)
        {
            var encrypter = new TextEncrypter();
            var encrypted = encrypter.EncryptText(text);
            var decrypted = encrypter.DecryptText(encrypted);
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
    }
}
