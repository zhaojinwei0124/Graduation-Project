using UnityEngine;
using System.Collections;
using System.Security.Policy;
using client;
using UI;
using UnityEngine.UI;

public class GameOverDialog : MonoBehaviour {
	/// <summary>
	/// 第几关
	/// </summary>
	public LevelType Level;
	/// <summary>
	/// 当前结果
	/// </summary>
	public Text CurrentResult;
	/// <summary>
	/// 最佳结果
	/// </summary>
	public Text BestResult;

	void OnEnable() {
		SetData();
	}

	void SetData() {
		switch (Level) {
			case LevelType.Level_1:
				CurrentResult.text = "得分：" + Client.instance.Player.GameScore1;
				BestResult.text = "最高分：" + GameBoard1.instance.MaxScore;
				break;
			case LevelType.Level_2:
				break;
			case LevelType.Level_3:
				break;
		}
	}
}
