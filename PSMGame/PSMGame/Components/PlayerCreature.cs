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
		public Bounds2 BoundingBox;
		public bool Dead { get; set;}

		public Dictionary<string, Animation> Animations; 
		
		public bool isJumping = false;
		private int _jumpOffset = 0;
		private const int _waterLevel = 272;
		
		
		public PlayerCreature ()
		{
			Dead = false;
			Animations = new Dictionary<string, Animation>();
			texInfo = new TextureInfo(AssetManager.GetTexture("catanimation"), new Vector2i(5,1),TRS.Quad0_1);
			Animations.Add("idle" , new Animation(0, 3, 0.1f, false));
			CurrentAnimation = Animations["idle"];
			CurrentAnimation.Play();
			sprite = new SpriteTile(texInfo);
			sprite.TileIndex1D = CurrentAnimation.CurrentFrame;
			sprite.Quad.S = new Vector2(258, 214);
			sprite.CenterSprite();
<<<<<<< OURS
			
			isJumping = false;

=======
			BoundingBox = new Bounds2(new Vector2(0, 258), new Vector2(0, 214));
			
>>>>>>> THEIRS
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
			
			if (this.isJumping)
			{
				float newX = this.sprite.Position.X;
				float newY = _waterLevel + 150-(_jumpOffset*_jumpOffset);//this.sprite.Position.Y;
				
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
