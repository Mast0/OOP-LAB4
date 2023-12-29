using DB.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Base;

namespace UI
{
	public class ShowPlayersUI : IUserInterface
	{
		GameAccountService accountService;
		public ShowPlayersUI(GameAccountService accountService)
		{
			this.accountService = accountService;
		}

		public void Operation()
		{
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
