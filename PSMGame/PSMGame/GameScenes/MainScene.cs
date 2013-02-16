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
using PSM;

namespace PSM 
{
	public class MainScene : Scene
	{
		//private PhysicsScene _physics;
	
		public SpriteList Sprites { get; private set; }
	
		private PlayerCreature _playerCreature;
		//private PhysicalSpriteUV _block;
		//private Layer _background;
		//private Layer _main;
		private Node _main;
		private Camera2D SceneCamera;
			
		public MainScene ()
		{
			this.ScheduleUpdate ();
			Vector2 ideal_screen_size = new Vector2(960.0f, 544.0f);
			
			SceneCamera = (Camera2D)Camera;
			SceneCamera.SetViewFromHeightAndCenter(ideal_screen_size.Y, ideal_screen_size / 2.0f);
			//_background = new Layer (SceneCamera, 0.1f, 0.1f);
			//_main = new Layer (SceneCamera);
			_main = new Node();
			/*
			_physics = new PhysicsScene();
			_physics.InitScene();
			*/
			
			_playerCreature = new PlayerCreature();
			_playerCreature.sprite.Position = Camera.CalcBounds().Center;
	//		_player.PositionAll = SceneCamera.CalcBounds().Center;
	
			/*
			_block = new PhysicalSpriteUV(new TextureInfo("/Application/assets/floor.png"), _physics);
			_block.PositionAll = new Vector2(SceneCamera.CalcBounds().Center.X + 10, SceneCamera.CalcBounds().Center.Y - 100);
			_physics.sceneBodies[_block.BodyIndex].SetBodyStatic();
			
			_physics.restitutionCoeff = 0.9f;
			_physics.sceneMax = new Vector2(10000, 10000);
			_physics.sceneMin = new Vector2(-10000, -10000);
			*/
			//AddChild (new SpriteUV(new TextureInfo("/Application/king_water_drop.png")));
			//_main.AddChild (_player);
			
			var background = new SpriteUV(new TextureInfo("/Application/assets/background.png"));
			background.Quad.S = background.TextureInfo.TextureSizef;
			background.CenterSprite();
			//_physics.Gravity = new Vector2(0.0f, -98f);
			background.Position = SceneCamera.CalcBounds().Center;
			//_background.AddChild(background);     
			//AddChild(_background);
			//AddChild(_block);
			AddChild(_main);
			_main.AddChild(background);
		_main.AddChild(_playerCreature.sprite);
			 
			// enemy sprite test code
			var fish0 = new FishEnemy(new Vector2(30.0f,30.0f));
			var fish1 = new FishEnemy(new Vector2(15.0f,15.0f));
			var fish2 = new FishEnemy(new Vector2(100.0f,70.0f));
			
			background.AddChild(FishEnemy.spriteList);
		}
	
		public override void Update (float dt)
		{
			/*
			if(!_player.Joined){
				float movement = PlayerInput.LeftRightAxis();
				if(movement != 0.0f)
				{
					Console.WriteLine("------MOVING------");
					//_physics.sceneBodies[_player.BodyIndex].Velocity = new Vector2(500 * movement, _physics.sceneBodies[_player.BodyIndex].Velocity.Y);
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
					_physics.sceneBodies[_player.BodyIndex].Velocity = new Vector2(0, 500);
					_physics.sceneBodies[_player.BodyIndex].Acceleration = new Vector2(0, 300);
				}
			}
	
			
			Vector2 dummy1 = new Vector2();
	        Vector2 dummy2 = new Vector2();
			_physics.Simulate(-1,ref dummy1,ref dummy2);
			*/
			_playerCreature.Update(dt);
			
			//_block.Update (dt);
	
			GamePadData gamePadData = GamePad.GetData(0);
			if ((gamePadData.Buttons & GamePadButtons.Up) != 0)
			{
				_playerCreature.sprite.Position = new Vector2(_playerCreature.sprite.Position.X,
				                                              _playerCreature.sprite.Position.Y+8);
			}
			if ((gamePadData.Buttons & GamePadButtons.Down) != 0)
			{
				_playerCreature.sprite.Position = new Vector2(_playerCreature.sprite.Position.X,
				                                              _playerCreature.sprite.Position.Y-8);
			}
			if ((gamePadData.Buttons & GamePadButtons.Left) != 0)
			{
				_playerCreature.sprite.Position = new Vector2(_playerCreature.sprite.Position.X-6,
				                                              _playerCreature.sprite.Position.Y);
			}
			if ((gamePadData.Buttons & GamePadButtons.Right) != 0)
			{
				_playerCreature.sprite.Position = new Vector2(_playerCreature.sprite.Position.X+6,
				                                              _playerCreature.sprite.Position.Y);
			}
			
			//SceneCamera.Center = _playerCreature.sprite.Position;
			
			//_background.Update(dt);
			base.Update (dt);
		}
	}
}
