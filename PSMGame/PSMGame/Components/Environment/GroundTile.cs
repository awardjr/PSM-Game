using System;
using System.Collections;
using System.Collections.Generic;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;
using Sce.PlayStation.Core.Environment;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

using Sce.PlayStation.HighLevel.Physics2D;


namespace PSM
{
	public class GroundTile : SpriteTile
	{
		public GroundTile (TextureInfo texInfo): base(texInfo)
		{
			
		}
		
		public override void Update(float dt)
		{
			Position -= new Vector2(1f, 0);
			if(Position.X < 0 - TextureInfo.TextureSizei.X)
				Position += new Vector2(960 + TextureInfo.TextureSizei.X, 0);
		}
	}
}

