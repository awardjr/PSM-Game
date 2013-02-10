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

public class MainScene : Scene
{
	private PhysicsScene _physics;

	public SpriteList Sprites { get; private set; }

	private SpriteUV _player;
	private Layer _background;
	private Layer _main;
	private Camera2D SceneCamera;
		
	public MainScene ()
	{
		Vector2 ideal_screen_size = new Vector2(960.0f, 544.0f);
		this.ScheduleUpdate ();
		SceneCamera = (Camera2D)Camera;
		SceneCamera.SetViewFromHeightAndCenter(ideal_screen_size.Y, ideal_screen_size / 2.0f);
		_background = new Layer (SceneCamera, 0.1f, 0.05f);
		_main = new Layer (SceneCamera);
		
		
		_player = new SpriteUV (new TextureInfo ("/Application/assets/square.png"));
		_player.Quad.S = _player.TextureInfo.TextureSizef;
		_player.Position = Camera.CalcBounds().Center;
		//AddChild (new SpriteUV(new TextureInfo("/Application/king_water_drop.png")));
		_main.AddChild (_player);
		var background = new SpriteUV(new TextureInfo("/Application/assets/background.png"));
		background.Quad.S = background.TextureInfo.TextureSizef;
		background.CenterSprite();
		background.Position = Camera.CalcBounds().Center;
		_background.AddChild(background);     
		AddChild(_background);
		AddChild(_main);
		
	}

	public override void Update (float dt)
	{
		SceneCamera.Center += new Vector2 (1, 0);
		_background.Update(dt);
		base.Update (dt);
		//	sprite.Position  += new Vector2(2,0);
	}
}

