using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
	public enum BackButtonType
	{
		Back = 1,
		CloseDialog = 2,
		BackToMain = 3
	}

	public class CommonBackButton : MonoBehaviour, IPointerClickHandler
	{
		public BackButtonType type = BackButtonType.Back;

		public virtual void OnPointerClick (PointerEventData eventData)
		{
			switch (type) {
				case BackButtonType.Back:
					MainUIController.Instance.MenuBackButton ();
					break;
				case BackButtonType.CloseDialog:
					MainUIController.Instance.CloseDialogButton ();
					break;
				case BackButtonType.BackToMain:
					MainUIController.Instance.Show (MenuType.Main);
					break;
			}
		}
	}
}
