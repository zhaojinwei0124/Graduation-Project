using UnityEngine;
using System.Collections;

namespace client {

	public class Client : MonoBehaviour
	{

		public static Client instance;
		/// <summary>
		/// 玩家模块
		/// </summary>
		public ModPlayer Player;
		/// <summary>
		/// 游戏模块
		/// </summary>
		public ModGame Game;
		/// <summary>
		/// Menu图集名称
		/// </summary>
		public const string ATLAS_MANU = "Atlas_Menu";
		/// <summary>
		/// 第一关最高分
		/// </summary>
		public const string GAME_1_MAXSCORE = "Game_1_MaxScore";
		/// <summary>
		/// 第二关最高分
		/// </summary>
		public const string GAME_2_MAXSCORE = "Game_2_MaxScore";
		void Awake()
		{
			instance = this;
		}

	}
}