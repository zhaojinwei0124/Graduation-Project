using UnityEngine;
using client;
using UI;
using UnityEngine.UI;

public class GameOverDialog : MonoBehaviour {
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
		switch (Client.instance.Game.CurrntLevel) {
			case Level.Level_1:
				CurrentResult.text = "  得分：" + Client.instance.Player.GameScore1;
				BestResult.text = "最高分：" + GameBoard1.instance.MaxScore;
				break;
			case Level.Level_2:
				CurrentResult.text = "  得分：" + Client.instance.Player.GameScore2;
				BestResult.text = "最高分：" + GameBoard2.instance.MaxScore;
				break;
			case Level.Level_3:
				CurrentResult.text = "      成绩：" + Client.instance.Player.GameScore3 + " 秒";
				BestResult.text = "最佳成绩：" + GameBoard3.instance.MaxScore + " 秒";
				break;
		}
	}
}
