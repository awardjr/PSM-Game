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
		
		public TitleScene ()
		{
			ScheduleUpdate();
			_sceneCamera = (Camera2D)Camera;
			Vector2 ideal_screen_size = new Vector2(960.0f, 544.0f);
			_titleBackground = new SpriteTile(new TextureInfo(AssetManager.GetTexture("titlescreen")));
			_titleBackground.Quad.S = _titleBackground.TextureInfo.TextureSizef;
			_titleBackground.CenterSprite();
			_sceneCamera.SetViewFromHeightAndCenter(ideal_screen_size.Y, ideal_screen_size / 2.0f);
			
			_musicPlayer = AssetManager.GetBGM("title").CreatePlayer();
			_musicPlayer.Play();
			_titleBackground.Position = _sceneCamera.CalcBounds().Center;
			AddChild(_titleBackground);
		}
		
		public override void Update (float dt)
		{
			var  gamePadData = GamePad.GetData(0);
			if((gamePadData.Buttons & GamePadButtons.Start) != 0)
			{
				_musicPlayer.Stop();
				Director.Instance.ReplaceScene( new TransitionSolidFade( new GamePlayScene() )
                    { Duration = 2.0f, Tween = (x) => Math.PowEaseOut( x, 3.0f )} );

			}
		}
	}
}

