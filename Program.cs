using System;
using GameClasses;

namespace MainClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Game.IdentificationNumber = 1000;
            GameAccount user = new GameAccount("Mast");
            GameAccount gamer = new GameAccount("Deremion");
            for (int i = 0; i < 10; i++)
            {
                //Game newGame = new Game(user, gamer, 10);
                Console.WriteLine($"Game №{i+1} is end.\n\t Winner: {newGame.StartGame()}\n\n");
            }

            user.GetStats();
        }
    }
}
