using DB.Entity.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Base
{
    public interface IGamesRepository
	{
		public void Create(GameEntity game);
		public List<GameEntity> GetAll();
		public GameEntity GetById(int id);
		public void Update(GameEntity game);
		public void Delete(GameEntity game);
	}
}
