using System;

namespace PSM
{
	public class Animation
	{
		private float _currentFrame;
		
		public bool IsPlaying { get; private set;}
		public int FirstFrame { get; private set;}
		public int LastFrame {get; private set;}
		public int NumFrames 
		{ 
			get {return LastFrame - FirstFrame;	}
			private set {}
		}
		
		public int CurrentFrame 
		{
			get {return (int)_currentFrame;} 
			set 
			{
				if(CurrentFrame >= FirstFrame && CurrentFrame <= LastFrame)
				{
					_currentFrame = value;
				}
			}
		}
		
		public float Rate { get; set;}
		public bool Loop {get; set;}
		
		
		public Animation (int firstFrame, int lastFrame, float rate, bool loop)
		{
			FirstFrame = firstFrame;
			LastFrame = lastFrame;
			_currentFrame = firstFrame;
			Rate = rate;
			Loop = loop;
			IsPlaying = false;
		}
		
		public void Play() 
		{
			IsPlaying = true;
		}
		
		public void Stop()
		{
			IsPlaying = false;	
		}
		
		public void Update (float dt)
		{
			var frames = dt/Rate;
			_currentFrame += frames;
			
			if(_currentFrame > LastFrame)
			{
				_currentFrame = _currentFrame - LastFrame;	
				
			}
		}
	}
}

