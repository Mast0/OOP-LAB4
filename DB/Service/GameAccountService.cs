using DB.Repository;
using DB.Service.Base;
using GameClasses;
using DB.Entity.GameAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Entity;
using lab1;

namespace DB.Service
{
    public class GameAccountService : IGameAccountService
	{
		GameAccountRepository repo;
		public GameAccountService(DBContext context) 
		{
			repo = new GameAccountRepository(context);
		}
		public void Create(string userName, GameAccountType accountType)
		{
			if (accountType == GameAccountType.GAME_ACCOUNT)
			{
				repo.Create(Map(new GameAccount(userName, this.GetAll().Count(), this)));
			}
			else if (accountType == GameAccountType.G_ACC_DOBLE_RATE)
			{
				repo.Create(Map(new GAccDobleRate(userName, this.GetAll().Count(), this)));
			}
			else
			{
				repo.Create(Map(new GAccLowRateDivide(userName, this.GetAll().Count(), this)));
			}
		}
		public List<GameAccount> GetAll()
		{
			var list = repo.GetAll()
				.Select(x => x != null ? Map(x) : null)
				.ToList();
			return list;
		}
		public GameAccount GetById(int id)
		{
			return Map(repo.GetById(id));
		}
		public void Update(GameAccount account)
		{
			repo.Update(Map(account));
		}
		public void Delete(GameAccount account)
		{
			repo.Delete(Map(account));
		}
		public List<GameRes> GetHistory(GameAccount account)
		{
			return MapGameHistory(repo.GetHistory(Map(account)));
		}

		private List<GameHistoryEntity> MapGameHistory(List<GameRes> games)
		{
			if (games == null) { return null; }
			List<GameHistoryEntity> history = new List<GameHistoryEntity>();
			foreach (var game in games)
			{
				history.Add(new GameHistoryEntity
				{
					GameIndex = game.GameIndex,
					UserName = game.UserName,
					UserCurrentRating = game.UserCurrentRating,
					IsWin = game.IsWin,
					GameType = game.GameType,
				});
			}
			return history;
		}
		private List<GameRes> MapGameHistory(List<GameHistoryEntity> games)
		{
			if (games == null) { return null; }
			List<GameRes> history = new List<GameRes>();
			foreach (var game in games)
			{
				history.Add(new GameRes
				{
					GameIndex = game.GameIndex,
					UserName = game.UserName,
					UserCurrentRating = game.UserCurrentRating,
					IsWin = game.IsWin,
					GameType = game.GameType,
				});
			}
			return history;
		}

		private GameAccountEntity Map(GameAccount account)
		{
			if (account == null) { return null; }
			return new GameAccountEntity
			{
				service = this,
				ID = account.ID,
				UserName = account.UserName,
				CurrentRating = account.CurrentRating,
				AccountType	= GameAccountType.GAME_ACCOUNT,
				games = MapGameHistory(account.games),
			};
		}
		private GameAccount Map(GameAccountEntity account)
		{
			if (account == null) { return null; }
			return new GameAccount(account.UserName, account.ID, this)
			{
				service = this,
				ID = account.ID,
				UserName = account.UserName,
				CurrentRating = account.CurrentRating,
				games = MapGameHistory(account.games),
			};
		}

		private GAccDobleRateEntity Map(GAccDobleRate account)
		{
			if (account == null) { return null; }
			return new GAccDobleRateEntity
			{
				service = this,
				ID = account.ID,
				UserName = account.UserName,
				CurrentRating = account.CurrentRating,
				AccountType = GameAccountType.G_ACC_DOBLE_RATE,
				games = MapGameHistory(account.games),
			};
		}
		private GAccDobleRate Map(GAccDobleRateEntity account)
		{
			if (account == null) { return null; }
			return new GAccDobleRate(account.UserName, account.ID, this)
			{
				service = this,
				ID = account.ID,
				UserName = account.UserName,
				CurrentRating = account.CurrentRating,
				games = MapGameHistory(account.games),
			};
		}

		private GAccLowRateDivideEntity Map(GAccLowRateDivide account)
		{
			if (account == null) { return null; }
			return new GAccLowRateDivideEntity
			{
				service = this,
				ID = account.ID,
				UserName = account.UserName,
				CurrentRating = account.CurrentRating,
				AccountType = GameAccountType.G_ACC_LOW_RATE_DIVIDE,
				games = MapGameHistory(account.games),
			};
		}
		private GAccLowRateDivide Map(GAccLowRateDivideEntity account)
		{
			if (account == null) { return null; }
			return new GAccLowRateDivide(account.UserName, account.ID, this)
			{
				service = this,
				ID = account.ID,
				UserName = account.UserName,
				CurrentRating = account.CurrentRating,
				games = MapGameHistory(account.games),
			};
		}
	}
}
