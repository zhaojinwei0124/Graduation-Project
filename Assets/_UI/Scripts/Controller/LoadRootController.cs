using UnityEngine;

namespace UI
{
	public enum LoadType
	{
		None = 0,
		/// <summary>
		/// 加载条
		/// </summary>
		Loading = 1
	}
		
	[System.Serializable]
	public class LoadContainer
	{
		public LoadType type;
		public GameObject[] loadItems;
	}
		
	public class LoadRootController : MonoBehaviour
	{
			
		public static LoadRootController instance;
		public LoadContainer[] Loads;
		private LoadType currentType = LoadType.None;

		public LoadType CurrentLoad {
			get{ return currentType;}
		}
			
		public void Awake ()
		{
			instance = this;
		}

		public void ShowLoad (LoadType type)
		{
			this.SetLoadActive (currentType, false);
			for (int i = 0; i < Loads.Length; i++) {
				if (Loads [i].type == type) {
					this.SetLoadActive (Loads [i], true);
				}
			}
			currentType = type;
		}
		
		public void SetLoadActive (LoadType type, bool isActive)
		{
			for (int i = 0; i < Loads.Length; i++) {
				if (Loads [i].type == type) {
					this.SetLoadActive (Loads [i], isActive);
				}
			}
		}

		public void SetLoadActive (LoadContainer load, bool isActive)
		{
			for (int i = 0; i < load.loadItems.Length; i++) {
				load.loadItems [i].SetActive (isActive);
			}
		}

		public void CloseAllLoad ()
		{
			ShowLoad (LoadType.None);
		}

		public void Reset ()
		{
			ShowLoad (LoadType.None);
		}
	}
}
