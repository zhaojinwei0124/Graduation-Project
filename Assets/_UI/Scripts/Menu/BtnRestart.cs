using client;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI {

	public class BtnRestart : MonoBehaviour, IPointerClickHandler {

		public void OnPointerClick(PointerEventData eventData) {
			switch (Client.instance.Game.CurrntLevel) {
				case Level.Level_1:
					GameBoard1.instance.Restart();
					break;
				case Level.Level_2:
					GameBoard2.instance.Restart();
					break;
				case Level.Level_3:
					GameBoard3.instance.Restart();
					break;
			}
		}
	}
}