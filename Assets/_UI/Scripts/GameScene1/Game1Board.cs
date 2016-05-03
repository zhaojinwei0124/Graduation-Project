using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Game1Board : MonoBehaviour
{
	public static Game1Board instance;

	/// <summary>
	/// 背景图片
	/// </summary>
	public Image Bg;

	/// <summary>
	/// 分数文字
	/// </summary>
	public Text Score;

	void Awake()
	{
		instance = this;
	}

	/// <summary>
	/// 设置分数
	/// </summary>
	/// <param name="score"></param>
	public void SetScore(int score)
	{
		Score.text = score.ToString();
	}
}
