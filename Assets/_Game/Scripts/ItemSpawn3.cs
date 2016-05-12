using UnityEngine;
using System.Collections;
using Common;
using Game;
using Update;

namespace Game {

	public class ItemSpawn3 : MonoBehaviour {
		/// <summary>
		/// 生产物品的时间间隔
		/// </summary>
		private float TimeInterval = 0.5f;
		/// <summary>
		/// 物品水
		/// </summary>
		private GameObject Water;
		/// <summary>
		/// 物品火
		/// </summary>
		private GameObject Fire;
		/// <summary>
		/// 出生点（水、火）
		/// </summary>
		public RectTransform[] Transforms;
		public Coroutine Coroutine1;
		public Coroutine Coroutine2;

		public void Start() {
			if (Coroutine1 != null) {
				StopCoroutine(Coroutine1);
			}
			if (Coroutine2 != null) {
				StopCoroutine(Coroutine2);
			}
			Water = UIPreLoadManager.instance.GetGameObjectByName("Water3");
			Fire = UIPreLoadManager.instance.GetGameObjectByName("Fire3");
			Coroutine1 = StartCoroutine(SpawnWater());
			Coroutine2 = StartCoroutine(SpawnFire());
		}

		/// <summary>
		/// 产出水
		/// </summary>
		/// <returns></returns>
		IEnumerator SpawnWater() {
			TimeInterval = Random.Range(1f, 1.6f);
			while (true) {
				yield return new WaitForSeconds(TimeInterval);
				Water = Instantiate(Water);
				SetItemPosition(Water, true);
			}
		}

		/// <summary>
		/// 产出火
		/// </summary>
		/// <returns></returns>
		IEnumerator SpawnFire() {
			TimeInterval = Random.Range(1f, 1.6f);
			while (true) {
				yield return new WaitForSeconds(TimeInterval);
				Fire = Instantiate(Fire);
				SetItemPosition(Fire, false);
			}
		}

		/// <summary>
		/// 设置物品位置
		/// </summary>
		/// <param name="item">物品</param>
		/// <param name="left">是否是左边道路上的物品</param>
		void SetItemPosition(GameObject item, bool isWater) {
			RectTransform rt = (RectTransform)item.transform;
			rt.SetParent(transform);
			rt.localScale = Vector3.one;
			if (isWater) {
				rt.localPosition = Transforms[1].localPosition ;
			} else {
				rt.localPosition = Transforms[0].localPosition;
			}
		}
	}
}
