using UnityEngine;
using System.Collections.Generic;

namespace UI {
	public enum MenuType {
		None = 0,
		Game1 = 1,
		Game2 = 2,
		Game3 = 3,
		Main,
		SelectLevel,
	}

	public enum MenuName {
		None = 0,
		GameBoard1 = 1,
		GameBoard2 = 2,
		GameBoard3 = 3,
		MainMenuBoard,
		CoinBoard,
		SelectLevelBoard,
	}

	[System.Serializable]
	public class MenuContainer {
		public MenuType type;
		public MenuName[] menuItems;
	}

	public class MenuRootController : MonoBehaviour {
		public static MenuRootController instance;
		public MenuContainer[] Menus;
		private Dictionary<MenuName, GameObject> MenuGO = new Dictionary<MenuName, GameObject>();

		public void Awake() {
			instance = this;
		}

		/// <summary>
		/// 显示界面
		/// </summary>
		/// <param name="type">Type.</param>
		/// <param name="isActive">If set to <c>true</c> is active.</param>
		public void SetMenuActive(MenuType type, bool isActive) {
			for (int i = 0; i < Menus.Length; i++)
			{
				if (Menus[i].type == type)
				{
					this.SetMenuActive(Menus[i], isActive);
				}
			}
		}

		private void SetMenuActive(MenuContainer menu, bool isActive) {
			for (int i = 0; i < menu.menuItems.Length; i++)
			{
				if (!MenuGO.ContainsKey(menu.menuItems[i]))
				{
					MenuGO.Add(menu.menuItems[i], null);
				}
				if (MenuGO[menu.menuItems[i]] == null)
				{
					GameObject iMenu = GameObject.Find(menu.menuItems[i].ToString());
					if (iMenu == null)
					{
						iMenu = LoadMenu(menu.menuItems[i].ToString());
					}
					MenuGO[menu.menuItems[i]] = iMenu;
				}
				GameObject go = MenuGO[menu.menuItems[i]];
				go.transform.SetSiblingIndex(i);
				go.SetActive(isActive);
			}
		}

		private GameObject LoadMenu(string menuPath) {
			Object go = Resources.Load(menuPath);
			GameObject iMenu = Instantiate(go) as GameObject;
			iMenu.name = go.name;
			RectTransform rt = iMenu.GetComponent<RectTransform>();
			rt.SetParent(transform);
			rt.localScale = Vector3.one;
			rt.localPosition = Vector3.zero;
			rt.sizeDelta = Vector2.zero;
			rt.localRotation = Quaternion.identity;
			return iMenu;
		}

		/// <summary>
		/// 清理界面
		/// </summary>
		public void ClearMenuBoards() {
			foreach (GameObject go in MenuGO.Values)
			{
				DestroyImmediate(go.gameObject);
			}
			MenuGO.Clear();
		}

		/// <summary>
		/// 重置MenuRootController数据
		/// </summary>
		public void Reset() {
			ClearMenuBoards();
		}
	}
}
