using System.Collections.Generic;

namespace UI
{
	public class MainUIType
	{
		public MenuType menu = MenuType.None;
		public List<DialogType> dialogList = new List<DialogType> ();

		public DialogType dialog {
			get {
				if (dialogList.Count > 0) {
					return dialogList [dialogList.Count - 1];
				} else {
					return DialogType.None;
				}
			}
			set {
				dialogList.Add (value);
			}
		}

		public MainUIType()
		{

		}

		public MainUIType (MenuType _menu)
		{
			menu = _menu;
		}

		public MainUIType (MenuType _menu, params DialogType[] _dialogs)
		{
			menu = _menu;
			dialogList.CopyTo (_dialogs);
		}

		public MainUIType (MainUIType _type)
		{
			menu = _type.menu;
			dialogList.AddRange (_type.dialogList.ToArray ());
		}

		public MainUIType ReturnSame (MainUIType _type)
		{
			MainUIType same = new MainUIType (this);
			same.menu = menu == _type.menu ? menu : MenuType.None;
			for (int i = 0; i < dialogList.Count; i ++) {
				if (i < _type.dialogList.Count) {
					if (dialogList [i] != _type.dialogList [i]) {
						same.dialogList [i] = DialogType.None;
					}
				}
				else{
					same.dialogList.RemoveRange(i,_type.dialogList.Count - dialogList.Count);
					break;
				}
			}
			return same;
		}

		public MainUIType ReturnDifferent(MainUIType _type){
			MainUIType diff = new MainUIType(this);
			diff.menu = menu != _type.menu ? menu : MenuType.None;
			for (int i = 0; i < dialogList.Count; i ++) {
				if (i < _type.dialogList.Count) {
					if (dialogList [i] == _type.dialogList [i]) {
						diff.dialogList [i] = DialogType.None;
					}
				}
			}
			return diff;
		}

		public bool IsEquals(MainUIType _type){
			if(menu != _type.menu || dialogList.Count != _type.dialogList.Count){
				return false;
			}
			for (int i = 0; i < dialogList.Count; i ++) {
				if (dialogList [i] != _type.dialogList [i]) {
					return false;
				}
			}
			return true;
		}
	}
}
