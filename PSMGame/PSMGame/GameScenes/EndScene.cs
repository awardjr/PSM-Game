using System.Collections;
using System.Collections.Generic;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Audio;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace PSM
{
	public class EndScene : Scene
	{
		private SpriteTile _cat;
		private Layer _groundLayer;
		private Camera2D _sceneCamera;
		
		public EndScene ()
		{
			_sceneCamera = (Camera2D)Camera;
			Vector2 ideal_screen_size = new Vector2(960.0f, 544.0f);
			_sceneCamera.SetViewFromHeightAndCenter(ideal_screen_size.Y, ideal_screen_size / 2.0f);
			_groundLayer = new Layer(_sceneCamera);
			
			_cat = new SpriteTile(new TextureInfo(AssetManager.GetTexture("catanimation")));
			_cat.Quad.S = _cat.TextureInfo.TextureSizef;
			_cat.Position = new Vector2(_sceneCamera.CalcBounds().Point00.X, _sceneCamera.CalcBounds().Point00.Y - _cat.TextureInfo.TextureSizef.Y);	
			
			for(var i = 0; i < 5; i++)
			{
				var _sprite = new GroundTile(new TextureInfo(AssetManager.GetTexture("ground_tile")));
				_groundLayer.AddChild(_sprite);
				_sprite.Quad.S = _sprite.TextureInfo.TextureSizef;
				_sprite.Position = new Vector2(_sceneCamera.CalcBounds().Point00.X + i * _sprite.TextureInfo.TextureSizef.X, _sceneCamera.CalcBounds().Point00.Y - _sprite.TextureInfo.TextureSizef.Y / 2);	
			}
			AddChild (_cat);
			AddChild (_groundLayer);
		}
	}
}

