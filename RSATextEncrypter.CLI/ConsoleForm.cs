namespace RSATextEncrypter.CLI
{
    public class ConsoleForm
    {
        private TextEncrypter _encrypter;
        private Dictionary<string, Action<string>> _commands;

        public ConsoleForm(TextEncrypter encrypter)
        {
            _encrypter = encrypter;
            _commands = new()
            {
                {"genkeys", x => _encrypter.GenerateKeys()},
                {"keys", x => Console.WriteLine(_encrypter.Keys)},
                {"enc", x => Console.WriteLine(_encrypter.EncryptText(x))},
                {"dec", x => Console.WriteLine(_encrypter.DecryptText(x))},
            };
        }

        public void WaitForCommand()
        {
            var input = Console.ReadLine() ?? "";
            try
            {
                (var command, var arg) = ParseCommand(input);
                command(arg);
            }
            catch
            {
                return;
            }
        }

        public (Action<string> command, string arg) ParseCommand(string command)
        {
            var splited = command.Split(' ');
            if (splited.Length == 1) return (_commands[splited[0]], "");
            else if (splited.Length == 2) return (_commands[splited[0]], splited[1]);
            else throw new ArgumentException("Неверная команда");
        }
    }
}
