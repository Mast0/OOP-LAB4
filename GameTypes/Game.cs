using DB.Service;

namespace GameClasses
{

	public class Game
    {
        public int ID;
        public int Index {  get; set; }
        public static int IdentificationNumber;
        public GameAccount User1 { get; set; }
        public GameAccount User2 { get; set; }
        private string GameStatistic;
        public string GameType;
		public int Rate { get; set; }
        public GameService service { get; set; }


		public Game(GameAccount user1, GameAccount user2, GameService _service, int rate = 10)
        {
            if (user1 == user2)
            {
                throw new InvalidDataException("You can't play with yourself!");
            }
            User1 = user1;
            User2 = user2;
            service = _service;
            Rate = rate;
            IdentificationNumber++;
            Index = IdentificationNumber;
			GameType = "Common game\t";
			GameStatistic = "-";
        }

        virtual public int GameRateCount()
        {
			var random = new Random();
			int rate = Rate + random.Next(0, 10);
			return rate;
		}

        public string StartGame()
        {
            string winner = "";
            var rand = new Random();
            if (rand.Next(0, 2) == 0)
            {
                User1.WinGame(this);
                User2.LoseGame(this);
                winner = User1.UserName;

                GameStatistic = $"\t Game type: {GameType}\t\t Game Identification Number: {Index}\n\t Winner: {User1.UserName}\t\t\t Loser: {User2.UserName}" +
                $"\n\t {User1.UserName} current raiting: {User1.CurrentRating}\t\t {User2.UserName} current raiting: {User2.CurrentRating}";
            }
            else
            {
                User1.LoseGame(this);
                User2.WinGame(this);
                winner = User2.UserName;

                GameStatistic = $"\t Game type: {GameType}\t\t Game Identification Number: {Index}\n\t Winner: {User2.UserName}\t\t\t Loser: {User1.UserName}" +
                $"\n\t {User2.UserName} current raiting: {User2.CurrentRating}\t\t {User1.UserName} current raiting: {User1.CurrentRating}";
                
            }

            service.Create(this);

            return winner;
        }

        public void GetStatistic() 
        {
            Console.WriteLine(GameStatistic);
        }
    }
}
