using UnityEngine;
using client;
using UI;

namespace Game {

	public class GamePlayer2 : MonoBehaviour {
		/// <summary>
		/// 玩家类型
		/// </summary>
		public PlayerType PlayerType;

		/// <summary>
		/// 另一个玩家
		/// </summary>
		public Transform OtherPlayer;

		/// <summary>
		/// 旋转速度
		/// </summary>
		public float Speed;

		void Update() {
			if (PlayerType == Client.instance.Player.CurrentPlayer) {
				transform.RotateAround(OtherPlayer.position,
					Vector3.forward,
					Time.deltaTime * Speed * Client.instance.Player.Fd);
			}
		}

		void OnTriggerEnter2D(Collider2D other) {
			if (other.gameObject.tag == "Line") {
				Client.instance.Player.Fd *= -1;
			}

			if (other.gameObject.tag == "Water") {
				if (PlayerType == PlayerType.PlayerWater) {
					AudioController.Instance.SetAudio(AudioName.Audio_Eat);
					Client.instance.Player.GameScore2 += 1;
					GameBoard2.instance.SetScore(Client.instance.Player.GameScore2);
					Destroy(other.gameObject);
					Client.instance.Game.ItemCount -= 1;
				} else {
					AudioController.Instance.SetAudio(AudioName.Audio_Die);
					EffectManager.instance.PlayEffect(EffectType.Effect_Dead_Fire, gameObject.transform.localPosition);
					gameObject.SetActive(false);
					GameBoard2.instance.GameOver();
				}
			}
			if (other.gameObject.tag == "Fire") {
				if (PlayerType == PlayerType.PlayerFire) {
					AudioController.Instance.SetAudio(AudioName.Audio_Eat);
					Client.instance.Player.GameScore2 += 1;
					GameBoard2.instance.SetScore(Client.instance.Player.GameScore2);
					Destroy(other.gameObject);
					Client.instance.Game.ItemCount -= 1;
				} else {
					AudioController.Instance.SetAudio(AudioName.Audio_Die);
					EffectManager.instance.PlayEffect(EffectType.Effect_Dead_Water, gameObject.transform.localPosition);
					gameObject.SetActive(false);
					GameBoard2.instance.GameOver();
				}
			}
		}
	}
}