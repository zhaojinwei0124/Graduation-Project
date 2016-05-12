using client;
using UI;
using UnityEngine;

public class Game2Line : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Water" || other.gameObject.tag == "Fire") {
			Destroy(other.gameObject);
			Client.instance.Game.ItemCount -= 1;
		}
	}
}
