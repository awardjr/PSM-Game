using System;
using System.Collections.Generic;
using Sce.PlayStation.Core;
using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace PSM
{
	public class Bullet
	{
		public SpriteUV sprite;

		private float _speed = 8.0f;
		private static TextureInfo texInfo = null;
		public static SpriteList spriteList = null;
		
		public static int cooldown = 0;
		
		public Bullet (Vector2 pos)
		{
			sprite = new SpriteUV();
			
			if (texInfo == null)
			{
				texInfo = new TextureInfo ("/Application/assets/bubble.png");
				//texInfo = new TextureInfo(AssetManager.GetTexture("bubble"), new Vector2i(4,1),TRS.Quad0_1);
			}
			
			if (spriteList == null)
			{
				spriteList = new SpriteList(texInfo);
				spriteList.Position = new Vector2(0.0f,0.0f);
			}
			
			spriteList.AddChild(sprite);
			sprite.Quad.S = texInfo.TextureSizef; // map 1:1 on screen -- necessary? !!!\
			
			sprite.CenterSprite();
			sprite.Position = pos;
			sprite.Schedule((dt) => Update());
		}
		
		public void Update()
		{
			sprite.Position += new Vector2(_speed,0);
		}
	}
}

