using GameClasses;
using FactoryGameClasses;

namespace MainClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Game.IdentificationNumber = 1000;
            var user = new GAccDobleRate("Mast");
            var gamer = new GAccLowRateDivide("Deremion");

            var gameCreator = new GameCreator();

            gameCreator.StartGame(user, gamer, GameTypes.TrainGame);

			gameCreator.StartGame(user, gamer, GameTypes.RandomRateGame);

			gameCreator.StartGame(user, gamer, GameTypes.CummonGame);

			user.GetStats();
        }
    }
}
