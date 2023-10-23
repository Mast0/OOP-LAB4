using GameClasses;

namespace FactoryGameClasses
{
	class TrainGameCreator : GameCreator
	{
		public override Game CreateGame(GameAccount user1, GameAccount user2, int rate = 0)
		{
			return new TrainGame(user1, user2);
		}
	}
}
