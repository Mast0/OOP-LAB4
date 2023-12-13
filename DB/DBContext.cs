using DB.Entity.GameAccounts;
using DB.Entity.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class DBContext
	{
		public List<GameAccountEntity> GameAccounts {  get; set; }
		public List<GameEntity> Games {  get; set; }
		public DBContext() 
		{
			GameAccounts = new List<GameAccountEntity>();
			Games = new List<GameEntity>();
		}
	}
}
