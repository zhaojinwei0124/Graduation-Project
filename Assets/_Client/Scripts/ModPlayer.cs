using System;
using UnityEngine;
using Game;

namespace client {

	public class ModPlayer : MonoBehaviour {
		/// <summary>
		/// 玩家分数（关卡1）
		/// </summary>
		[NonSerialized]
		public int GameScore1;
		/// <summary>
		/// 玩家分数（关卡2）
		/// </summary>
		[NonSerialized]
		public int GameScore2;
		/// <summary>
		/// 玩家分数（关卡3）
		/// </summary>
		[NonSerialized]
		public int GameScore3;
		/// <summary>
		/// 当前玩家（第二关中转动的玩家）
		/// </summary>
		private PlayerType currentPlayer;
		/// <summary>
		/// 关卡二的玩家是否是正向旋转（即初始旋转方向），1为正向，-1为反向
		/// </summary>
		public int Fd = 1;

		public PlayerType CurrentPlayer {
			get {
				return currentPlayer;
			}

			set {
				currentPlayer = value;
			}
		}
	}
}
