using UnityEngine;
using System.Collections;
using UI;
using UnityEngine.EventSystems;

public class ButtonGame1PlayeControler : MonoBehaviour, IPointerClickHandler
{

	/// <summary>
	/// 控制的玩家
	/// </summary>
	public Game1Player Player;

	public void OnPointerClick(PointerEventData eventData) {
		Player.ChangeRoadNum();
	}
}
