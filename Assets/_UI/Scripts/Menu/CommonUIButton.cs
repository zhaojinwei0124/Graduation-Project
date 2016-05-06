using UnityEngine;
using UnityEngine.EventSystems;
using HeavyDutyInspector;
namespace UI
{
	public class CommonUIButton : MonoBehaviour , IPointerClickHandler
	{

		public UIType uiType = UIType.None;
		[HeavyDutyInspector.HideConditional("uiType",(int)UIType.Menu)]
		public MenuType menu = MenuType.None;
		[HeavyDutyInspector.HideConditional("uiType",(int)UIType.Dialog)]
		public DialogType dialog = DialogType.None;
		[HeavyDutyInspector.HideConditional("uiType",(int)UIType.Load)]
		public LoadType load = LoadType.None;
		[HeavyDutyInspector.HideConditional("uiType",(int)UIType.Tip)]
		public TipType tip = TipType.None;

		public virtual void OnPointerClick (PointerEventData eventData)
		{
			switch (uiType) {
				case UIType.Menu:
					MainUIController.Instance.Show (menu);
					break;
				case UIType.Dialog:
					MainUIController.Instance.Show (dialog);
					break;
				case UIType.Load:
					MainUIController.Instance.Show (load);
					break;
				case UIType.Tip:
					MainUIController.Instance.Show (tip);
					break;
				default:
					break;
			}
		}
	}
}
