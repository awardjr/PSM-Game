/* SCE CONFIDENTIAL
 * PlayStation(R)Suite SDK 0.98.2
 * Copyright (C) 2012 Sony Computer Entertainment Inc.
 * All Rights Reserved.
 */

//#define EASY_SETUP
//#define EXTERNAL_INPUT

using System.Collections;
using System.Collections.Generic;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;
using Sce.PlayStation.Core.Environment;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

static class PSMGame
{
	static void Main( string[] args )
	{

		Sce.PlayStation.Core.Graphics.GraphicsContext context = new Sce.PlayStation.Core.Graphics.GraphicsContext();

		uint sprites_capacity = 500;

		// maximum number of vertices that can be used in debug draws
		uint draw_helpers_capacity = 400;

		// initialize GameEngine2D's singletons, passing context from outside
		Director.Initialize( sprites_capacity, draw_helpers_capacity, context );

		Director.Instance.GL.Context.SetClearColor( Colors.Grey20 );

		// set debug flags that display rulers to debug coordinates
//		Director.Instance.DebugFlags |= DebugFlags.DrawGrid;
		// set the camera navigation debug flag (press left alt + mouse to navigate in 2d space)
		Director.Instance.DebugFlags |= DebugFlags.Navigate; 

		// create a new scene
		//var scene = new Scene();
		
		var scene = new MainScene();
		// set the camera so that the part of the word we see on screen matches in screen coordinates
		scene.Camera.SetViewFromViewport();

		Director.Instance.RunWithScene( scene, true );
		
		while ( !Input2.GamePad0.Cross.Press )
		{
			Sce.PlayStation.Core.Environment.SystemEvents.CheckEvents();

			#if EXTERNAL_INPUT

			// it is not needed but you can set external input data if you want

			List<TouchData> touch_data_list = Touch.GetData(0);
			Input2.Touch.SetData( 0, touch_data_list );

			GamePadData pad_data = GamePad.GetData(0);
			Input2.GamePad.SetData( 0, pad_data );

			#endif // #if EXTERNAL_INPUT
			
			Director.Instance.Update();
			Director.Instance.Render();
			Director.Instance.GL.Context.SwapBuffers();
			Director.Instance.PostSwap(); 
		}
		Director.Terminate();

		System.Console.WriteLine( "Bye!" );
	}
}

