using UnityEngine;
using client;
using UI;

public class MainMenuBoard : MonoBehaviour {

	void OnEnable() {
		AudioController.Instance.SetBKMusic();
		Client.instance.Game.CurrntLevel = Level.None;
	}
}
