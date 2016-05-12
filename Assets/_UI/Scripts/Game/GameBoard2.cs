using System.Collections;
using System.Linq.Expressions;
using System.Timers;
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
		/// 水元素初始位置
		/// </summary>
		public Vector2 WaterPos;
		/// <summary>
		/// 火元素初始位置
		/// </summary>
		public Vector2 FirePos;
		/// <summary>
		/// 最高分
		/// </summary>
		private int maxScore;
		/// <summary>
		/// 是否延迟show操作
		/// </summary>
		private bool ShowLater = false;
		private float Timer;
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
			WaterPos = Water.transform.localPosition;
			FirePos = Fire.transform.localPosition;
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
			Client.instance.Game.GameStatu = GameStatus.GamePlaying;
			Time.timeScale = 1;
			Client.instance.Game.CurrntLevel = Level.Level_2;
			Client.instance.Player.GameScore2 = 0;
			Client.instance.Game.ItemCount = 0;

			Water.gameObject.SetActive(true);
			Water.transform.localPosition = WaterPos;
			Water.transform.localRotation = new Quaternion(0, 0, 0, 0);
			Water.transform.localScale = Vector3.one;

			Fire.gameObject.SetActive(true);
			Fire.transform.localPosition = FirePos;
			Fire.transform.localRotation = new Quaternion(0, 0, 0, 0);
			Fire.transform.localScale = Vector3.one;

			CleanAllItems();
			SetScore(0);
			ItemSpawn2.Start();
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
			for (int i = 0; i < ItemSpawn2.transform.childCount; i++) {
				Destroy(ItemSpawn2.transform.GetChild(i).gameObject);
			}
		}

		public void GameOver() {
			if (MainUIController.Instance.CurrentDialogType == DialogType.GameOver) {
				return;
			}
			Time.timeScale = 0;
			Client.instance.Game.GameStatu = GameStatus.GameOver;
			AudioController.Instance.PauseBKMusic();
			if (MaxScore < Client.instance.Player.GameScore2) {
				MaxScore = Client.instance.Player.GameScore2;
			}
			ShowLater = true;
			Timer = Time.realtimeSinceStartup;
		}

		void Update() {
			if (ShowLater) {
				if (Time.realtimeSinceStartup - Timer >= 0.5f) {
					MainUIController.Instance.Show(DialogType.GameOver);
					Timer = Time.realtimeSinceStartup;
					ShowLater = false;
				}
			}
		}
	}
}