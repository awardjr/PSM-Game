using System;
using System.Collections;
using System.Collections.Generic;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;
using Sce.PlayStation.Core.Environment;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

using Sce.PlayStation.HighLevel.Physics2D;

public class Layer : Node
 {
	public float ScrollRateX { get; set; }
	public float ScrollRateY { get; set; }
	public Camera2D camera {get; private set;}
	
	public Layer (Camera2D camera, float scrollRateX = 1f, float scrollRateY = 1f) 
	{
		this.camera = camera;
		ScrollRateX = scrollRateX ;
		ScrollRateY = ScrollRateY ;
	}
	
	public override void Update(float dt)
	{
		Position = new Vector2(-this.camera.CalcBounds().Point00.X * (ScrollRateX -1), 
		                       -this.camera.CalcBounds().Point00.Y * (ScrollRateY - 1));
	}
}

