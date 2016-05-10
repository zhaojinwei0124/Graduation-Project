using UnityEngine;
using client;
using Game;
using UnityEngine.EventSystems;

namespace UI {

	public class BtnGame2PlayerContraller : MonoBehaviour, IPointerClickHandler {

		void Start() {
			Init();
		}

		void Init() {
			var rd = Random.Range(0, 2);
			if (rd == 0) {
				Client.instance.Player.CurrentPlayer = PlayerType.PlayerFire;
			} else {
				Client.instance.Player.CurrentPlayer = PlayerType.PlayerWater;
			}
		}

		public void OnPointerClick(PointerEventData eventData) {
			ChangePlayer();
		}

		void ChangePlayer() {
			switch (Client.instance.Player.CurrentPlayer) {
				case PlayerType.PlayerFire:
					Client.instance.Player.CurrentPlayer = PlayerType.PlayerWater;
					break;
				case PlayerType.PlayerWater:
					Client.instance.Player.CurrentPlayer = PlayerType.PlayerFire;
					break;
			}
		}
	}
}