using UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI {

	public class BtnContinue : MonoBehaviour, IPointerClickHandler {
		/// <summary>
		/// 第几关
		/// </summary>
		public LevelType Level;

		public void OnPointerClick(PointerEventData eventData) {
			switch (Level) {
				case LevelType.Level_1:
					GameBoard1.instance.Continue();
					break;
				case LevelType.Level_2:
					break;
				case LevelType.Level_3:
					break;
			}
		}
	}
}