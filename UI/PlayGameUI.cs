using DB.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Base;

namespace UI
{
	public class PlayGameUI : IUserInterface
	{
		GameAccountService accountService;
		GameService gameService;
		public PlayGameUI(GameAccountService accountService, GameService gameService)
		{
			this.accountService = accountService;
			this.gameService = gameService;
		}

		public void Operation()
		{
			bool playAgain = true;
			do
			{
				var game = gameService.GetById(gameService.GetAll().Count - 1);
				string winner = game.StartGame();
				gameService.Update(game);
				accountService.Update(game.User1);
				accountService.Update(game.User2);
				Console.WriteLine($"Winner is {winner}");

				Console.Write("Хочете зіграти ще одну гру? (Так/Ні): ");
				string playAgainResponse = Console.ReadLine().Trim();

				if (!playAgainResponse.Equals("Так", StringComparison.OrdinalIgnoreCase))
				{
					playAgain = false;
				}
			} while (playAgain);
		}
	}
}
