using DB.Entity;
using DB.Entity.GameAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Base
{
    public interface IGameAccountsRepository
	{
		public void Create(string userName, GameAccountType type);
		public List<GameAccountEntity> GetAll();
		public GameAccountEntity GetById(int id);
		public void Update(GameAccountEntity gameAccount);
		public void Delete(GameAccountEntity gameAccount);
		public List<GameHistoryEntity> GetHistory(GameAccountEntity gameAccount);
	}
}
