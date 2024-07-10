namespace RSATextEncrypter.CLI
{
    public static class Program
    {
        private static void Main()
        {
            var form = new ConsoleForm(new TextEncrypter());
            while (true) form.WaitForCommand();
        }
    }
}
