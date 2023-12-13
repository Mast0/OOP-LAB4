using DB.Service;

namespace GameClasses
{
	public class GAccLowRateDivide : GameAccount
	{
		public GAccLowRateDivide(string userName, int id, GameAccountService _service) : base(userName, id, _service) { }
		protected override int CountRaiting(bool isWin, int rate)
		{
			if (isWin)
			{
				return rate;
			}
			else
			{
				return -rate/2;
			}
		}
	}
}
