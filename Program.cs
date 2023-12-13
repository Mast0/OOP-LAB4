using GameClasses;
using FactoryGameClasses;
using DB.Entity.Games;
using DB;
using DB.Service;

namespace MainClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Game.IdentificationNumber = 1000;

            DBContext context = new DBContext();
            GameAccountService accountService = new GameAccountService(context);
            GameService gameService = new GameService(context);

            accountService.Create("user1", DB.Entity.GameAccounts.GameAccountType.G_ACC_DOBLE_RATE);

            accountService.Create("user2", DB.Entity.GameAccounts.GameAccountType.G_ACC_LOW_RATE_DIVIDE);

            var gameCreator = new GameCreator();

            gameCreator.StartGame(accountService.GetById(0), accountService.GetById(1), GameTypes.TRAIN_GAME, gameService);
			gameCreator.StartGame(accountService.GetById(0), accountService.GetById(1), GameTypes.TRAIN_GAME, gameService);

			gameCreator.StartGame(accountService.GetById(0), accountService.GetById(1), GameTypes.RANDOM_RATE_GAME, gameService);
			gameCreator.StartGame(accountService.GetById(0), accountService.GetById(1), GameTypes.RANDOM_RATE_GAME, gameService);

			gameCreator.StartGame(accountService.GetById(0), accountService.GetById(1), GameTypes.CUMMON_GAME, gameService);
			gameCreator.StartGame(accountService.GetById(0), accountService.GetById(1), GameTypes.CUMMON_GAME, gameService);

            var accountList = accountService.GetAll();
            foreach (var account in accountList)
            {
                if (account != null)
                {
                    account.GetStats();
                }
            }
        }
    }
}
