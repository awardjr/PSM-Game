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
		this.ScheduleUpdate ();
		Vector2 ideal_screen_size = new Vector2(960.0f, 544.0f);
		
		SceneCamera = (Camera2D)Camera;
		SceneCamera.SetViewFromHeightAndCenter(ideal_screen_size.Y, ideal_screen_size / 2.0f);
		_background = new Layer (SceneCamera, 1f, 1f);
		_main = new Layer (SceneCamera);
		
		_physics = new PhysicsScene();
		_physics.InitScene();
		PhysicsShape shape = new PhysicsShape(10);
		PhysicsBody body = new PhysicsBody(shape, 100);
		
		_physics.sceneShapes[0] = shape; 
		_physics.sceneBodies[0] = body;
		_physics.sceneBodies[0].rotation = 0.1f;
		_physics.sceneBodies[0].position = SceneCamera.CalcBounds().Center;
		
		PhysicsShape shape2 = new PhysicsShape(50);
		PhysicsBody body2 = new PhysicsBody(shape2, 10);
		
		_physics.sceneShapes[1] = shape2;
		_physics.sceneBodies[1] = body2;
		_physics.sceneBodies[1].position = new Vector2(SceneCamera.CalcBounds().Center.X + 10, SceneCamera.CalcBounds().Center.Y - 100);
		_physics.sceneBodies[1].SetBodyStatic();
		_physics.sceneBodies[1].SetBodyKinematic();
		
		_physics.restitutionCoeff = 0.9f;
		_physics.sceneMax = new Vector2(10000, 10000);
		_physics.sceneMin = new Vector2(-10000, -10000);
		_physics.numBody = 2;
		_physics.numShape = 2;
		
		_player = new SpriteUV (new TextureInfo ("/Application/assets/square.png"));
		_player.Quad.S = _player.TextureInfo.TextureSizef;
		_player.Position = Camera.CalcBounds().Center;
		
		//AddChild (new SpriteUV(new TextureInfo("/Application/king_water_drop.png")));
		_main.AddChild (_player);
		var background = new SpriteUV(new TextureInfo("/Application/assets/background.png"));
		background.Quad.S = background.TextureInfo.TextureSizef;
		background.CenterSprite();
		_physics.Gravity = new Vector2(0.0f, -98f);
		background.Position = SceneCamera.CalcBounds().Center;
		_background.AddChild(background);     
		AddChild(_background);
		AddChild(_main);
	
		
	}

	public override void Update (float dt)
	{
		 Vector2 dummy1 = new Vector2();
         Vector2 dummy2 = new Vector2();
		_physics.Simulate(-1,ref dummy1,ref dummy2);
		_player.Position = _physics.sceneBodies[0].position;
		_player.Angle = _physics.sceneBodies[0].rotation;
		SceneCamera.Center = _player.Position;
		_background.Update(dt);
		base.Update (dt);
		//	sprite.Position  += new Vector2(2,0);
	}
}

