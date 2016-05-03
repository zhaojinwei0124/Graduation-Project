using client;
using UnityEngine;
using UnityEngine.UI;

namespace UI {

	/// <summary>
	/// 玩家类型枚举
	/// </summary>
	public enum PlayerType {
		PlayerWater,
		PlayerFire
	}

	public class Game1Player : MonoBehaviour {

		public static Game1Player instance;

		/// <summary>
		/// 玩家行进路线的x值数组
		/// </summary>
		public float[] PlayerRoadX = new float[4];

		/// <summary>
		/// 玩家类型
		/// </summary>
		public PlayerType PlayerType;

		/// <summary>
		/// 背景图片的RectTransform
		/// </summary>
		private RectTransform BgRect;

		/// <summary>
		/// 当先路线的编号
		/// </summary>
		private int CurrentRoadNum;

		void Awake() {
			instance = this;
		}

		void Start() {
			if (PlayerType == PlayerType.PlayerWater)
			{
				CurrentRoadNum = 0;
			} else
			{
				CurrentRoadNum = 3;
			}
			BgRect = Game1Board.instance.Bg.rectTransform;
			var width = BgRect.rect.width;
			for (int i = 0; i < PlayerRoadX.Length; i++)
			{
				PlayerRoadX[i] = width / 8 * (2 * i - 3);
			}
			SetPlayerPositon(width);
		}

		/// <summary>
		/// 改变玩家所处路线
		/// </summary>
		public void ChangeRoadNum() {
			switch (CurrentRoadNum)
			{
				case 0:
					CurrentRoadNum = 1;
					break;
				case 1:
					CurrentRoadNum = 0;
					break;
				case 2:
					CurrentRoadNum = 3;
					break;
				case 3:
					CurrentRoadNum = 2;
					break;
			}
			ChangePlayerPosition(CurrentRoadNum);
		}

		/// <summary>
		/// 改变玩家位置
		/// </summary>
		/// <param name="index">所处路线的序号</param>
		void ChangePlayerPosition(int index) {
			var rect = GetComponent<Image>().rectTransform;
			var y = rect.localPosition.y;
			var toPosition = new Vector2(PlayerRoadX[index], y);
			rect.localPosition = Vector3.Lerp(rect.localPosition, toPosition, Time.time);
		}

		/// <summary>
		/// 设置玩家初始位置
		/// </summary>
		/// <param name="width"></param>
		void SetPlayerPositon(float width) {
			var rect = GetComponent<Image>().rectTransform;
			var y = rect.localPosition.y;
			if (PlayerType == PlayerType.PlayerWater)
			{
				rect.localPosition = new Vector2(PlayerRoadX[0], y);
			} else if (PlayerType == PlayerType.PlayerFire)
			{
				rect.localPosition = new Vector2(PlayerRoadX[3], y);
			}
		}

		void OnTriggerEnter2D(Collider2D other) {
			if (other.gameObject.tag == "Water")
			{
				if (PlayerType == PlayerType.PlayerWater)
				{
					Client.instance.Player.Score += 1;
					Game1Board.instance.SetScore(Client.instance.Player.Score);
					Destroy(other.gameObject);
				} else
				{
					GameOver();
				}
			}
			if (other.gameObject.tag == "Fire")
			{
				if (PlayerType == PlayerType.PlayerFire)
				{
					Client.instance.Player.Score += 1;
					Game1Board.instance.SetScore(Client.instance.Player.Score);
					Destroy(other.gameObject);
				} else
				{
					GameOver();
				}
			}
		}

		void GameOver()
		{
			Time.timeScale = 0;
		}
	}
}