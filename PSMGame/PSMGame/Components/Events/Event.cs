using System;

namespace PSM
{
	public abstract class Event
	{
		public double triggerTime;

		protected Event(){}
		public abstract void triggerEvent();
	}
}

