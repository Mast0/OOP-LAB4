using GameClasses;

namespace FactoryGameClasses
{
	class GameCreator
	{
		public Game CreateGame(GameAccount user1, GameAccount user2, GameTypes gameType, int rate = 10)
		{
			if (GameTypes.RandomRateGame == gameType)
			{
				return new RandomRateGame(user1, user2);
			}
			else if (GameTypes.TrainGame == gameType)
			{
				return new TrainGame(user1, user2);
			}
			else
			{
				return new CommonGame(user1, user2, rate);
			}
		}

		public string StartGame(GameAccount user1, GameAccount user2, GameTypes gameType, int rate = 10)
		{
			var game = CreateGame(user1, user2, gameType, rate);
			return game.StartGame();
		}
	}
}
