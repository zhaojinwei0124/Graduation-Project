using UnityEngine;

namespace UI
{

	public class ShowEffect : MonoBehaviour
	{
		public GameObject effectObject;
		private RectTransform rect;

		void Start ()
		{
			//如使用预加载 将此设为false
			effectObject.SetActive (false);
			rect = GetComponent<RectTransform> ();
		}

		public void Show(bool show){
			effectObject.SetActive (false);
			effectObject.SetActive (true);
		}

		public void Show(bool show ,Vector2 to){
			rect.anchoredPosition = to;
			effectObject.SetActive (false);
			effectObject.SetActive (true);
		}
	}
}
