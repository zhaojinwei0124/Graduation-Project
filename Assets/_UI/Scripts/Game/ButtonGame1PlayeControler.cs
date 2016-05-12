using client;
using UnityEngine;
using Game;
using UnityEngine.EventSystems;

namespace UI {

	public class ButtonGame1PlayeControler : MonoBehaviour, IPointerClickHandler {

		/// <summary>
		/// 控制的玩家
		/// </summary>
		public GamePlayer1 Player;

		public void OnPointerClick(PointerEventData eventData) {
			if (Client.instance.Game.GameStatu == GameStatus.GameOver) {
				return;
			}
			Player.ChangeRoadNum();
		}
	}
}
