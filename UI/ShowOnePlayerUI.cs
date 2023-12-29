using DB.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Base;

namespace UI
{
	public class ShowOnePlayerUI : IUserInterface
	{
		GameAccountService accountService;
		public ShowOnePlayerUI(GameAccountService accountService)
		{
			this.accountService = accountService;
		}

		public void Operation()
		{
			Console.Write("Введіть id гравця: ");
			int id = Convert.ToInt32(Console.ReadLine());
			accountService.GetById(id).GetStats();
		}
	}
}
