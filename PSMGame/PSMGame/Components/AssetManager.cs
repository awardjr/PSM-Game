using System;
using System.Collections.Generic;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Audio;

namespace PSM
{
	public static class AssetManager
	{
		private const string assetPath = "/Application/assets/";  
		
		private static Dictionary<string, Texture2D> Textures;
		private static Dictionary<string, Bgm> Music;
		private static Dictionary<string, Sound> Sounds;
		
		static AssetManager ()
		{
			Textures = new Dictionary<string, Texture2D>();
			Music = new Dictionary<string, Bgm>();
			Sounds = new Dictionary<string, Sound>();
		}
		
		public static Texture2D GetTexture(string texture)
		{
			if(!Textures.ContainsKey(texture))
			{
				
				Textures.Add ( texture, new Texture2D(assetPath + texture + ".png", false));
			} 
			return Textures[texture];
		}
		
		public static Bgm GetBGM (string bgm)
		{
			if(!Music.ContainsKey(bgm))
			{
				Music.Add (bgm, new Bgm(assetPath + "/audio/" + bgm + ".mp3"));
			}
			return Music[bgm];
		}
		
		public static Sound GetSound (string sound)
		{
			if(!Sounds.ContainsKey(sound))
			{
				Sounds.Add(sound, new Sound(assetPath + "/audio/" + sound + ".wav"));
			}
			return Sounds[sound];
		}
		
		public static void Dispose(string asset)
		{
			Textures.Remove(asset);
			Music.Remove(asset);
			Sounds.Remove(asset);
		}
	}
}

