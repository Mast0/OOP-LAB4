using DB.Entity.Games;
using GameClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Base
{
    public interface IGamesRepository
	{
		public void Create(GameTypes type, GameAccount user1, GameAccount user2, int rate = 10);
		public List<GameEntity> GetAll();
		public GameEntity GetById(int id);
		public void Update(GameEntity game);
		public void Delete(GameEntity game);
	}
}
