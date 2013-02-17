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
		
		public bool isJumping = false;
		private int _jumpOffset = 0;
		private const int _waterLevel = 272;
		
		public Dictionary<string, Animation> Animations; 
		
		public PlayerCreature ()
		{
			Animations = new Dictionary<string, Animation>();
			texInfo = new TextureInfo(AssetManager.GetTexture("spritesheet"), new Vector2i(2,2), TRS.Quad0_1);
			Animations.Add("idle" , new Animation(0, 2, 0.4f, false));
			CurrentAnimation = Animations["idle"];
			CurrentAnimation.Play();
			sprite = new SpriteTile(texInfo);
			sprite.TileIndex1D = CurrentAnimation.CurrentFrame;
			sprite.Quad.S = texInfo.TextureSizef;
			
			isJumping = false;
		}
		
		public void SetAnimation(string animation)
		{
			CurrentAnimation = Animations[animation];	
		}
		
		public void Update(float dt)
		{
			CurrentAnimation.Update(dt);
			sprite.TileIndex1D = CurrentAnimation.CurrentFrame;
			
			if (this.isJumping)
			{
				float newX = this.sprite.Position.X;
				float newY = _waterLevel + 250-(_jumpOffset*_jumpOffset);//this.sprite.Position.Y;
				
				_jumpOffset++;
				if (newY < _waterLevel)
				{
					this.isJumping = false;
					_jumpOffset = 0;
				}
				
				this.sprite.Position = new Vector2(newX,newY);
			}
		}
	}
}

