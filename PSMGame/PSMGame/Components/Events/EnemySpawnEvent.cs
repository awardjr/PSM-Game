using System;
using System.Collections;
using System.Collections.Generic;
using Sce.PlayStation.Core;
using Sce.PlayStation.HighLevel.GameEngine2D;

namespace PSM
{
	public class EnemySpawnEvent : Event
	{
		private Enemy.EnemyType enemyType;
		private Node parent;
		private PlayerCreature player;
		public static int maxX=960, maxY=544;
		
		private EnemySpawnEvent(){}
		public EnemySpawnEvent(double triggerTime, Enemy.EnemyType enemyType, Node parentLayer, PlayerCreature player)
		{
			this.triggerTime = triggerTime;
			this.enemyType = enemyType;
			this.parent = parentLayer;
			this.player = player;
		}
		public override void triggerEvent()
		{
			System.Console.WriteLine("TRIGGER!");
			Random rand = new Random();
			
			int x = rand.Next(maxX);
			int y = rand.Next(maxY);
			
			if (this.enemyType == Enemy.EnemyType.ENEMY_TYPE_FISH)
			{
				int coinFlip = rand.Next(2);
				
				FishEnemy enemy;
				if (coinFlip == 0)
				{
				   	enemy = new FishEnemy(new Vector2(0,y),player);
				}
				else
				{
					enemy = new FishEnemy(new Vector2(maxX,y),player);
				}
				//this.parent.AddChild(enemy.sprite);
			}
		}
	}
}

