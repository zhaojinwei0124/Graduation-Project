using UnityEngine;
using System.Collections.Generic;

namespace UI
{
	public enum TipType
	{
		None,
		Notice,
	}
		
	[System.Serializable]
	public class TipContainer
	{
		public TipType type;
		public GameObject[] items;
	}
		
	public class TipRootController : MonoBehaviour
	{
		public static TipRootController instance;
		public TipContainer[] tips;
		private List<TipType> showList = new List<TipType> ();
		private bool isShowTip = false;
			
		void Awake ()
		{
			isShowTip = false;
			instance = this;
		}
			
		/// <summary>
		/// 显示tip界面
		/// </summary>
		/// <param name="_type">Type.</param>
		public void ShowTip (TipType _type)
		{
			SetTipActive (_type, true);
		}
			
		/// <summary>
		/// 关闭tip界面
		/// </summary>
		/// <param name="_type">Type.</param>
		public void CloseTip (TipType _type)
		{
			
			SetTipActive (_type, false);
		}
			
		void SetTipActive (TipType _type, bool _active)
		{
			if (_active) {
				isShowTip = true;
				if (!showList.Contains (_type)) {
					showList.Add (_type);
				}
			} else if (showList.Contains (_type)) {
				showList.Remove (_type);
			}
				
			for (int i = 0; i < tips.Length; i++) {
				if (tips [i].type == _type) {
					this.SetTipActive (tips [i], _active);
				}
			}
		}
			
		void SetTipActive (TipContainer _tip, bool _active)
		{
			for (int i = 0; i < _tip.items.Length; i++) {
				if(_tip.items[i] != null){
					_tip.items [i].SetActive (_active);
				}
			}
		}

		public void Reset ()
		{
			foreach (TipType t in showList) {
				SetTipActive (t, false);
			}
			showList.Clear ();
		}

		public TipType GetRootTipType(){
			if(showList.Count > 0){
				return showList [showList.Count - 1];
			}
			return TipType.None;
		}
	}
	
}
