using DB.Entity.Games;
using DB.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Base;

namespace UI
{
	public class ChooseGameUI : IUserInterface
	{
		GameService gameService;
		GameAccountService accountService;
		public ChooseGameUI(GameService gameService, GameAccountService accountService)
		{
			this.gameService = gameService;
			this.accountService = accountService;
		}

		public void Operation()
		{
			bool flag = true;
			do
			{
				Console.WriteLine("Введіть тип гри: ");
				Console.WriteLine("1. Звичайний гра, ");
				Console.WriteLine("2. Гра в якій рейтинг що буде начислятися гравцям вибирається випадково, ");
				Console.WriteLine("3. Тренувальна гра. ");
				int temp = Convert.ToInt32(Console.ReadLine());
				flag = false;
				switch (temp)
				{
					case 1:
						Console.WriteLine("Введіть рейтинг на який ви бажаєте грати: ");
						int tempRate = Convert.ToInt32(Console.ReadLine());
						gameService.Create(accountService.GetById(accountService.GetAll().Count - 2),
							accountService.GetById(accountService.GetAll().Count - 1), GameTypes.CUMMON_GAME, tempRate);
						break;
					case 2:
						gameService.Create(accountService.GetById(accountService.GetAll().Count - 2),
							accountService.GetById(accountService.GetAll().Count - 1), GameTypes.RANDOM_RATE_GAME);
						break;
					case 3:
						gameService.Create(accountService.GetById(accountService.GetAll().Count - 2),
							accountService.GetById(accountService.GetAll().Count - 1), GameTypes.TRAIN_GAME);
						break;
					default:
						flag = true;
						Console.WriteLine("введено не коректне значення!");
						break;
				}
			} while (flag);
		}
	}
}
