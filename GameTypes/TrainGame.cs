namespace GameClasses
{
	class TrainGame : Game
	{
		public TrainGame(GameAccount user1, GameAccount user2) : base(user1, user2) { GameType = "Training game"; }

		public override int GameRateCount()
		{
			return 0;
		}
	}
}
