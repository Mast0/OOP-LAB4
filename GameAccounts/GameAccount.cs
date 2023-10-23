namespace GameClasses
{
    class GameAccount
    {
        private string username;
        private int raiting;
        public string UserName { get { return username; } }
        public int CurrentRating { 
            get { return raiting; } set {
				if (value > 1)
				{
					raiting = value;
				}
			} }
        public int GameCount { get { return games.Count; } }
        private List<Game> games = new List<Game>();

        public GameAccount(string userName) {
            username = userName;
            raiting = 1;
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
        }

        public void LoseGame(Game game)
        {
            CurrentRating += CountRaiting(false, game.GameRateCount());
		}

        public void AddStatistic(Game stats)
        {
            games.Add(stats);
        }

        public void GetStats()
        {
            Console.WriteLine("\t\tGames statistic:\n");
            for (int i = 0; i < this.games.Count(); i++)
            {
                games[i].GetStatistic();
                Console.WriteLine();
            }
        }
    }
}
