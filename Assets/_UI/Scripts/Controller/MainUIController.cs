using UnityEngine;
using System.Collections.Generic;

namespace UI
{

	public enum UIType{
		None = 0,
		Tip = 1,
		Load = 2,
		Menu = 3,
		Dialog = 4
	}

	public class MainUIController : MonoBehaviour
	{
		public delegate void OnChangeMenu (MainUIType last,MainUIType now);

		public Camera UICamera;

		public OnChangeMenu OnBack = null;
		public OnChangeMenu OnShow = null;
		private Stack<MainUIType> MainUIStack = new Stack<MainUIType> ();
		private static MainUIController instance;
		
		public static MainUIController Instance {
			get { 
				if (instance == null) {
					instance = FindObjectOfType<MainUIController> ();
					Debug.LogError ("*****instance=" + instance + "*****");
				}
				return instance;
			}
		}

		void Awake ()
		{
			instance = this;
		}

		public void Show (TipType _type)
		{
			TipRootController.instance.ShowTip (_type);
		}

		public void Show (LoadType _type)
		{
			LoadRootController.instance.ShowLoad (_type);
		}

		public void Show (MenuType _type)
		{
			Show ((object)_type);
		}

		public void Show (DialogType _type)
		{
			Show ((object)_type);
		}

		public void CloseLoad (){
			LoadRootController.instance.CloseAllLoad();
		}

		public void MenuBackButton ()
		{
			if (MainUIStack.Count > 1) {
				MainUIType _last = MainUIStack.Peek ();
				MainUIType lastType = new MainUIType (MainUIStack.Pop ());
				MainUIType currentType = MainUIStack.Peek ();
				lastType = lastType.ReturnDifferent (currentType);
				bool isChangeMenu = lastType.menu != MenuType.None;
				SetUIActive (lastType, false, isChangeMenu);
				SetUIActive (MainUIStack.Peek (), true,false);
				if (OnBack != null) {
					OnBack (_last, MainUIStack.Peek ());
				}
			} else {
				Show (MenuType.Main);
			}
		}

		public void CloseDialogButton ()
		{
			if (CurrentDialogType != DialogType.None) {
				MenuBackButton ();
			}
		}

		void Show (object _type)
		{
			MainUIType last = new MainUIType();
			MainUIType now = new MainUIType();
			if (MainUIStack.Count > 0) {
				last = MainUIStack.Peek ();
			}

			if (_type is MenuType) {
				now = new MainUIType ((MenuType)_type);
				MainUIStack.Push (now);
				MenuRootController.instance.SetMenuActive (last.menu, false);
				MenuRootController.instance.SetMenuActive ((MenuType)_type, true);
				if(OnShow != null){
					OnShow (last, now);
				}
			} else if (_type is DialogType) {
				now = new MainUIType (last);
				now.dialog = (DialogType)_type;
				MainUIStack.Push (now);
				DialogRootController.instance.SetDialogActive (now.dialogList, true);
				if(OnShow != null){
					OnShow (last, now);
				}
			}
		}

		/// <summary>
		/// 设置UI显示与否
		/// </summary>
		void SetUIActive (MainUIType _type, bool _isActive, bool _isChangeMenu = true)
		{
			if (_type.menu != MenuType.None && _isChangeMenu) {
				MenuRootController.instance.SetMenuActive (_type.menu, _isActive);
			}
			if (_type.dialog != DialogType.None) {
				DialogRootController.instance.SetDialogActive (_type.dialogList, _isActive);
			}
		}

		private void BackTo (MainUIType[] _types)
		{
			MainUIType lastType = new MainUIType (MainUIStack.Peek ());
			bool isBreak = false;
			while (MainUIStack.Count > 1 && !isBreak) {
				MainUIStack.Pop ();
				foreach (MainUIType _type in _types) {
					if ((_type.dialog == DialogType.None && (_type.menu == MainUIStack.Peek ().menu && MainUIStack.Peek ().dialog == DialogType.None)) ||
						(_type.dialog != DialogType.None && _type.dialog == MainUIStack.Peek ().dialog)) {
						isBreak = true;
						break;
					}
				}
			}
			if (MainUIStack.Count <= 0) {
				MainUIStack.Push (new MainUIType (MenuType.Main));
			}
			lastType = lastType.ReturnDifferent (MainUIStack.Peek ());
			bool isChangeMenu = lastType.menu != MenuType.None;
			SetUIActive (lastType, false, isChangeMenu);
			SetUIActive (MainUIStack.Peek (), true);
		}
		
		/// <summary>
		/// 返回到某个指定界面（可多个，满足任意一个即跳转）
		/// </summary>
		/// <param name="_types">Types.</param>
		public void UIBackTo (params MainUIType[] _types)
		{
			BackTo (_types);
		}

		public void UIBackTo (MainUIType _type)
		{
			BackTo (new MainUIType[]{_type});
		}

		/// <summary>
		/// 返回当前menu界面Type
		/// </summary>
		public MenuType CurrentMenuType {
			get { 
				if (MainUIStack.Count > 0) {
					return MainUIStack.Peek ().menu;
				}
				return MenuType.None;
			}
		}
		
		/// <summary>
		/// 返回当前最顶层Dialog，无弹窗则返回DialogType.None
		/// </summary>
		/// <value>The type of the current dialog.</value>
		public DialogType CurrentDialogType {
			get {  
				if (MainUIStack.Count > 0) {
					return MainUIStack.Peek ().dialog;
				}
				return DialogType.None;
			}
		}

	}
}
