using DB.Service;
using lab1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Entity.GameAccounts
{
    public enum GameAccountType
    {
        GAME_ACCOUNT = 1,
        G_ACC_DOBLE_RATE = 2,
        G_ACC_LOW_RATE_DIVIDE = 3,
    }

    public class GameAccountEntity
    {
		public GameAccountService service;
		public int ID;
        public string UserName { get; set; }
        public int CurrentRating { get; set; }
        public List<GameHistoryEntity> games { get; set; }
        public GameAccountType AccountType { get; set; }
    }
}
