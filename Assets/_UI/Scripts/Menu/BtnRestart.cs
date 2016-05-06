using UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI {

	public enum LevelType {
		Level_1,
		Level_2,
		Level_3
	}

	public class BtnRestart : MonoBehaviour, IPointerClickHandler {


		/// <summary>
		/// 第几关
		/// </summary>
		public LevelType Level;

		public void OnPointerClick(PointerEventData eventData) {
			switch (Level) {
				case LevelType.Level_1:
					GameBoard1.instance.Restart();
					break;
				case LevelType.Level_2:
					break;
				case LevelType.Level_3:
					break;
			}
		}
	}
}