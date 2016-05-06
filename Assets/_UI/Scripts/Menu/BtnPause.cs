using UnityEngine;
using System.Collections;
using UI;
using UnityEngine.EventSystems;

public class BtnPause : MonoBehaviour, IPointerClickHandler {

	/// <summary>
	/// 第几关
	/// </summary>
	public LevelType Level;

	public void OnPointerClick(PointerEventData eventData) {
		switch (Level) {
			case LevelType.Level_1:
				GameBoard1.instance.Pause();
				break;
			case LevelType.Level_2:
				break;
			case LevelType.Level_3:
				break;
		}
	}
}
