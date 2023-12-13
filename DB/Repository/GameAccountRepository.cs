using DB.Repository.Base;
using DB.Entity.GameAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Entity;

namespace DB.Repository
{
    public class GameAccountRepository : IGameAccountsRepository
	{
		DBContext context;
		public GameAccountRepository(DBContext _context)
		{
			context = _context;
		}
		public void Create(GameAccountEntity account)
		{
			context.GameAccounts.Add(account);
		}
		public List<GameAccountEntity> GetAll()
		{
			return context.GameAccounts;
		}
		public GameAccountEntity GetById(int id)
		{
			return context.GameAccounts[id];
		}
		public void Update(GameAccountEntity account)
		{ 
			context.GameAccounts.RemoveAt(account.ID);
			context.GameAccounts.Insert(account.ID, account);
		}
		public void Delete(GameAccountEntity account) 
		{
			context.GameAccounts.RemoveAt(account.ID);
			int ID = 0;
            foreach (var gameAccount in context.GameAccounts)
            {
				context.GameAccounts[ID].ID = ID;
				ID++;
            }
        }
		public List<GameHistoryEntity> GetHistory(GameAccountEntity account)
		{
			return account.games;
		}

	}
}
