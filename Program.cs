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

            var trainGame = new TrainGameCreator();
            trainGame.StartGame(user, gamer);

            var randomRateGame = new RandomRateGameCreator();
            randomRateGame.StartGame(user, gamer);

            var commonGame = new CommonGameCreator();
            commonGame.StartGame(user, gamer, 50);

            user.GetStats();
        }
    }
}
