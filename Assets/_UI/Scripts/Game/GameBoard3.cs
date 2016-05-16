using System.Collections;
using client;
using Game;
using UnityEngine;
using UnityEngine.UI;

namespace UI {

	public class GameBoard3 : MonoBehaviour {
		public static GameBoard3 instance;
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
		public ItemSpawn3 ItemSpawn3;
		/// <summary>
		/// 水元素
		/// </summary>
		public GamePlayer3 Water;
		/// <summary>
		/// 火元素
		/// </summary>
		public GamePlayer3 Fire;
		/// <summary>
		/// 最高分
		/// </summary>
		private int maxScore;

		private float Timer;
		/// <summary>
		/// 是否延迟show操作
		/// </summary>
		private bool ShowLater = false;
		private float Timer1;


		public int MaxScore {
			get {
				return maxScore;
			}
			set {
				maxScore = value;
				CommonUtil.SetInt(Client.GAME_3_MAXSCORE, value);
			}
		}

		void Awake() {
			instance = this;
			InitData();
		}

		private void InitData() {
			maxScore = CommonUtil.GetInt(Client.GAME_3_MAXSCORE, 0);
		}

		/// <summary>
		/// 设置分数
		/// </summary>
		/// <param name="score"></param>
		public void SetScore(int score) {
			Score.text = string.Format("{00:00}", score);
		}

		void Update() {
			if (ShowLater) {
				if (Time.realtimeSinceStartup - Timer1 >= 0.5f) {
					MainUIController.Instance.Show(DialogType.GameOver);
					Timer1 = Time.realtimeSinceStartup;
					ShowLater = false;
				}
			}
			if (Time.timeScale == 0) {
				return;
			}
			if (Time.realtimeSinceStartup - Timer >= 1.0f) {
				Client.instance.Player.GameScore3 += 1;
				SetScore(Client.instance.Player.GameScore3);
				Timer = Time.realtimeSinceStartup;
			}
		}

		void Start() {
			Client.instance.Game.GameStatu = GameStatus.GamePlaying;
			Time.timeScale = 1;
			Client.instance.Game.CurrntLevel = Level.Level_3;
			Client.instance.Player.GameScore3 = 0;
			CleanAllItems();
			SetScore(0);
			Water.Start();
			Fire.Start();
			ItemSpawn3.Start();
		}

		void OnEnable() {
			AudioController.Instance.SetBKMusic();
			Start();
		}

		public void Continue() {
			Client.instance.Game.GameStatu = GameStatus.GamePlaying;
			Time.timeScale = 1;
		}

		public void Pause() {
			Client.instance.Game.GameStatu = GameStatus.GameParse;
			AudioController.Instance.PauseBKMusic();
			Time.timeScale = 0;
		}

		public void Restart() {
			Start();
		}

		public void CleanAllItems() {
			for (int i = 0; i < ItemSpawn3.transform.childCount; i++) {
				var obj = ItemSpawn3.transform.GetChild(i);
				if (obj.tag == "Water" || obj.tag == "Fire") {
					Destroy(ItemSpawn3.transform.GetChild(i).gameObject);
				}
			}
		}

		public void GameOver() {
			if (MainUIController.Instance.CurrentDialogType == DialogType.GameOver) {
				return;
			}
			Client.instance.Game.GameStatu = GameStatus.GameOver;
			AudioController.Instance.PauseBKMusic();
			Time.timeScale = 0;
			if (MaxScore < Client.instance.Player.GameScore3) {
				MaxScore = Client.instance.Player.GameScore3;
			}
			ShowLater = true;
			Timer1 = Time.realtimeSinceStartup;
		}
	}
}
