using GameClasses;

namespace FactoryGameClasses
{
	class RandomRateGameCreator : GameCreator
	{
		public override Game CreateGame(GameAccount user1, GameAccount user2, int rate = 0)
		{
			return new RandomRateGame(user1, user2);
		}
	}
}
