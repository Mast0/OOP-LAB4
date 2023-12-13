using DB.Entity.Games;
using DB.Repository;
using GameClasses;
using System;
using System.Collections.Generic;
using System.Linq;
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

		public void Create(Game game)
		{
			repo.Create(Map(game));
		}
		public List<Game> GetAll()
		{
			var list = repo.GetAll()
				.Select(x => x != null ? Map(x) : null)
				.ToList();
			return list;
		}
		public Game GetById(int id)
		{
			return Map(repo.GetById(id));
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
			return new Game(game.User1, game.User2, this, game.Rate)
			{
				service = this,
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
				service = this,
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
			return new RandomRateGame(game.User1, game.User2, this)
			{
				service = this,
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
				service = this,
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
			return new TrainGame(game.User1, game.User2, this)
			{
				service = this,
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
				service = this,
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
