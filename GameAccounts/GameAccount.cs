using DB.Entity.GameAccounts;
using DB.Service;
using lab1;

namespace GameClasses
{
    public class GameAccount
    {
        public int ID;
        private string username;
        private int raiting;
        public string UserName { get { return username; } set { username = value; } }
        public int CurrentRating { 
            get { return raiting; } set {
				if (value > 1)
				{
					raiting = value;
				}
			} }
        public List<GameRes> games { get; set; }
        public GameAccountService service {  get; set; }

        public GameAccount(string userName, int id, GameAccountService _service) {
            username = userName;
            raiting = 1;
            games = new List<GameRes>();
            service = _service;
            ID = id;
		}

        virtual protected int CountRaiting(bool isWin, int rate) {
            if (isWin) 
            { 
                return rate;
            }
            else
            {
                return -rate;
            }
        }

        public void WinGame(Game game)
        {
            CurrentRating += CountRaiting(true, game.GameRateCount());
            games.Add(new GameRes
            {
                GameIndex = game.Index,
                UserName = username,
                UserCurrentRating = CurrentRating,
				IsWin = true,
				GameType = game.GameType
            });
            service.Update(this);
        }

        public void LoseGame(Game game)
        {
            CurrentRating += CountRaiting(false, game.GameRateCount());
			games.Add(new GameRes
			{
				GameIndex = game.Index,
				UserName = UserName,
				UserCurrentRating = CurrentRating,
				IsWin = false,
				GameType = game.GameType
			});
			service.Update(this);
		}

		public void GetStats()
        {
			Console.WriteLine($"Gaming Records for {UserName}:");
			Console.WriteLine("{0,-15} {1,-10} {2,-10} {3,-10} {4,-10}", "UserName", "UserCurRate", "IsWin", "Index", "GameType");
			for (int i = 0; i < this.games.Count(); i++)
            {
                Console.WriteLine("{0,-15} {1,-10} {2,-10} {3,-10} {4,-10}",
                    games[i].UserName,
                    games[i].UserCurrentRating,
                    games[i].IsWin ? "Win" : "Loose",
                    games[i].GameIndex,
                    games[i].GameType
                    );
            }
        }
    }
}
