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
		public Camera2D SceneCamera;
   		public Bgm bgm1;
		public Bgm bgm2;
		public BgmPlayer player;
		public MapTestScene ()
		{
			this.ScheduleUpdate ();
		
			bgm1 = new Bgm("/Application/assets/music1.mp3");
			bgm2 = new Bgm("/Application/assets/root.mp3");
			player = bgm1.CreatePlayer();
			player.Play ();
			SceneCamera = (Camera2D)Camera;
			var texInfo = new TextureInfo(new Texture2D("/Application/assets/spritesheet.png", false),new Vector2i(2,2), TRS.Quad0_1);
			_ground = new SpriteList(texInfo);
			
			 _sprite = new SpriteTile(texInfo);
			
			_ground.AddChild(_sprite);
			_sprite.Quad.S = texInfo.TextureSizef; 

		_sprite.CenterSprite();
			_sprite.TileIndex2D = new Vector2i(0,0);
			AddChild(_ground);
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
				player.Dispose();
				player = bgm1.CreatePlayer();
				player.Play();
			}
			
			if (Input2.GamePad0.Right.Down)
			{
				player.Dispose();
				player = bgm2.CreatePlayer();
				player.Play();
			}
			SceneCamera.Center = _sprite.Position;
			base.Update (dt);
		}
	}
}

