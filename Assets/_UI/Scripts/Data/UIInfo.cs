
using UnityEngine;

namespace UI {

	public class UIInfo : MonoBehaviour
	{
		public static int rewardCount = 0;
		private static string  noticeStr;

		public static string NoticeStr{
			get{
				return noticeStr;
			}
			set{
				noticeStr = value;
			}
		}

	}
}
