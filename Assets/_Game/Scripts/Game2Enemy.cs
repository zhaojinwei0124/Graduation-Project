using client;
using UI;
using UnityEngine;

public class Game2Enemy : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag=="Line")
		{
			EffectManager.instance.PlayEffect(EffectType.Effect_Dead,transform.localPosition);
			Destroy(gameObject);
			Client.instance.Game.ItemCount -= 1;
		}
	}
}
