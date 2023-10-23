using System;
using GameClasses;
using FactoryGameClasses;

namespace MainClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Game.IdentificationNumber = 1000;
            GameAccount user = new GameAccount("Mast");
            GameAccount gamer = new GameAccount("Deremion");

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
