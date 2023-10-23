namespace GameClasses
{
	class GAccDobleRate : GameAccount
	{
		public GAccDobleRate(string userName) : base(userName) { }
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
