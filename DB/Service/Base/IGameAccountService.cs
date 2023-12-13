using DB.Entity.GameAccounts;
using GameClasses;
using lab1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Service.Base
{
	public interface IGameAccountService
	{
		public void Create(string userName, GameAccountType accountType);
		public List<GameAccount> GetAll();
		public GameAccount GetById(int id);
		public void Update(GameAccount gameAccount);
		public void Delete(GameAccount gameAccount);
		public List<GameRes> GetHistory(GameAccount gameAccount);
	}
}
