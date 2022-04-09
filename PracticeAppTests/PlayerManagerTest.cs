using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace PracticeApp.Tests
{
	[TestClass()]
	public class PlayerManagerTest
	{
		[TestMethod()]
		public void AddPlayers_Test__IsTrue()
		{
			//Arrange
			PlayerManager playerManager = new PlayerManager();

			//Act
			playerManager.AddPlayer("Michael");
			playerManager.AddPlayer("John");

			//Assert
			Assert.IsTrue(playerManager.Players.Any(player => player._name == "John"));
		}

		[TestMethod()]
		public void DeletePlayer_Test_IsFalse()
		{
			//Arrange
			PlayerManager playerManager = new PlayerManager();
			playerManager.AddPlayer("John");
			playerManager.AddPlayer("Michael");

			//Act
			playerManager.DeletePlayer("John");

			//Assert
			Assert.IsFalse(playerManager.Players.Any(player => player._name == "John"));
		}

		[TestMethod()]
		public void CheckListCount_AreEqual()
		{
			//Arrange
			PlayerManager playerManager = new PlayerManager();
			playerManager.AddPlayer("Michael");
			playerManager.AddPlayer("John");

			//Act
			playerManager.checkPlayerList();

			//Assert
			Assert.AreEqual(2, playerManager.Players.Count);
			
		}

	}
}