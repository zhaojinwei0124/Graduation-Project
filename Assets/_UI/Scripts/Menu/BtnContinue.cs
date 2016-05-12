using client;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI {

	public class BtnContinue : MonoBehaviour, IPointerClickHandler {

		public void OnPointerClick(PointerEventData eventData) {
			AudioController.Instance.ResumeBkMusic();
			switch (Client.instance.Game.CurrntLevel) {
				case Level.Level_1:
					GameBoard1.instance.Continue();
					break;
				case Level.Level_2:
					GameBoard2.instance.Continue();
					break;
				case Level.Level_3:
					GameBoard3.instance.Continue();
					break;
			}
		}
	}
}