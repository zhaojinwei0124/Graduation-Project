using System.Collections;
using DG.Tweening;
using UnityEngine;
using UI;
namespace Game {
	public class GamePlayer3 : MonoBehaviour {

		public static GamePlayer3 instance;
		/// <summary>
		/// 玩家类型
		/// </summary>
		public PlayerType PlayerType;
		/// <summary>
		/// 特效物体
		/// </summary>
		public GameObject EffectObject;

		public Tween Tween1;
		public Tween Tween2;
		public bool CanJump = true;

		void Awake() {
			instance = this;
		}

		public void Start() {
			StartCoroutine(RestEffect());
		}

		public void Jump() {
			if (!CanJump) {
				return;
			}
			CanJump = false;
			Sequence sequence = DOTween.Sequence();
			if (PlayerType == PlayerType.PlayerWater) {
				Tween1 = transform.DOLocalMoveX(-350, 0.2f);
				Tween2 = transform.DOLocalMoveX(-74, 0.4f).OnComplete(() => {
					CanJump = true;
				}
			);
				sequence.Append(Tween1);
				sequence.Append(Tween2);
			} else {
				Tween1 = transform.DOLocalMoveX(350, 0.2f);
				Tween2 = transform.DOLocalMoveX(74, 0.4f).OnComplete(() => {
					CanJump = true;
				});
				sequence.Append(Tween1);
				sequence.Append(Tween2);
			}
		}

		IEnumerator RestEffect() {
			EffectObject.SetActive(false);
			EffectObject.SetActive(false);
			yield return 0;
			EffectObject.SetActive(true);
			EffectObject.SetActive(true);
		}

		void OnTriggerEnter2D(Collider2D other) {
			GameBoard3.instance.GameOver();
		}

	}
}