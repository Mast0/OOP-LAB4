using DB.Repository.Base;
using DB.Entity.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository
{
    class GameRepository : IGamesRepository
	{
		DBContext context;
		public GameRepository(DBContext _context) 
		{
			context = _context;
		}
		public void Create(GameEntity game)
		{
			context.Games.Add(game);
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
