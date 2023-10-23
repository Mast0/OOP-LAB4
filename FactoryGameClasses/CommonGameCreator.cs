using GameClasses;

namespace FactoryGameClasses
{
	class CommonGameCreator : GameCreator
	{
		public override Game CreateGame(GameAccount user1, GameAccount user2, int rate)
		{
			return new CommonGame(user1, user2, rate);
		}
	}
}
