using System;
using System.Collections.Generic;
using Sce.PlayStation.HighLevel.GameEngine2D;

namespace PSM
{
	public class EventManager
	{
		private double _startTime;
		private List<Event> _eventList;
		private int _currentIndex;
		
		public EventManager (Node parent, PlayerCreature player)
		{			
			_eventList = new List<Event>();
			
			EnemySpawnEvent enemySpawn0 = new EnemySpawnEvent(1.0f, Enemy.EnemyType.ENEMY_TYPE_FISH, parent, player);
			EnemySpawnEvent enemySpawn1 = new EnemySpawnEvent(5.0f, Enemy.EnemyType.ENEMY_TYPE_FISH, parent, player);
			EnemySpawnEvent enemySpawn2 = new EnemySpawnEvent(15.0f, Enemy.EnemyType.ENEMY_TYPE_FISH, parent, player);
			
			_eventList.Add(enemySpawn0);
			_eventList.Add(enemySpawn1);
			_eventList.Add(enemySpawn2);
			
			_currentIndex = 0;
			_startTime = Director.Instance.DirectorTime;
		}

		public void Update ()
		{
			double currentTime = Director.Instance.DirectorTime;
			//double elapsedTime = currentTime - _startTime;
			
			if (_currentIndex > _eventList.Count-1)
				return;
			
			Event currentEvent = _eventList[_currentIndex];
			if (currentTime > currentEvent.triggerTime + _startTime)
			{
				currentEvent.triggerEvent();
				_currentIndex++;
			}
		}
	}
}

