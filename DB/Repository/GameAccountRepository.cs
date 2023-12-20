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
		public void Create(string userName, GameAccountType type)
		{
			switch (type)
			{
				case GameAccountType.GAME_ACCOUNT:
					context.GameAccounts.Add(new GameAccountEntity
					{
						ID = context.GameAccounts.Count,
						AccountType = type,
						UserName = userName,
						CurrentRating = 0,
						games = new List<GameHistoryEntity>()
					});
					break;
				case GameAccountType.G_ACC_LOW_RATE_DIVIDE:
					context.GameAccounts.Add(new GAccLowRateDivideEntity
					{
						ID = context.GameAccounts.Count,
						AccountType = type,
						UserName = userName,
						CurrentRating = 0,
						games = new List<GameHistoryEntity>()
					});
					break;
				case GameAccountType.G_ACC_DOBLE_RATE:
					context.GameAccounts.Add(new GAccDobleRateEntity
					{
						ID = context.GameAccounts.Count,
						AccountType = type,
						UserName = userName,
						CurrentRating = 0,
						games = new List<GameHistoryEntity>()
					});
					break;
			}
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
