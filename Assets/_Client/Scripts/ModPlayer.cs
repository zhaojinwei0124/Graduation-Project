using System;
using UnityEngine;
using System.Collections;
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
		/// 当前玩家（第二关中转动的玩家）
		/// </summary>
		private PlayerType currentPlayer;

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
