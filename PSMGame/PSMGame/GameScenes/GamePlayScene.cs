using System;
using System.Collections;
using System.Collections.Generic;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Audio;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

using Sce.PlayStation.HighLevel.Physics2D;

namespace PSM
{
	public class GamePlayScene : Scene
	{
		private SpriteTile _sprite;
		private SpriteList _ground;
		private SpriteTile _water;
		
		private Random _random;
		private int _waterLevel;
		
		public Camera2D SceneCamera;
   		public Bgm bgm1;
		public Bgm bgm2;
		public BgmPlayer player;
		
		private Layer _backgroundLayer;
		private Layer _groundLayer;
		
		private Animation animation;
		public GamePlayScene ()
		{
			this.ScheduleUpdate ();
		
			_waterLevel = 272;
			_random = new Random();
			
			Vector2 ideal_screen_size = new Vector2(960.0f, 544.0f);
			SceneCamera = (Camera2D)Camera;
			
			SceneCamera.SetViewFromHeightAndCenter(ideal_screen_size.Y, ideal_screen_size / 2.0f);
			
			_backgroundLayer = new Layer(SceneCamera, 0, 0);
			var background = new SpriteTile(new TextureInfo(AssetManager.GetTexture("background_paper")));
			_backgroundLayer.AddChild(background);
			background.Quad.S = background.TextureInfo.TextureSizef;
			background.CenterSprite();
			background.Position = SceneCamera.CalcBounds().Center;
			
			animation = new Animation(0, 3, 0.1f, true);
			
			_water = new SpriteTile(new TextureInfo(AssetManager.GetTexture("water")));
			_water.Quad.S = _water.TextureInfo.TextureSizef;
			_water.CenterSprite();
			_water.Position = SceneCamera.CalcBounds().Center + new Vector2(0, -244);
			_water.BlendMode = BlendMode.Multiplicative;
			
			_groundLayer = new Layer(SceneCamera, 1, 1);
		
			var texInfo = new TextureInfo(AssetManager.GetTexture ("ground_tile"));
			_ground = new SpriteList(texInfo);
			_sprite = new SpriteTile(texInfo);
			_ground.AddChild(_sprite);
			
			_sprite.Quad.S = texInfo.TextureSizef; 
			_sprite.CenterSprite();
			_sprite.TileIndex2D = new Vector2i(0,0);
			GenerateMap();
			AddChild (_backgroundLayer);
			AddChild(_groundLayer);
			AddChild(_water);
		}
		
		public void GenerateMap()
		{
			for(int i = 0; i < 5; i++)
			{
				_sprite = new GroundTile(_ground.TextureInfo);
				_groundLayer.AddChild(_sprite);
			//	_sprite.TileIndex1D = _random.Next(0,4);
				_sprite.Quad.S = _sprite.TextureInfo.TextureSizef;
				_sprite.Position = new Vector2(SceneCamera.CalcBounds().Point00.X + i * _sprite.TextureInfo.TextureSizef.X, SceneCamera.CalcBounds().Point00.Y - _sprite.TextureInfo.TextureSizef.Y / 2);	
			}
		}
		public override void Update (float dt)
		{
			animation.Update(dt);
			
		//	_sprite.TileIndex1D = animation.CurrentFrame;
			
			if (Input2.GamePad0.Left.Down)
			{
			}
			
			if (Input2.GamePad0.Right.Down)
			{
			}
			_backgroundLayer.Update(dt);
			_groundLayer.Update (dt);
			base.Update (dt);
		}
	}
}

