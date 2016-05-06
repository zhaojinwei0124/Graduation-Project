using UnityEngine;
using client;
using Game;
using UnityEngine.UI;

namespace UI {

	public class GameBoard2 : MonoBehaviour {

		public static GameBoard2 instance;
		/// <summary>
		/// 分数文字
		/// </summary>
		public Text Score;
		/// <summary>
		/// 敌人出生点
		/// </summary>
		public ItemSpawn2 ItemSpawn2;
		/// <summary>
		/// 水元素
		/// </summary>
		public GamePlayer2 Water;
		/// <summary>
		/// 火元素
		/// </summary>
		public GamePlayer2 Fire;

		/// <summary>
		/// 最高分
		/// </summary>
		private int maxScore;

		public int MaxScore {
			get { return maxScore; }
			set {
				maxScore = value;
				CommonUtil.SetInt(Client.GAME_2_MAXSCORE, value);
			}
		}

		void Awake() {
			instance = this;
			InitData();
		}

		private void InitData() {
			maxScore = CommonUtil.GetInt(Client.GAME_2_MAXSCORE, 0);
		}

		/// <summary>
		/// 设置分数
		/// </summary>
		/// <param name="score"></param>
		public void SetScore(int score) {
			Score.text = score.ToString();
		}

		void Start() {
			Time.timeScale = 1;
			Client.instance.Player.GameScore2 = 0;
			CleanAllItems();
			SetScore(0);
			ItemSpawn2.Start();
		}

		void OnEnable() {
			Start();
		}

		public void Continue() {
			Time.timeScale = 1;
		}

		public void Pause() {
			Time.timeScale = 0;
		}

		public void Restart() {
			Start();
		}

		public void CleanAllItems() {
			for (int i = 0; i < ItemSpawn2.transform.childCount; i++) {
				Destroy(ItemSpawn2.transform.GetChild(i).gameObject);
			}
		}

		public void GameOver() {
			Time.timeScale = 0;
			if (MaxScore < Client.instance.Player.GameScore2) {
				MaxScore = Client.instance.Player.GameScore2;
			}
			MainUIController.Instance.Show(DialogType.GameOver);
		}
	}
}