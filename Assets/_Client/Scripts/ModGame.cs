﻿using System;
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

	public class ModGame : MonoBehaviour {
		/// <summary>
		/// 游戏的状态
		/// </summary>
		public enum GameStatus {
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
	}
}