
using client;
using UnityEngine;

namespace UI {
	public class EscapeInputCrl : MonoBehaviour {
		private GameObject mainGameObject;
		private GameObject endGameObject;

		private void Update() {
			if (Input.GetKeyDown(KeyCode.Escape)) {
				OnEscapeKeyDown();
			}
		}

		private void OnEscapeKeyDown() {
			if (Client.instance.Game.FirstGame) {
				return;
			}

			if (MainUIController.Instance.CurrentDialogType == DialogType.GamePause || MainUIController.Instance.CurrentDialogType == DialogType.GameOver) {
				return;
			}

			// 如果有弹窗则关闭弹窗 
			if (MainUIController.Instance.CurrentDialogType != DialogType.None) {
				MainUIController.Instance.CloseDialogButton();
				return;
			}

			var Game1 = GameObject.Find("GameBoard1");
			if (Game1) {
				GameBoard1.instance.Pause();
				MainUIController.Instance.Show(DialogType.GamePause);
				return;
			}

			var Game2 = GameObject.Find("GameBoard2");
			if (Game2) {
				GameBoard2.instance.Pause();
				MainUIController.Instance.Show(DialogType.GamePause);
				return;
			}

			var Game3 = GameObject.Find("GameBoard3");
			if (Game3) {
				GameBoard3.instance.Pause();
				MainUIController.Instance.Show(DialogType.GamePause);
				return;
			}

			var level = GameObject.Find("SelectLevelBoard");
			if (level) {
				MainUIController.Instance.Show(MenuType.Main);
				return;
			}

			MainUIController.Instance.Show(DialogType.ExitGame);

		}
	}

}
