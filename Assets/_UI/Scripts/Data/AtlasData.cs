
using UnityEngine;
using System.Collections.Generic;

namespace UI
{
	[System.Serializable]
	public class SpriteData
	{
		public string spriteName;
		public Sprite sprite;

		public SpriteData (string _name, Sprite _sprite)
		{
			spriteName = _name;
			sprite = _sprite;
		}
	}
	
	[System.Serializable]
	public class AtlasData:ScriptableObject
	{
		public string atlasName;
		public List<SpriteData> spriteList;
	}
}
