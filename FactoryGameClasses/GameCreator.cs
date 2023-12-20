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
				service.Create(user1, user2, gameType, rate);
				return service.GetById(service.GetAll().Count - 1);
			}
			else if (GameTypes.TRAIN_GAME == gameType)
			{
				service.Create(user1, user2, gameType, rate);
				return service.GetById(service.GetAll().Count - 1);
			}
			else
			{
				service.Create(user1, user2, gameType, rate);
				return service.GetById(service.GetAll().Count - 1);
			}
		}

		public string StartGame(GameAccount user1, GameAccount user2, GameTypes gameType, GameService gameService, GameAccountService accountService, int rate = 10)
		{
			var game = CreateGame(user1, user2, gameType, gameService, rate);
			string winner = game.StartGame();
			accountService.Update(user1);
			accountService.Update(user2);
			gameService.Update(game);
			return winner;
		}
	}
}
