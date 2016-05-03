
using UnityEngine;
using System.IO;
using System.Collections.Generic;
using UnityEditor;

namespace UI
{
	public class AtlasTools : MonoBehaviour
	{
		[MenuItem("MenuTools/图集管理/生成图集信息")]
		public static void CreatAtlasData ()
		{
			DirectoryInfo rootFile = new DirectoryInfo ("Assets/_UI/Textures");
			DirectoryInfo[] atlasDirList = rootFile.GetDirectories ("*", SearchOption.TopDirectoryOnly);
			int count = rootFile.GetFiles ("*.png", SearchOption.AllDirectories).Length;
			count += rootFile.GetFiles ("*.jpg", SearchOption.AllDirectories).Length;
			int now = 0;
			string log = "----------图集处理结果---------\n";
			try {
				foreach (DirectoryInfo atlasFile in atlasDirList) {
					List<SpriteData> spriteList = new List<SpriteData> ();
					List<FileInfo> textureList = new List<FileInfo> ();
					textureList.AddRange (atlasFile.GetFiles ("*.png", SearchOption.AllDirectories));
					textureList.AddRange (atlasFile.GetFiles ("*.jpg", SearchOption.AllDirectories));
					log += "**********添加图集:" + atlasFile.Name + "**********\n";
					foreach (FileInfo spriteFile in textureList) {
						now ++;
						EditorUtility.DisplayProgressBar ("图集信息生成中", "正在添加“" + spriteFile.Name + "”......" + now + "/" + count, (float)now / (float)count);
                        TextureImporter ti = (TextureImporter)TextureImporter.GetAtPath (spriteFile.FullName.Replace("\\","/").Replace (Application.dataPath, "Assets"));
						ti.textureType = TextureImporterType.Sprite;
						ti.spritePackingTag = atlasFile.Name;
						ti.mipmapEnabled = false;
						if (atlasFile.Name == "Atlas_Menu") {
							ti.textureFormat = TextureImporterFormat.RGBA32;
						} else {
							ti.textureFormat = TextureImporterFormat.RGBA32;
						}
						ti.SaveAndReimport ();
						Sprite ob = AssetDatabase.LoadAssetAtPath (ti.assetPath, typeof(Sprite)) as Sprite;
						spriteList.Add (new SpriteData (ob.name, ob));
						log += ob.name + "\n";
					}
					AtlasData iAtlas = ScriptableObject.CreateInstance<AtlasData> ();
					iAtlas.atlasName = atlasFile.Name;
					iAtlas.spriteList = spriteList;
					AssetDatabase.CreateAsset (iAtlas, "Assets/_UI/Prefabs/Atlas/Resources/" + atlasFile.Name + ".asset");
				}
			} catch(UnityException e) {
				EditorUtility.ClearProgressBar ();
				Debug.LogError(e);
			}
			AssetDatabase.SaveAssets ();
			AssetDatabase.Refresh ();
			EditorUtility.ClearProgressBar ();
			log += "添加图集：" + atlasDirList.Length + "个，添加图片：" + count + "个";
			Debug.Log (log);
		}

	}
}
