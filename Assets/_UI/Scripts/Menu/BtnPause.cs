﻿using UnityEngine;
using client;
using UI;
using UnityEngine.EventSystems;

public class BtnPause : MonoBehaviour, IPointerClickHandler {

	public void OnPointerClick(PointerEventData eventData) {
		switch (Client.instance.Game.CurrntLevel) {
			case Level.Level_1:
				GameBoard1.instance.Pause();
				break;
			case Level.Level_2:
				GameBoard2.instance.Pause();
				break;
			case Level.Level_3:
				GameBoard3.instance.Pause();
				break;
		}
	}
}
