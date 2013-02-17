
using Sce.PlayStation.Core;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;



namespace PSM
{
	public class GroundTile : SpriteTile
	{
		public GroundTile (TextureInfo texInfo): base(texInfo)
		{
			
		}
		
		public override void Update(float dt)
		{
			Position -= new Vector2(1f, 0);
			if(Position.X < 0 - TextureInfo.TextureSizei.X)
				Position += new Vector2(960 + TextureInfo.TextureSizei.X, 0);
		}
	}
}
