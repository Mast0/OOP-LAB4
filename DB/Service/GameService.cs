using DB.Entity.GameAccounts;
using DB.Entity.Games;
using DB.Repository;
using GameClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace DB.Service
{
	public class GameService
	{
		GameRepository repo;
		public GameService(DBContext context)
		{
			repo = new GameRepository(context);
		}

		public void Create(GameAccount user1, GameAccount user2, GameTypes type,int rate = 10)
		{
			repo.Create(type, user1, user2, rate);
		}
		public List<Game> GetAll()
		{
			List<GameEntity> list = repo.GetAll();
			List<Game> newList = new List<Game>();
			foreach (GameEntity entity in list)
			{
				switch (entity.GameType)
				{
					case GameTypes.CUMMON_GAME:
						newList.Add(new Game(entity.User1, entity.User2, entity.Rate)
						{
							ID = entity.ID,
							Type = entity.GameType,
							User1 = entity.User1,
							User2 = entity.User2,
							Rate = entity.Rate,
							Index = entity.Index,
						});
						break;
					case GameTypes.RANDOM_RATE_GAME:
						newList.Add(new RandomRateGame(entity.User1, entity.User2)
						{
							ID = entity.ID,
							Type = entity.GameType,
							User1 = entity.User1,
							User2 = entity.User2,
							Rate = entity.Rate,
							Index = entity.Index,
						});
						break;
					case GameTypes.TRAIN_GAME:
						newList.Add(new TrainGame(entity.User1, entity.User2)
						{
							ID = entity.ID,
							Type = entity.GameType,
							User1 = entity.User1,
							User2 = entity.User2,
							Rate = entity.Rate,
							Index = entity.Index,
						});
						break;
				}
			}
			return newList;
		}
		public Game GetById(int id)
		{
			var entity = repo.GetById(id);
			switch (entity.GameType)
			{
				case GameTypes.RANDOM_RATE_GAME:
					return new RandomRateGame(entity.User1, entity.User2)
					{
						ID = entity.ID,
						Type = entity.GameType,
						User1 = entity.User1,
						User2 = entity.User2,
						Rate = entity.Rate,
						Index = entity.Index,
					};
				case GameTypes.TRAIN_GAME:
					return new TrainGame(entity.User1, entity.User2)
					{
						ID = entity.ID,
						Type = entity.GameType,
						User1 = entity.User1,
						User2 = entity.User2,
						Rate = entity.Rate,
						Index = entity.Index,
					};
				default:
					return new Game(entity.User1, entity.User2, entity.Rate)
					{
						ID = entity.ID,
						Type = entity.GameType,
						User1 = entity.User1,
						User2 = entity.User2,
						Rate = entity.Rate,
						Index = entity.Index,
					};
			}
		}
		public void Update(Game game)
		{
			repo.Update(Map(game));
		}
		public void Delete(Game game)
		{
			repo.Delete(Map(game));
		}

		private Game Map(GameEntity game)
		{
			if (game == null) { return null; }
			return new Game(game.User1, game.User2, game.Rate)
			{
				ID = game.ID,
				Index = game.Index,
				User1 = game.User1,
				User2 = game.User2,
				Rate = game.Rate,
			};
		}
		private GameEntity Map(Game game)
		{
			if (game == null) { return null; }
			return new GameEntity
			{
				ID = game.ID,
				Index = game.Index,
				User1 = game.User1,
				User2 = game.User2,
				Rate = game.Rate,
				GameType = GameTypes.CUMMON_GAME,
			};
		}

		private RandomRateGame Map(RandomRateGameEntity game)
		{
			if (game == null) { return null; }
			return new RandomRateGame(game.User1, game.User2)
			{
				ID = game.ID,
				Index = game.Index,
				User1 = game.User1,
				User2 = game.User2,
				Rate = game.Rate,
			};
		}
		private RandomRateGameEntity Map(RandomRateGame game)
		{
			if (game == null) { return null; }
			return new RandomRateGameEntity
			{
				ID = game.ID,
				Index = game.Index,
				User1 = game.User1,
				User2 = game.User2,
				Rate = game.Rate,
				GameType = GameTypes.RANDOM_RATE_GAME,
			};
		}

		private TrainGame Map(TrainGameEntity game)
		{
			if (game == null) { return null; }
			return new TrainGame(game.User1, game.User2)
			{
				ID = game.ID,
				Index = game.Index,
				User1 = game.User1,
				User2 = game.User2,
				Rate = game.Rate,
			};
		}
		private TrainGameEntity Map(TrainGame game)
		{
			if (game == null) { return null; }
			return new TrainGameEntity
			{
				ID = game.ID,
				Index = game.Index,
				User1 = game.User1,
				User2 = game.User2,
				Rate = game.Rate,
				GameType = GameTypes.TRAIN_GAME,
			};
		}
	}
}
