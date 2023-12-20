using DB.Repository.Base;
using DB.Entity.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameClasses;

namespace DB.Repository
{
    class GameRepository : IGamesRepository
	{
		DBContext context;
		public GameRepository(DBContext _context) 
		{
			context = _context;
		}
		public void Create(GameTypes type, GameAccount user1, GameAccount user2, int rate = 10)
		{
			switch (type)
			{
				case GameTypes.CUMMON_GAME:
					context.Games.Add(new GameEntity
					{
						ID = context.Games.Count,
						GameType = type,
						User1 = user1,
						User2 = user2,
						Rate = rate,
						Index = Game.IdentificationNumber,
			});
					break;
				case GameTypes.RANDOM_RATE_GAME:
					context.Games.Add(new RandomRateGameEntity
					{
						ID = context.Games.Count,
						GameType = type,
						User1 = user1,
						User2 = user2,
						Rate = rate,
						Index = Game.IdentificationNumber,
					});
					break;
				case GameTypes.TRAIN_GAME:
					context.Games.Add(new TrainGameEntity
					{
						ID = context.Games.Count,
						GameType = type,
						User1 = user1,
						User2 = user2,
						Rate = rate,
						Index = Game.IdentificationNumber,
					});
					break;
			}
		}
		public List<GameEntity> GetAll()
		{
			return context.Games;
		}
		public GameEntity GetById(int id) 
		{
			return context.Games[id];
		}
		public void Update(GameEntity game)
		{
			context.Games.RemoveAt(game.ID);
			context.Games.Insert(game.ID, game);
		}
		public void Delete(GameEntity game) 
		{
			context.Games.RemoveAt(game.ID);
			int ID = 1;
            foreach (var Game in context.Games)
            {
				Game.ID = ID;
				ID++;
            }
        }
	}
}
