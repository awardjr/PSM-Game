using System;
using System.Collections;
using Sce.PlayStation.Core;
using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace PSM
{
	public class FishEnemy : Enemy
	{
		private static TextureInfo _texInfo = null;
		
		private FishEnemy (){}

		public FishEnemy (Vector2 pos)
		{
			sprite.Position = pos;
			// sprite.Quad.S = texture_info.TextureSizef; // map 1:1 on screen -- necessary? !!!
			
			if (!_texInfo)
				_texInfo = new TextureInfo ("/Application/assets/fish.png");
			
			enemyHabitat = Enemy.EnemyHabitat.ENEMY_HABITAT_SEA;
			enemyType = Enemy.EnemyType.ENEMY_TYPE_FISH;
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
			if (_texInfo) 
			{
				_texInfo.Dispose();
				_texInfo = null;
			}
		}
	}
}
