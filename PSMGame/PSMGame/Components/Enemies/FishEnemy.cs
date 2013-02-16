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

		private FishEnemy (){}

		public FishEnemy (Vector2 pos)
		{
			enemyHabitat = Enemy.EnemyHabitat.ENEMY_HABITAT_SEA;
			enemyType = Enemy.EnemyType.ENEMY_TYPE_FISH;
			sprite = new SpriteUV();
			
			if (texInfo == null)
			{
				texInfo = new TextureInfo ("/Application/assets/fish.png");
			}
			
			if (spriteList == null)
			{
				spriteList = new SpriteList(texInfo);
			}
			
			spriteList.AddChild(sprite);
			
			sprite.GetContentWorldBounds(ref boundingBox);
			sprite.Quad.S = texInfo.TextureSizef; // map 1:1 on screen -- necessary? !!!
			sprite.Position = pos;
		}

		public override void UpdateEnemyState ()
		{
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
