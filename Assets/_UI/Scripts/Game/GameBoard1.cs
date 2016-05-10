using client;
using Game;
using UnityEngine;
using UnityEngine.UI;

namespace UI {

	public class GameBoard1 : MonoBehaviour {
		public static GameBoard1 instance;
		/// <summary>
		/// 背景图片
		/// </summary>
		public Image Bg;
		/// <summary>
		/// 分数文字
		/// </summary>
		public Text Score;
		/// <summary>
		/// 敌人出生点
		/// </summary>
		public ItemSpawn1 ItemSpawn1;
		/// <summary>
		/// 水元素
		/// </summary>
		public GamePlayer1 Water;
		/// <summary>
		/// 火元素
		/// </summary>
		public GamePlayer1 Fire;
		/// <summary>
		/// 最高分
		/// </summary>
		private int maxScore;

		public int MaxScore {
			get {
				return maxScore;
			}
			set {
				maxScore = value;
				CommonUtil.SetInt(Client.GAME_1_MAXSCORE, value);
			}
		}

		void Awake() {
			instance = this;
			InitData();
		}

		private void InitData() {
			maxScore = CommonUtil.GetInt(Client.GAME_1_MAXSCORE, 0);
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
			Client.instance.Player.GameScore1 = 0;
			CleanAllItems();
			SetScore(0);
			Water.SetPlayerPositon();
			Fire.SetPlayerPositon();
			ItemSpawn1.Start();
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
			for (int i = 0; i < ItemSpawn1.transform.childCount; i++) {
				if (ItemSpawn1.transform.childCount > 0) {
					Destroy(ItemSpawn1.transform.GetChild(i).gameObject);
				}
			}
		}

		public void GameOver() {
			Time.timeScale = 0;
			if (MaxScore < Client.instance.Player.GameScore1) {
				MaxScore = Client.instance.Player.GameScore1;
			}
			MainUIController.Instance.Show(DialogType.GameOver);
		}
	}
}
