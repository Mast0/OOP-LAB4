using DB.Entity.GameAccounts;
using DB.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Base;

namespace UI
{
	public class ChooseAccountsUI : IUserInterface
	{
		GameAccountService accountService;
		public ChooseAccountsUI(GameAccountService accountService)
		{
			this.accountService = accountService;
		}

		public void Operation()
		{
			bool flag = false;
			do
			{
				Console.WriteLine($"Введіть ім'я гравця: ");
				string tempName = Convert.ToString(Console.ReadLine());
				Console.WriteLine("Введіть тип акаунту: ");
				Console.WriteLine("1. Звичайний акаунт, ");
				Console.WriteLine("2. акаунт що отримує вдвічі більше рейтингу при виграші, ");
				Console.WriteLine("3. акаунт в якого знімається вдвічі менше рейтигнку при програші. ");
				int temp = Convert.ToInt32(Console.ReadLine());
				flag = false;
				switch (temp)
				{
					case 1:
						accountService.Create(tempName, GameAccountType.GAME_ACCOUNT);
						break;
					case 2:
						accountService.Create(tempName, GameAccountType.G_ACC_DOBLE_RATE);
						break;
					case 3:
						accountService.Create(tempName, GameAccountType.G_ACC_LOW_RATE_DIVIDE);
						break;
					default:
						flag = true;
						Console.WriteLine("Введено не коректне значення!");
						break;
				}
			} while (flag);	
		}
	}
}
