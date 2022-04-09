using System.Collections.Generic;

namespace PracticeApp
{
	internal interface IPlayerManager
	{
		List<Player> Players { get; set; } //The game has to have a list of players.
	}
}
