
using Sce.PlayStation.Core;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;



namespace PSM
{
	
	
	public class WaterTile : SpriteTile
	{
		private Timer _timer;
		private int _delay;
		
		public WaterTile (TextureInfo texInfo) : base(texInfo)
		{
			_timer = new Timer();
			_delay = 3000;
			_timer.Reset();
		}
	
		public override void Update(float dt)
		{
			
			if(_timer.Milliseconds() >= _delay)
			{
				this.FlipU = !this.FlipU;
				_timer.Reset();
				_delay = 500;
			}
		}
	}
}

