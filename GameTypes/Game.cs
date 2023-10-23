namespace GameClasses
{
	abstract class Game
    {
        private int Index;
        public static int IdentificationNumber;
        private GameAccount User1;
        private GameAccount User2;
        private string GameStatistic;



        public Game(GameAccount user1, GameAccount user2)
        {
            if (user1 == user2)
            {
                throw new InvalidDataException("You can't play with yourself!");
            }
            User1 = user1;
            User2 = user2;
            IdentificationNumber++;
            Index = IdentificationNumber;

            GameStatistic = "-";
        }

        abstract public int GameRateCount();

        public string StartGame()
        {
            string winner = "";
            var rand = new Random();
            if (rand.Next(0, 2) == 0)
            {
                User1.WinGame(this);
                User2.LoseGame(this);
                winner = User1.UserName;

                GameStatistic = $"\t Game Identification Number: {Index}\n\t Winner: {User1.UserName}\t\t Loser: {User2.UserName}" +
                $"\n\t {User1.UserName} current raiting: {User1.CurrentRating}\t\t {User2.UserName} current raiting: {User2.CurrentRating}";
            }
            else
            {
                User1.LoseGame(this);
                User2.WinGame(this);
                winner = User2.UserName;

                GameStatistic = $"\t Game Identification Number: {Index}\n\t Winner: {User2.UserName}\t\t Loser: {User1.UserName}" +
                $"\n\t {User2.UserName} current raiting: {User2.CurrentRating}\t\t {User1.UserName} current raiting: {User1.CurrentRating}";
                
            }
            User1.AddStatistic(this);
            User2.AddStatistic(this);

            return winner;
        }

        public void GetStatistic() 
        {
            Console.WriteLine(GameStatistic);
        }
    }
}
