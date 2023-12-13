using GameClasses;
using DB.Entity.Games;
using DB.Service;

namespace FactoryGameClasses
{
    class GameCreator
	{
		public Game CreateGame(GameAccount user1, GameAccount user2, GameTypes gameType, GameService service, int rate = 10)
		{
			if (GameTypes.RANDOM_RATE_GAME == gameType)
			{
				return new RandomRateGame(user1, user2, service);
			}
			else if (GameTypes.TRAIN_GAME == gameType)
			{
				return new TrainGame(user1, user2, service);
			}
			else
			{
				return new Game(user1, user2, service, rate);
			}
		}

		public string StartGame(GameAccount user1, GameAccount user2, GameTypes gameType, GameService service, int rate = 10)
		{
			var game = CreateGame(user1, user2, gameType, service, rate);
			return game.StartGame();
		}
	}
}
