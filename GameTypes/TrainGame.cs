using DB.Service;

namespace GameClasses
{
	class TrainGame : Game
	{
		public TrainGame(GameAccount user1, GameAccount user2, GameService _service) : base(user1, user2, _service) { GameType = "Training game"; }

		public override int GameRateCount()
		{
			return 0;
		}
	}
}
