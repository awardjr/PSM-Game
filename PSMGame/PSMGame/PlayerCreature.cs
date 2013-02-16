using System;
using Sce.PlayStation.Core;
using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace PSM
{
	public class PlayerCreature
	{
		public SpriteUV sprite;
		private TextureInfo texInfo;
		
		public PlayerCreature ()
		{
			texInfo = new TextureInfo ("/Application/assets/square.png");
			sprite = new SpriteUV (texInfo);
			sprite.Quad.S = texInfo.TextureSizef;
		}
	}
}

