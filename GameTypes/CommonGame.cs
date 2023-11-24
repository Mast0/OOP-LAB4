namespace GameClasses
{
	class CommonGame : Game
	{
		private int Rate;
		public CommonGame(GameAccount user1, GameAccount user2, int rate) : base(user1, user2)
		{
			Rate = rate;
			GameType = "Common game\t";
		}

		public override int GameRateCount()
		{
			var random = new Random();
			int rate = Rate + random.Next(0, 10);
			return rate;
		}
	}
}
