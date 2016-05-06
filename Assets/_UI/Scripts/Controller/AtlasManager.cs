using UnityEngine;
using Update;

namespace UI
{
	public class AtlasManager : MonoBehaviour
	{

		public static Sprite GetSprite(string atlasName, string spriteName){
			AtlasData atlas = null;
			if((atlas = UIPreLoadManager.instance.GetAtlasByAtlasName(atlasName)) == null){
				atlas = Resources.Load<AtlasData> (atlasName);
				UIPreLoadManager.instance.SaveAtlas(atlasName,atlas);
			}


			if(atlas == null){
				Debug.LogError("未找到Atlas：" + atlasName + "！");
				return null;
			}
			foreach(SpriteData _sprite in atlas.spriteList){
				if(_sprite.spriteName == spriteName){
					return _sprite.sprite;
					break;
				}
			}
			Debug.LogError("Sprite is not found");
			return null;
		}
	}
}
