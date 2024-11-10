namespace RSATextEncrypter.CLI;

public static class Program
{
	private static bool _runnig = true;

	private static void Main()
	{
		var form = new ConsoleForm(new TextEncrypter());
		while (_runnig) form.WaitForCommand();
	}

	public static void Exit() => _runnig = false;
}
