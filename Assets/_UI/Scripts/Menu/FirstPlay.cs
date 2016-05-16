using client;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI {

	public class FirstPlay : MonoBehaviour, IPointerClickHandler {
		private Canvas canvas;
		private GraphicRaycaster graphicRaycaster;
		private Image Image;
		private Tweener Tweener;
		private bool Removed;

		void Start() {
			if (Client.instance.Game.FirstGame) {
				MainUIController.Instance.Show(DialogType.Shadow);
				canvas = gameObject.AddComponent<Canvas>();
				canvas.overrideSorting = true;
				canvas.sortingOrder = 11;
				graphicRaycaster = gameObject.AddComponent<GraphicRaycaster>();
				Tweener = transform.DOScale(new Vector3(0.8f, 0.8f, 1), 1).SetLoops(-1, LoopType.Yoyo);
			}
		}

		public void Remove() {
			if (Removed) {
				return;
			}
			MainUIController.Instance.CloseDialogButton();
			if (graphicRaycaster) {
				Destroy(graphicRaycaster);
			}
			if (canvas) {
				Destroy(canvas);
			}
			if (MainUIController.Instance.CurrentDialogType == DialogType.Setting) {
				Client.instance.Game.FirstGame = false;
			}
			if (Tweener != null) {
				Tweener.Kill();
			}
			Removed = true;
		}

		public void OnPointerClick(PointerEventData eventData) {
			if (Client.instance.Game.FirstGame) {
				Remove();
			}
		}
	}
}
