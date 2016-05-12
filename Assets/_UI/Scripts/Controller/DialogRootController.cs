
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UI {
	public enum DialogType {
		None = 0,
		Shadow,
		GamePause,
		GameOver,
		Setting,
		Help,
		Close,
	}

	public enum DialogName {
		None = 0,
		ShadowDialog,
		GamePauseDialog,
		GameOverDialog,
		SettingDialog,
		HelpDialog,
		CloseDialog,
	}

	[System.Serializable]
	public class DialogContainer {
		public DialogType type;
		public DialogName[] dialogItems;
	}

	public class DialogRootController : MonoBehaviour {
		public static DialogRootController instance;
		public DialogContainer[] Dialogs;
		private List<GameObject> canvasList = new List<GameObject>();
		private Dictionary<DialogName, GameObject> DialogGO = new Dictionary<DialogName, GameObject>();

		void Awake() {
			instance = this;
		}

		public void SetDialogActive(List<DialogType> _types, bool isActive) {
			for (int d = 0; d < _types.Count; d++) {
				for (int i = 0; i < Dialogs.Length; i++) {
					if (Dialogs[i].type == _types[d]) {
						this.SetDialogActive(Dialogs[i], isActive, d);
						break;
					}
				}
			}
		}

		private void SetDialogActive(DialogContainer dialog, bool isActive, int index = 0) {
			if (canvasList.Count <= index) {
				GameObject iLayer = LoadDialog("DialogLayer");
				iLayer.transform.SetSiblingIndex(index);
				canvasList.Add(iLayer);
			}
			for (int i = 0; i < dialog.dialogItems.Length; i++) {
				if (!DialogGO.ContainsKey(dialog.dialogItems[i])) {
					DialogGO.Add(dialog.dialogItems[i], LoadDialog(dialog.dialogItems[i].ToString(), canvasList[index].transform));
				}
				GameObject go = DialogGO[dialog.dialogItems[i]];
				if (isActive) {
					go.transform.SetParent(canvasList[index].transform);
					go.transform.SetSiblingIndex(i);
					go.SetActive(isActive);
				} else {
					go.SetActive(isActive);
					go.transform.SetParent(this.transform);
				}
			}
		}

		public GameObject LoadDialog(string dialogPath, Transform _parent = null) {
			Object go = Resources.Load(dialogPath);
			GameObject iDialog = Instantiate(go) as GameObject;
			iDialog.name = go.name;
			RectTransform rt = iDialog.GetComponent<RectTransform>();
			rt.SetParent((_parent == null) ? this.transform : _parent);
			rt.localScale = Vector3.one;
			rt.localPosition = Vector3.zero;
			rt.sizeDelta = Vector2.zero;
			rt.localRotation = Quaternion.identity;
			return iDialog;
		}

		public void ClearDialog() {
			foreach (GameObject go in DialogGO.Values) {
				Destroy(go.gameObject);
			}
			DialogGO.Clear();
		}

		/// <summary>
		/// 重置DialogRootController数据
		/// </summary>
		public void Reset() {
			ClearDialog();
		}
	}
}
