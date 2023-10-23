using GameClasses;

namespace FactoryGameClasses
{
	abstract class GameCreator
	{
		public abstract Game CreateGame(GameAccount user1, GameAccount user2, int rate = 10);

		public string StartGame(GameAccount user1, GameAccount user2, int rate = 10)
		{
			var game = CreateGame(user1, user2, rate);
			return game.StartGame();
		}
	}
}
