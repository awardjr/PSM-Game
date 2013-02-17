using System;
using System.Collections.Generic;
using Sce.PlayStation.Core;
using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace PSM
{
	public class Bullet : SpriteTile
	{
		public Bullet (TextureInfo texInfo) : base(texInfo)
		{
			
		}
		
		public override void Update (float dt)
		{
			Position += new Vector2(1,0);
			base.Update (dt);
		}
	}
}

