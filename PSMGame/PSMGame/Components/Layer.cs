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
	public Vector2 Offset { get; set;}
	public Camera2D Camera {get;  set;}
	
	public Layer (Camera2D camera, float scrollRateX = 1f, float scrollRateY = 1f) 
	{
		Offset = new Vector2(0,0);
		this.Camera = camera;
		ScrollRateX = scrollRateX ;
		ScrollRateY = ScrollRateY ;
	}
	
	public override void Update(float dt)
	{
		Position = new Vector2(-this.Camera.CalcBounds().Point00.X * (ScrollRateX -1) - Offset.X, -this.Camera.CalcBounds().Point00.Y * (ScrollRateY - 1) - Offset.Y);
		
		foreach(Node node in Children)
		{
			node.Update (dt);	
		}
	}
}

