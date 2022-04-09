using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticeApp
{
	public class PlayerManager :IPlayerManager
	{
		public List<Player> Players { get; set; }
		DiceGame game = new DiceGame();

		public PlayerManager()
		{
			Players = new List<Player>();
		}

		public void AddPlayer(String playerName)
		{
			Player player = new Player(playerName); //creates object of player
			Players.Add(player); //Adds a player to the List
		}

		public void DeletePlayer(String playername)
		{
			int index = 0;
			foreach (Player player in Players)
			{
				if (player._name == playername)
				{
					index = Players.IndexOf(player);
				}	
			}
			Players.RemoveAt(index);
		}

		public int checkPlayerList()
		{
			return Players.Count;
		}

		public void PlayerMenu()
		{
			bool finished = false;
			string answer;
			Console.WriteLine("Would you like to add a player or Quit? Yes (y), No (n), Quit (q)");
			answer = Console.ReadLine();
			while (!finished)
			{
				switch (answer)
				{
					case "y":
						Console.WriteLine("Enter a players name");
						AddPlayer(Console.ReadLine());
						answer = null;
						break;
					case "n":
						if (checkPlayerList() > 0 && checkPlayerList() < 2)
						{
							AddPlayer("Computer");
							finished = true;
							answer = null;
						}
						else if (checkPlayerList() <= 1)
						{
							Console.WriteLine("You must have more than 1 player to play.");
							finished = false;
							answer = null;
						}
						else
						{
							finished = true;
						}
						break;
					case "q":
						Environment.Exit(0);
						break;
					default:
						Console.WriteLine("Choose Yes (y), No (n), Quit (q)");
						answer = Console.ReadLine();
						break;
				}
			}
			if (checkPlayerList() >= 2)
				game.StartGame(Players);
			else
				Console.WriteLine("You need more players to play");
		}
	}
}