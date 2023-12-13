using DB.Service;

namespace GameClasses
{
	public class GAccDobleRate : GameAccount
	{
		public GAccDobleRate(string userName, int id, GameAccountService _service) : base(userName, id, _service) { }
		protected override int CountRaiting(bool isWin, int rate)
		{
			if (isWin)
			{
				return rate*2;
			}
			else
			{ 
				return -rate; 
			}
		}
	}
}
