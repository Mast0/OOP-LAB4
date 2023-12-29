using GameClasses;
using FactoryGameClasses;
using DB.Entity.Games;
using DB;
using DB.Service;
using UI;
using System.Text;

namespace MainClass
{
    class Program
    {
        static void Main(string[] args)
        {
			Console.OutputEncoding = Encoding.UTF8;
			Game.IdentificationNumber = 1000;

            DBContext context = new DBContext();
            GameAccountService accountService = new GameAccountService(context);
            GameService gameService = new GameService(context);
            StartUI UI = new StartUI(accountService, gameService);

            UI.Operation();
        }
    }
}
