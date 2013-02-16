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
	public class MapTestScene : Scene
	{
		private SpriteTile _sprite;
		private SpriteList _ground;
		private Random _random;
		public Camera2D SceneCamera;
   		public Bgm bgm1;
		public Bgm bgm2;
		public BgmPlayer player;
		public MapTestScene ()
		{
			this.ScheduleUpdate ();
		
			_random = new Random();
		//	bgm1 = new Bgm("/Application/assets/music1.mp3");
			//bgm2 = new Bgm("/Application/assets/root.mp3");
		//	player = bgm1.CreatePlayer();
			//player.Play ();
			SceneCamera = (Camera2D)Camera;
			var texInfo = new TextureInfo(AssetManager.GetTexture ("spritesheet"),new Vector2i(2,2), TRS.Quad0_1);
			_ground = new SpriteList(texInfo);
			
			 _sprite = new SpriteTile(texInfo);
			
			_ground.AddChild(_sprite);
			_sprite.Quad.S = texInfo.TextureSizef; 

		_sprite.CenterSprite();
			_sprite.TileIndex2D = new Vector2i(0,0);
			GenerateMap();
			AddChild(_ground);
		}
		
		public void GenerateMap()
		{
			for(int i = 0; i < 50; i++)
			{
				_sprite = new SpriteTile(_ground.TextureInfo);
				_ground.AddChild(_sprite);
				_sprite.TileIndex1D = _random.Next(0,4);
				_sprite.Quad.S = _sprite.TextureInfo.TextureSizef;
				_sprite.Position = new Vector2(SceneCamera.CalcBounds().Point00.X + i * _sprite.TextureInfo.TextureSizef.X, SceneCamera.CalcBounds().Point00.Y);	
			}
		}
		public override void Update (float dt)
		{
			_sprite.TileIndex1D +=1;
			if(_sprite.TileIndex1D > 3)
			{
				_sprite.TileIndex1D = 0;
			}
			
			if (Input2.GamePad0.Left.Down)
			{
			//	player.Dispose();
			//	player = bgm1.CreatePlayer();
			//	player.Play();
			}
			
			if (Input2.GamePad0.Right.Down)
			{
			//	player.Dispose();
				//player = bgm2.CreatePlayer();
			//	player.Play();
			}
		//	SceneCamera.Center = _sprite.Position;
			base.Update (dt);
		}
	}
}

