using UnityEngine;
using System.Collections;
using Update;

namespace UI {

	public class ItemSpawn : MonoBehaviour {

		/// <summary>
		/// 生产物品的时间间隔
		/// </summary>
		public float TimeInterval = 1;

		/// <summary>
		/// 物品水
		/// </summary>
		private GameObject Water;

		/// <summary>
		/// 物品火
		/// </summary>
		private GameObject Fire;
		
		void Start() {
			Water = UIPreLoadManager.instance.GetGameObjectByName("Water");
			Fire = UIPreLoadManager.instance.GetGameObjectByName("Fire");
			StartCoroutine(SpawnItem());
		}

		/// <summary>
		/// 产出物品
		/// </summary>
		/// <returns></returns>
		IEnumerator SpawnItem() {
			GameObject ItemLeft = null;
			GameObject ItemRight = null;
			int rd;
			
			while (true)
			{
				yield return new WaitForSeconds(TimeInterval);
				rd = Random.Range(0, 2);
				if (rd == 0)
				{
					ItemLeft = Instantiate(Water);
				}
				else
				{
					ItemLeft = Instantiate(Fire);
				}
				SetItemPosition(ItemLeft, true);
				rd = Random.Range(0, 2);
				if (rd == 0)
				{
					ItemRight = Instantiate(Water);
				} else
				{
					ItemRight = Instantiate(Fire);
				}
				SetItemPosition(ItemRight,false);
			}
		}
		
		/// <summary>
		/// 设置物品位置
		/// </summary>
		/// <param name="item">物品</param>
		/// <param name="left">是否是左边道路上的物品</param>
		void SetItemPosition(GameObject item,bool left)
		{
			RectTransform rt = (RectTransform) item.transform;
			rt.SetParent(transform);
			rt.localScale = Vector3.one;
			var rd = Random.Range(0, 2);
			if (rd == 0)
			{
				if (left)
				{
					rt.localPosition = new Vector2(Game1Player.instance.PlayerRoadX[0], 0);
				}
				else
				{
					rt.localPosition = new Vector2(Game1Player.instance.PlayerRoadX[2], 0);
				}
			}
			else
			{
				if (left)
				{
					rt.localPosition = new Vector2(Game1Player.instance.PlayerRoadX[1], 0);
				} else
				{
					rt.localPosition = new Vector2(Game1Player.instance.PlayerRoadX[3], 0);
				}
			}
		}
	}
}
