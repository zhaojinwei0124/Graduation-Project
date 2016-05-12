using UnityEngine;
using System.Collections;
using client;
using UI;

public class MainMenuBoard : MonoBehaviour {

	void OnEnable()
	{
		Client.instance.Game.CurrntLevel = Level.None;
		//AudioController.Instance.SetMusic(AudioName.Music_Menu);
	}
}
