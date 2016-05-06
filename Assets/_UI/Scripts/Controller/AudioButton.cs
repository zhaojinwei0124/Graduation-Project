using UnityEngine;
using UnityEngine.EventSystems;

namespace UI{
	public class AudioButton : MonoBehaviour, IPointerClickHandler{
		public enum AudioEvent{
			None,
			OnClick
		}

		public AudioEvent audioEvent = AudioEvent.None;
		public AudioName audioName = AudioName.None;

		public void  OnPointerClick(PointerEventData eventData){
			if(audioEvent == AudioEvent.OnClick){
				AudioController.Instance.SetAudio (audioName);
			}
		}
	}
}
