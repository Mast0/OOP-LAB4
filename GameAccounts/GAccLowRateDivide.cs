namespace GameClasses
{
	class GAccLowRateDivide : GameAccount
	{
		public GAccLowRateDivide(string userName) : base(userName) { }
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
