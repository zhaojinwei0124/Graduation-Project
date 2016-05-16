using UnityEngine;
using UnityEngine.UI;

public class UIDepth : MonoBehaviour {
	public int Order;
	/// <summary>
	/// 是否是UI
	/// </summary>
	public bool IsUI = true;
	/// <summary>
	/// 是否需要接收点击事件
	/// </summary>
	public bool CanBeClicked;

	void Start() {
		if (IsUI) {
			Canvas canvas = GetComponent<Canvas>();
			if (canvas == null) {
				canvas = gameObject.AddComponent<Canvas>();
			}
			canvas.overrideSorting = true;
			canvas.sortingOrder = Order;

			if (CanBeClicked) {
				GraphicRaycaster graphicRaycaster = GetComponent<GraphicRaycaster>();
				if (graphicRaycaster == null) {
					gameObject.AddComponent<GraphicRaycaster>();
				}
			}
		} else {
			Renderer[] renders = GetComponentsInChildren<Renderer>();
			foreach (Renderer render in renders) {
				render.sortingOrder = Order;
			}
		}
	}
}