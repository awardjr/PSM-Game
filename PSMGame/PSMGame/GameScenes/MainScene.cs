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

	private PhysicalSpriteUV _player;
	private PhysicalSpriteUV _block;
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
		
		_player = new PhysicalSpriteUV (new TextureInfo ("/Application/assets/circle.png"), _physics, true);
		_player.Position = Camera.CalcBounds().Center;
		_player.PositionAll = SceneCamera.CalcBounds().Center;

		
		_block = new PhysicalSpriteUV(new TextureInfo("/Application/assets/floor.png"), _physics);
		_block.PositionAll = new Vector2(SceneCamera.CalcBounds().Center.X + 10, SceneCamera.CalcBounds().Center.Y - 100);
		_physics.sceneBodies[_block.BodyIndex].SetBodyStatic();
		_physics.sceneBodies[_block.BodyIndex].SetBodyKinematic();
		
		_physics.restitutionCoeff = 0.9f;
		_physics.sceneMax = new Vector2(10000, 10000);
		_physics.sceneMin = new Vector2(-10000, -10000);
		
		//AddChild (new SpriteUV(new TextureInfo("/Application/king_water_drop.png")));
		_main.AddChild (_player);
		var background = new SpriteUV(new TextureInfo("/Application/assets/background.png"));
		background.Quad.S = background.TextureInfo.TextureSizef;
		background.CenterSprite();
		_physics.Gravity = new Vector2(0.0f, -98f);
		background.Position = SceneCamera.CalcBounds().Center;
		_background.AddChild(background);     
		AddChild(_background);
		AddChild(_block);
		AddChild(_main);
	
		
	}

	public override void Update (float dt)
	{
		if(!_player.Joined){
			float movement = PlayerInput.LeftRightAxis();
			if(movement != 0.0f)
			{
				Console.WriteLine("------MOVING------");
				_physics.sceneBodies[_player.BodyIndex].Velocity = new Vector2(100 * movement, _physics.sceneBodies[_player.BodyIndex].Velocity.Y);
			}
			
			if(_player.Intersects((uint)_block.BodyIndex))
			{
				_player.AddJoint((uint)_block.BodyIndex);
			}
		}
		else
		{
			if(PlayerInput.JumpButton())
			{
				System.Console.WriteLine("------JUMPING------");
				_player.RemoveJoint();
				_physics.sceneBodies[_player.BodyIndex].Velocity = new Vector2(0, 250);
				_physics.sceneBodies[_player.BodyIndex].Acceleration = new Vector2(0, 150);
			}
		}

		
		Vector2 dummy1 = new Vector2();
        Vector2 dummy2 = new Vector2();
		_physics.Simulate(-1,ref dummy1,ref dummy2);
		
		_player.Update(dt);
		
		_block.Update (dt);
		
		SceneCamera.Center = _player.Position;
		
		_background.Update(dt);
		base.Update (dt);
	}
}

