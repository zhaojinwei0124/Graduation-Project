using UnityEngine;
using System;
using System.Collections.Generic;

namespace Update
{
	[Serializable]
	public class PreloadData : ScriptableObject
	{
		public List<string> atlasName; 	//UIAtlas名称
		public List<string> fontName;	//TTF字体名称
		public List<string> musicName;	//音乐名称
	}
}
