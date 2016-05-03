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

		void Awake()
		{
			instance = this;
		}

	}
}