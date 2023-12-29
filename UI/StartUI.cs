using DB.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using UI.Base;

namespace UI
{
	public class StartUI : IUserInterface
	{
		GameAccountService accountService;
		GameService gameService;
		List<IUserInterface> commands;
		public StartUI(GameAccountService accountService, GameService gameService)
		{
			this.accountService = accountService;
			this.gameService = gameService;
			commands = new List<IUserInterface>();
			commands.Add(new ChooseAccountsUI(accountService));
			commands.Add(new ChooseGameUI(gameService, accountService));
			commands.Add(new PlayGameUI(accountService, gameService));
			commands.Add(new ShowPlayersUI(accountService));
			commands.Add(new ShowOnePlayerUI(accountService));
		}

		public void Operation() 
		{
			do {
				Console.WriteLine("1. Розпочати гру: ");
				Console.WriteLine("2. Вивести статистику всіх гравців: ");
				Console.WriteLine("3. Вивести статистику одного гравця: ");
				Console.WriteLine("4. Завершити сесію: ");
				int temp = Convert.ToInt32(Console.ReadLine());

				switch (temp)
				{
					case 1:
						commands[0].Operation();
						commands[0].Operation();
						commands[1].Operation();
						commands[2].Operation();
						break;
					case 2:
						commands[3].Operation();
						break;
					case 3:
						commands[4].Operation();
						break;
					case 4:
						Console.WriteLine("До зустрічі!");
						return;
					default:
						Console.WriteLine("Введено не коректне значення.");
						break;
				}
			} while (true);
		}
	}
}
