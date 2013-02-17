using System;
using System.Collections.Generic;
using Sce.PlayStation.Core;
using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace PSM
{
	public class PlayerCreature
	{
		public SpriteTile sprite;
		private TextureInfo texInfo;
		public Animation CurrentAnimation;

		public Dictionary<string, Animation> Animations; 

		public PlayerCreature ()
		{
			Animations = new Dictionary<string, Animation>();
			texInfo = new TextureInfo(AssetManager.GetTexture("catanimation"), new Vector2i(5,1),TRS.Quad0_1);
			Animations.Add("idle" , new Animation(0, 3, 0.1f, false));
			CurrentAnimation = Animations["idle"];
			CurrentAnimation.Play();
			sprite = new SpriteTile(texInfo);
			sprite.TileIndex1D = CurrentAnimation.CurrentFrame;
			sprite.Quad.S = new Vector2(258, 214);
			sprite.CenterSprite();
		}
		
		public Vector2 spriteSize()
		{
			return new Vector2(64, 120);
		}
		
		public void SetAnimation(string animation)
		{
			CurrentAnimation = Animations[animation];	
		}

		public void Update(float dt)
		{
			CurrentAnimation.Update(dt);
			sprite.TileIndex1D = CurrentAnimation.CurrentFrame;
		}
	}
}