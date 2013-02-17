using System;
using System.Collections;
<<<<<<< OURS
using System.Collections.Generic;
using Sce.PlayStation.Core;
using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace PSM
{
	public class FishEnemy : Enemy
	{
		private float speed = 4.0f;
		private static TextureInfo texInfo = null;
		public static SpriteList spriteList = null;
		public PlayerCreature player;
		public Animation CurrentAnimation;

		public Dictionary<string, Animation> Animations; 
		
		public delegate void _updateFunc();
		
		private FishEnemy (){}

		public FishEnemy (Vector2 pos, PlayerCreature player)
		{
			enemyHabitat = Enemy.EnemyHabitat.ENEMY_HABITAT_SEA;
			enemyType = Enemy.EnemyType.ENEMY_TYPE_FISH;
			sprite = new SpriteTile();
			this.player = player;
			
			if (texInfo == null)
			{
				//texInfo = new TextureInfo ("/Application/assets/stingray_float.png");
				texInfo = new TextureInfo(AssetManager.GetTexture("stingray_float"), new Vector2i(4,1),TRS.Quad0_1);
			}
			
			if (spriteList == null)
			{
				spriteList = new SpriteList(texInfo);
			}
			
			spriteList.Position = new Vector2(0.0f,0.0f);
			spriteList.AddChild(sprite);
			
			Animations = new Dictionary<string, Animation>();
			//texInfo = new TextureInfo(AssetManager.GetTexture("stingray_float"), new Vector2i(4,1),TRS.Quad0_1);
			Animations.Add("idle" , new Animation(0, 3, 0.3f, false));
			CurrentAnimation = Animations["idle"];
			CurrentAnimation.Play();
			
			sprite.GetContentWorldBounds(ref boundingBox);
			sprite.Quad.S = texInfo.TextureSizef; // map 1:1 on screen -- necessary? !!!\
			sprite.CenterSprite();
			sprite.Position = pos;
			sprite.Schedule((dt) => UpdateEnemyState(dt));
		}
		
		public Vector2 spriteSize()
		{
			return FishEnemy.spriteList.TextureInfo.TileSizeInPixelsf;
		}
		
		public void UpdateEnemyState(float dt)
		{
			float newX = this.sprite.Position.X;
			float newY = this.sprite.Position.Y;
			
			if (this.sprite.Position.X < player.sprite.Position.X)
			{
				newX += speed;
			}
			else if (this.sprite.Position.X > player.sprite.Position.X)
			{
				newX -= speed;
			}
			if (this.sprite.Position.Y < player.sprite.Position.Y)
			{
				newY += speed;
			}
			else if (this.sprite.Position.Y > player.sprite.Position.Y)
			{
				newY -= speed;
			}
			this.sprite.Position = new Vector2(newX,newY);
		}

		public override void Die ()
		{
			Cleanup ();
		}
		
		// not thread-safe!
		public override void Cleanup ()
		{
			this.sprite.UnscheduleAll();
			/*
			if (texInfo != null) 
			{
				texInfo.Dispose();
				texInfo = null;
			}
			*/
=======
using Sce.PlayStation.Core;
using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace PSM
{
	public class FishEnemy : Enemy
	{
		private float speed = 4.0f;
		private static TextureInfo texInfo = null;
		public static SpriteList spriteList = null;
		public PlayerCreature player;
		
		public delegate void _updateFunc();
		
		private FishEnemy (){}

		public FishEnemy (Vector2 pos, PlayerCreature player)
		{
			enemyHabitat = Enemy.EnemyHabitat.ENEMY_HABITAT_SEA;
			enemyType = Enemy.EnemyType.ENEMY_TYPE_FISH;
			sprite = new SpriteUV();
			this.player = player;
			
			if (texInfo == null)
			{
				texInfo = new TextureInfo ("/Application/assets/fish.png");
			}
			
			if (spriteList == null)
			{
				spriteList = new SpriteList(texInfo);
			}
			
			spriteList.Position = new Vector2(0.0f,0.0f);
			spriteList.AddChild(sprite);
			
			sprite.GetContentWorldBounds(ref boundingBox);
			sprite.Quad.S = texInfo.TextureSizef; // map 1:1 on screen -- necessary? !!!\
			sprite.CenterSprite();
			sprite.Position = pos;
			sprite.Schedule((dt) => UpdateEnemyState(dt));
		}
		
		public Vector2 spriteSize()
		{
			return FishEnemy.spriteList.TextureInfo.TileSizeInPixelsf;
		}
		
		public void UpdateEnemyState(float dt)
		{
			float newX = this.sprite.Position.X;
			float newY = this.sprite.Position.Y;
			
			if (this.sprite.Position.X < player.sprite.Position.X)
			{
				newX += speed;
			}
			else if (this.sprite.Position.X > player.sprite.Position.X)
			{
				newX -= speed;
			}
			if (this.sprite.Position.Y < player.sprite.Position.Y)
			{
				newY += speed;
			}
			else if (this.sprite.Position.Y > player.sprite.Position.Y)
			{
				newY -= speed;
			}
			this.sprite.Position = new Vector2(newX,newY);
			
			if(isCollidingWith(player.BoundingBox))
			{
				player.Dead = true;	
			}
				
			
		}

		public override void Die ()
		{
		}
		
		// not thread-safe!
		public override void Cleanup ()
		{
			this.sprite.UnscheduleAll();
			
			if (texInfo != null) 
			{
				texInfo.Dispose();
				texInfo = null;
			}
>>>>>>> THEIRS
		}
	}
}
