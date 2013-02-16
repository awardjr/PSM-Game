using System;
using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace PSM
{
	public abstract class Enemy
	{
		public enum EnemyHabitat
		{
			ENEMY_HABITAT_SEA,
			ENEMY_HABITAT_SKY
		}

		public enum EnemyType
		{
			ENEMY_TYPE_FISH,
			ENEMY_TYPE_BIRD
		}

		public SpriteUV sprite; // change type to SpriteTile when we get spritesheet assets
		
		public Bounds2 boundingBox;
		
		public EnemyHabitat enemyHabitat;
		public EnemyType enemyType;
		
		public Enemy ()
		{
		}
		public bool isCollidingWith(Bounds2 otherBounds)
		{
			return boundingBox.Overlaps(otherBounds);
		}
		public abstract void UpdateEnemyState();
		public abstract void Die(); // play death animation
		public abstract void Cleanup();
	}
}

