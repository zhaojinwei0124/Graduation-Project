using System;
using System.Security.Policy;
using UnityEngine;

namespace client {

	/// <summary>
	/// 关卡枚举
	/// </summary>
	public enum Level {
		None,
		Level_1,
		Level_2,
		Level_3,
	}

	/// <summary>
	/// 游戏的状态
	/// </summary>
	public enum GameStatus {
		None,
		/// <summary>
		/// 游戏正在进行
		/// </summary>
		GamePlaying,

		/// <summary>
		/// 游戏暂停
		/// </summary>
		GameParse,

		/// <summary>
		/// 游戏结束
		/// </summary>
		GameOver
	}

	public class ModGame : MonoBehaviour {

		/// <summary>
		/// 第二关敌人数量
		/// </summary>
		[NonSerialized]
		public int ItemCount;

		/// <summary>
		/// 当前进行的关卡
		/// </summary>
		[NonSerialized]
		public Level CurrntLevel;

		/// <summary>
		/// 当前游戏状态
		/// </summary>
		public GameStatus GameStatu;

		/// <summary>
		/// 是否是第一次游戏
		/// </summary>
		private bool firstGame;

		/// <summary>
		/// 是否是第一次游戏
		/// </summary>
		public bool FirstGame {
			get {
				return firstGame;
			}
			set {
				firstGame = value;
				CommonUtil.SetBool(Client.FIRSTGAME, value);
			}
		}

		void Awake() {
			Init();
		}

		private void Init() {
			firstGame = CommonUtil.GetBool(Client.FIRSTGAME, true);
		}
	}
}