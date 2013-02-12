using System;

using Sce.PlayStation.HighLevel.Physics2D;
using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace PSM
{
	public class PhysicsSprite
	{
		public SpriteUV sprite;
		public PhysicsBody body;
		
		public PhysicsSprite (SpriteUV sprite, PhysicsBody body)
		{
			this.sprite = sprite;
			this.body = body;
		}
	}
}

