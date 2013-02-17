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
	public class TitleScene : Scene
	{
		private Camera2D _sceneCamera;
		private SpriteTile _titleBackground;
		private BgmPlayer _musicPlayer;
		private Timer _sleepTimer;
		private bool _nextSequence;
		
		public TitleScene ()
		{
			ScheduleUpdate();
			_nextSequence = false;
			_sleepTimer = new Timer();
			
			_sceneCamera = (Camera2D)Camera;
			Vector2 ideal_screen_size = new Vector2(960.0f, 544.0f);
			_titleBackground = new SpriteTile(new TextureInfo(AssetManager.GetTexture("titlescreen")));
			_titleBackground.Quad.S = _titleBackground.TextureInfo.TextureSizef;
			_titleBackground.CenterSprite();
			_sceneCamera.SetViewFromHeightAndCenter(ideal_screen_size.Y, ideal_screen_size / 2.0f);
			
			var kid = new SpriteTile(new TextureInfo(AssetManager.GetTexture("kid")));
			kid.Quad.S = kid.TextureInfo.TextureSizef;
			kid.CenterSprite();
			kid.Position = _sceneCamera.CalcBounds().Center;
			
			_musicPlayer = AssetManager.GetBGM("title").CreatePlayer();
			_musicPlayer.Play();
			_titleBackground.Position = _sceneCamera.CalcBounds().Center;
			AddChild(kid);
			AddChild(_titleBackground);
		}
		
		public override void Update (float dt)
		{
			var  gamePadData = GamePad.GetData(0);
			if((gamePadData.Buttons & GamePadButtons.Start) != 0)
			{
				_nextSequence = true;
				
			}
			
			
			if((gamePadData.Buttons & GamePadButtons.Start) != 0)
			{
				_nextSequence = true;
				_sleepTimer.Reset();	
			}
	
			if(_nextSequence)
			{
				_titleBackground.Position += new Vector2(0, 8);
			}
			
			if(_nextSequence && _sleepTimer.Seconds() >= 3)
			{
				_sleepTimer.Reset();
				_musicPlayer.Dispose();
				Director.Instance.ReplaceScene( new TransitionDirectionalFade( new GamePlayScene() )
                    { Duration = 1.0f, Tween = (x) => Math.PowEaseOut( x, 3.0f )} );
			}
		}
	}
}

