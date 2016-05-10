using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace UI {

	public class Lines : MonoBehaviour {

		/// <summary>
		/// 线条数组
		/// </summary>
		public Image[] LineArr = new Image[3];

		/// <summary>
		/// 背景图的RectTransform
		/// </summary>
		private RectTransform BgRect;

		void Start() {
			BgRect = GameBoard1.instance.Bg.rectTransform;
			var width = BgRect.rect.width;
			SetLinesPosition(width);
		}

		/// <summary>
		/// 设置线条位置
		/// </summary>
		/// <param name="width"></param>
		void SetLinesPosition(float width)
		{
			var y = LineArr[0].rectTransform.localPosition.y;
			LineArr[0].rectTransform.localPosition = new Vector2(width / 4,y);
			LineArr[1].rectTransform.localPosition = new Vector2(0, y);
			LineArr[2].rectTransform.localPosition = new Vector2(width / 4 * -1, y);
		}
	}
}
