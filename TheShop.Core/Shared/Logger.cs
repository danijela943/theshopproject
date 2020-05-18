using System;
using TheShop.Core.Interfaces;

namespace TheShop.Core
{
	public class ConsoleLogger<T> : ILogger<T>
	{
		public void Info(string message)
		{
			Console.WriteLine("Info: " + message);
		}

		public void Error(string message)
		{
			Console.WriteLine("Error: " + message);
		}

		public void Debug(string message)
		{
			Console.WriteLine("Debug: " + message);
		}
	}
}