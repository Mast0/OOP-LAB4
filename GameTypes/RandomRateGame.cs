﻿using DB.Service;

namespace GameClasses
{
	class RandomRateGame : Game
	{
		public RandomRateGame(GameAccount user1, GameAccount user2, GameService _service) : base(user1, user2, _service) { GameType = "Random rate game"; }

		public override int GameRateCount()
		{
			var random = new Random();
			int rate = random.Next(1, 51);
			return rate;
		}
	}
}
