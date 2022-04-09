using System;
using System.Threading;

namespace PracticeApp
{
	internal class Program
	{
		static void Main(string[] args)
		{
			PlayerManager playerManager = new PlayerManager();
			playerManager.PlayerMenu();
			
			Console.ReadKey();
		}
	}
}
