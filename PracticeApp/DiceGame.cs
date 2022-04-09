using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace PracticeApp
{
	public class DiceGame: IDice
	{
		private int _maxRoll; //declare
		private Random _random; //declare

		public DiceGame() //initalize here
		{
			_maxRoll = 0;
			_random = new Random();
		}

		public void GetPlayersRoll(Player player)
		{
			_maxRoll = 0;
			player._currentRoll = _random.Next(1,7);
			Console.WriteLine(player._name + " Rolls a " + player._currentRoll);
			if (player._currentRoll > _maxRoll)
			{
				_maxRoll = player._currentRoll;
			}
		}

		public void StartGame(List<Player> player)
		{
			for (int i = 0; i < 10; i++)
			{
				Console.WriteLine("Press any key to roll");
				Console.ReadLine();

				foreach (Player p in player)
				{
					GetPlayersRoll(p);
					Console.WriteLine("...");
					Thread.Sleep(1000);
				}
				getRoundWinner(player);
			}
			getOverAllWinner(player);
		}

		private void getRoundWinner(List<Player> Players)
		{
			if (Players.All(player => player._currentRoll == _maxRoll))
			{
				Console.WriteLine("This round is a draw!");
			}
			else
			{
				Player winner = Players.OrderByDescending(player => player._currentRoll).FirstOrDefault();
				Console.WriteLine(winner._name + " wins this round");
				winner._points++;
			}
		}

		private void getOverAllWinner(List<Player> Players)
		{
			int maxPoints = Players
								.Select(player => player._points)
								.OrderByDescending(point => point)
								.FirstOrDefault();
			if (Players.All(player => player._points == maxPoints))
			{
				Console.WriteLine("This game is a draw!");
			}
			else
			{
				Player winner = Players.OrderByDescending(player => player._points).FirstOrDefault();
				Console.WriteLine(winner._name + " WINNER!!");
			}
		}

	}
}
