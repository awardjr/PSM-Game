using System;
using System.Collections;
using Sce.PlayStation.Core;
using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace PSM
{
	public class FishEnemy : Enemy
	{
		private static TextureInfo texInfo = null;
		public static SpriteList spriteList = null;
		public PlayerCreature player;
		
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
			//sprite.CenterSprite();
			sprite.Position = pos;
		}
		
		public Vector2 spriteSize()
		{
			return FishEnemy.spriteList.TextureInfo.TileSizeInPixelsf;
		}
		
		public override void UpdateEnemyState()
		{	
			if (this.sprite.Position.X < player.sprite.Position.X)
			{
				this.sprite.Position = new Vector2(this.sprite.Position.X-1,this.sprite.Position.Y);
			}
			else if (this.sprite.Position.X > player.sprite.Position.X)
			{
				this.sprite.Position = new Vector2(this.sprite.Position.X+1,this.sprite.Position.Y);;
			}
			if (this.sprite.Position.Y < player.sprite.Position.Y)
			{
				this.sprite.Position = new Vector2(this.sprite.Position.X,this.sprite.Position.Y+1);
			}
			else if (this.sprite.Position.Y > player.sprite.Position.Y)
			{
				this.sprite.Position = new Vector2(this.sprite.Position.X,this.sprite.Position.Y-1);
			}
		}

		public override void Die ()
		{
		}
		
		// not thread-safe!
		public override void Cleanup ()
		{
			if (texInfo != null) 
			{
				texInfo.Dispose();
				texInfo = null;
			}
		}
	}
}
