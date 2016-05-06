using UnityEngine;
using System.Collections;
using client;
using Game;
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
				transform.RotateAround(OtherPlayer.position, Vector3.forward, Time.deltaTime * Speed);
			}
		}

		void OnTriggerEnter2D(Collider2D other) {
			if (other.gameObject.tag == "Line") {
				Speed *= -1;
			}

			if (other.gameObject.tag == "Water") {
				if (PlayerType == PlayerType.PlayerWater) {
					Client.instance.Player.GameScore2 += 1;
					GameBoard2.instance.SetScore(Client.instance.Player.GameScore2);
					Destroy(other.gameObject);
				} else {
					GameBoard2.instance.GameOver();
				}
			}
			if (other.gameObject.tag == "Fire") {
				if (PlayerType == PlayerType.PlayerFire) {
					Client.instance.Player.GameScore2 += 1;
					GameBoard2.instance.SetScore(Client.instance.Player.GameScore2);
					Destroy(other.gameObject);
				} else {
					GameBoard2.instance.GameOver();
				}
			}
		}
	}
}