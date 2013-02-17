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
		private Dictionary<string, Animation> Animations;
		private Animation _currentAnimation;
		private BgmPlayer _musicPlayer;
		private Timer _waitTimer;
		private bool _secondSequence;
		
		public EndScene ()
		{
			_waitTimer = new Timer();
			ScheduleUpdate();
			_sceneCamera = (Camera2D)Camera;
			Vector2 ideal_screen_size = new Vector2(960.0f, 544.0f);
			_sceneCamera.SetViewFromHeightAndCenter(ideal_screen_size.Y, ideal_screen_size / 2.0f);
			
			_groundLayer = new Layer(_sceneCamera);
			
			Animations = new Dictionary<string, Animation>();
			var texInfo = new TextureInfo(AssetManager.GetTexture("catanimation"), new Vector2i(5,1),TRS.Quad0_1);
			_currentAnimation = new Animation(0, 5, 0.1f, false);
			_currentAnimation.Play();
			
			_cat = new SpriteTile(texInfo);
			_cat.TileIndex1D = _currentAnimation.CurrentFrame;
			_cat.Quad.S = new Vector2(258, 214);
			_cat.CenterSprite();
			_cat.Position = new Vector2(_sceneCamera.CalcBounds().Point00.X, _sceneCamera.CalcBounds().Point00.Y + _cat.TextureInfo.TextureSizef.Y/2 +64 );
			
			var background = new SpriteTile(new TextureInfo(AssetManager.GetTexture("background_paper")));
			background.Quad.S = background.TextureInfo.TextureSizef;
			background.CenterSprite();
			background.Position = _sceneCamera.CalcBounds().Center;
			
			for(var i = 0; i < 5; i++)
			{
				var _sprite = new GroundTile(new TextureInfo(AssetManager.GetTexture("ground_tile")));
				_groundLayer.AddChild(_sprite);
				_sprite.Quad.S = _sprite.TextureInfo.TextureSizef;
				_sprite.Position = new Vector2(_sceneCamera.CalcBounds().Point00.X + i * _sprite.TextureInfo.TextureSizef.X, _sceneCamera.CalcBounds().Point00.Y - _sprite.TextureInfo.TextureSizef.Y / 2);	
			}
			_musicPlayer = AssetManager.GetBGM("endscreen").CreatePlayer();
			_musicPlayer.Play();
			AddChild(background);
			AddChild (_cat);
			AddChild (_groundLayer);
		}
		
		public override void Update (float dt)
		{
			_currentAnimation.Update(dt);
			_cat.TileIndex1D = _currentAnimation.CurrentFrame;
			if(!_secondSequence) {
				if(_cat.Position.X < _sceneCamera.Center.X)
				{
					_cat.Position += new Vector2(0.8f, 0);
				} else {
					_currentAnimation.Stop();
					_secondSequence = true;
					_waitTimer.Reset();
				}
			} else if(_waitTimer.Milliseconds() > 3500){
				_cat.Position += new Vector2(2, 2);
				_currentAnimation.Play ();
			}
			
			if(_secondSequence && _waitTimer.Milliseconds() > 15000)
			{
				_waitTimer.Reset();
				_musicPlayer.Dispose();
				Director.Instance.ReplaceScene( new TransitionSolidFade( new TitleScene() )
                    { Duration = 2.0f, Tween = (x) => Math.PowEaseOut( x, 3.0f )} );	
			}
			
			base.Update (dt);
		}
	}
}

