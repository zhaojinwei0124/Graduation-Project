using UnityEngine;
using System.Collections;

public class ModGame : MonoBehaviour {

	/// <summary>
	/// 游戏的状态
	/// </summary>
	public enum GameStatus
	{
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
	public int ItemCount;
}
