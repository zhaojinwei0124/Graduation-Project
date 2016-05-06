using UnityEngine;
using UI;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelGrid : MonoBehaviour, IPointerClickHandler {
	/// <summary>
	/// 关卡槽图片
	/// </summary>
	public Image Slot;
	/// <summary>
	/// 关卡文字
	/// </summary>
	public Text Text;
	/// <summary>
	/// 关卡序号
	/// </summary>
	public int index;
	/// <summary>
	/// 音效控制脚本
	/// </summary>
	private AudioButton AudioButton;

	void Awake() {
		AudioButton = GetComponent<AudioButton>();
	}

	void OnEnable() {
		SetData();
	}

	/// <summary>
	/// 设置数据，
	/// </summary>
	void SetData() {
		if (index == -1) {
			if (AudioButton) {
				AudioButton.enabled = false;
			}
			return;
		}
		Text.text = (index + 1).ToString();
	}

	public void OnPointerClick(PointerEventData eventData) {
		if (index == -1) {
			return;
		}
		MainUIController.Instance.Show((MenuType)(index + 1));
	}
}
