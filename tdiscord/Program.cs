using System;
using Discord;

namespace tdiscord
{
	class TDiscord
	{
		DiscordClient client = new DiscordClient();
		public static void Main(string[] args)
		{
			Console.Write("E-Mail:   ");
			string email = Console.ReadLine();
			Console.Write("Password: ");
			string password = "";
			while (true)
			{
				var key = System.Console.ReadKey(true);
				if (key.Key == ConsoleKey.Enter)
					break;
				//Console.WriteLine("key pressed: " + key.Key);
				if (key.Key == ConsoleKey.Backspace)
				{
					if (password.Length > 0)
					{
						//Console.WriteLine(password + " ==" + password.Length + "=> " + password.Remove(password.Length - 1));
						password = password.Remove(password.Length - 1);
					}
				}
				else
					password += key.KeyChar;
			}
			Console.WriteLine("\nConnecting...");
			if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
			{
				TDiscord td = new TDiscord();
				td.Run(email, password);
			}
			else
				Console.WriteLine("E-mail & password cannot be blank.");
		}
		public void Run(string email, string password)
		{
			client.ExecuteAndWait(async () =>
			{
				await client.Connect(email, password);
				Console.WriteLine("Connected.");
			});
		}
	}
}
