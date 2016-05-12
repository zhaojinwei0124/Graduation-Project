using client;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI {

	public enum SwitchType {
		None,
		Music,
		Audio,
	}

	public class BtnSwitch : MonoBehaviour, IPointerClickHandler {
		/// <summary>
		/// 选择类型
		/// </summary>
		public SwitchType SwitchType;
		/// <summary>
		/// 按钮图片
		/// </summary>
		public Image ButtonImage;

		void OnEnable() {
			InitData();
		}

		public void OnPointerClick(PointerEventData eventData) {
			switch (SwitchType) {
				case SwitchType.Audio:
					AudioController.Instance.IsAudioPause = !AudioController.Instance.IsAudioPause;
					if (AudioController.Instance.IsAudioPause) {
						ButtonImage.sprite = AtlasManager.GetSprite(Client.ATLAS_MANU, "BoxCheckNot");
					} else {
						ButtonImage.sprite = AtlasManager.GetSprite(Client.ATLAS_MANU, "BoxChecked");
					}
					break;

				case SwitchType.Music:
					AudioController.Instance.IsMusicPause = !AudioController.Instance.IsMusicPause;
					if (AudioController.Instance.IsMusicPause) {
						ButtonImage.sprite = AtlasManager.GetSprite(Client.ATLAS_MANU, "BoxCheckNot");
					} else {
						ButtonImage.sprite = AtlasManager.GetSprite(Client.ATLAS_MANU, "BoxChecked");
					}
					break;
			}
		}

		void InitData() {

			switch (SwitchType) {
				case SwitchType.Audio:
					if (AudioController.Instance.IsAudioPause) {
						ButtonImage.sprite = AtlasManager.GetSprite(Client.ATLAS_MANU, "BoxCheckNot");
					} else {
						ButtonImage.sprite = AtlasManager.GetSprite(Client.ATLAS_MANU, "BoxChecked");
					}
					break;

				case SwitchType.Music:
					if (AudioController.Instance.IsMusicPause) {
						ButtonImage.sprite = AtlasManager.GetSprite(Client.ATLAS_MANU, "BoxCheckNot");
					} else {
						ButtonImage.sprite = AtlasManager.GetSprite(Client.ATLAS_MANU, "BoxChecked");
					}
					break;
			}
		}
	}
}
