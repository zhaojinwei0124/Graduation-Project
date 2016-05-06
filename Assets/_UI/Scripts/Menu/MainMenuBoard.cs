using UnityEngine;
using System.Collections;
using UI;

public class MainMenuBoard : MonoBehaviour {

	void OnEnable()
	{
		AudioController.Instance.SetMusic(AudioName.Music_Menu);
	}
}
