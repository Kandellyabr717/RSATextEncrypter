namespace RSATextEncrypter.CLI;

public class ConsoleForm
{
    private TextEncrypter _encrypter;
    private Dictionary<string, Action<string[]>> _commands;

    public ConsoleForm(TextEncrypter encrypter)
    {
        _encrypter = encrypter;
        _commands = new()
        {
            { "genkeys", args =>
            {
                _encrypter.GenerateKeys();
                Console.WriteLine();
            } },
            { "showkeys", args => Console.WriteLine("\n" + _encrypter.Keys + "\n") },
            { "setkeys", args =>
            {
                _encrypter.SetKeys(new KeyPair(args[0], args[1]));
                Console.WriteLine();
            } },
            { "enc", args => Console.WriteLine("\n" + _encrypter.Encrypt(args[0]) + "\n") },
            { "dec", args => Console.WriteLine("\n" + _encrypter.Decrypt(args[0]) + "\n") },
            { "exit", args => Program.Exit() },
        };
    }

    public void WaitForCommand()
    {
        try
        {
            TryExecute(Console.ReadLine() ?? "");
        }
        catch (ArgumentException)
        {
            return;
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("\nIncorrect argument count\n");
        }
        catch (Exception exception)
        {
            Console.WriteLine("\n" + exception.Message + "\n");
        }
    }

    private void TryExecute(string input)
    {
        var array = input
            .Split(' ')
            .Where(x => x != " " && x != "")
            .ToArray();
        if (array.Length == 0) throw new ArgumentException("Empty input");
        if (!_commands.ContainsKey(array[0])) throw new Exception("Unknown command");

        _commands[array[0]](array[1..^0]);
    }
}
