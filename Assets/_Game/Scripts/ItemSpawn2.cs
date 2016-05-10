using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using client;
using Common;
using Update;

public class ItemSpawn2 : MonoBehaviour {
	/// <summary>
	/// 生产物品的时间间隔
	/// </summary>
	public float TimeInterval = 2f;
	/// <summary>
	/// 产生敌人的位置
	/// </summary>
	public List<Transform> PosList;
	/// <summary>
	/// 物品水
	/// </summary>
	private GameObject Water;
	/// <summary>
	/// 物品火
	/// </summary>
	private GameObject Fire;
	public Coroutine Coroutine;

	public void Start() {
		if (Coroutine != null) {
			StopCoroutine(Coroutine);
		}
		Water = UIPreLoadManager.instance.GetGameObjectByName("Water2");
		Fire = UIPreLoadManager.instance.GetGameObjectByName("Fire2");
		Coroutine = StartCoroutine(SpawnItem());
	}

	/// <summary>
	/// 产出物品
	/// </summary>
	/// <returns></returns>
	IEnumerator SpawnItem() {
		GameObject Item = null;
		Transform Pos = null;
		int index = 0;
		int rd;

		while (true) {
			yield return new WaitForSeconds(TimeInterval);
			if (Client.instance.Game.ItemCount < 8) {
				rd = Random.Range(0, 2);
				if (rd == 0) {
					Item = Instantiate(Water);
				} else {
					Item = Instantiate(Fire);
				}

				rd = Random.Range(0, 4);
				switch (rd) {
					case 0:
						Pos = PosList[0];
						index = 0;
						break;
					case 1:
						Pos = PosList[1];
						index = 1;
						break;
					case 2:
						Pos = PosList[2];
						index = 2;
						break;
					case 3:
						Pos = PosList[3];
						index = 3;
						break;
				}
				Client.instance.Game.ItemCount += 1;
				SetItemPosition(Item, Pos, index);
			}
		}
	}

	/// <summary>
	/// 设置物品位置
	/// </summary>
	/// <param name="item">物品</param>
	/// <param name="left">是否是左边道路上的物品</param>
	void SetItemPosition(GameObject item, Transform pos, int index) {
		RectTransform rt = (RectTransform)item.transform;
		rt.SetParent(transform);
		rt.localScale = Vector3.one;
		rt.localPosition = pos.localPosition;
		var rigidbody = rt.GetComponent<Rigidbody2D>();
		if (rigidbody)
		{
			float min = 0.7f;
			float max = 0.9f;

			switch (index) {
				case 0:
					rigidbody.velocity = new Vector2(Random.Range(-max, -min), Random.Range(-max, -min));
					break;
				case 1:
					rigidbody.velocity = new Vector2(Random.Range(-max, -min), Random.Range(max, min));
					break;
				case 2:
					rigidbody.velocity = new Vector2(Random.Range(min, max), Random.Range(min, max));
					break;
				case 3:
					rigidbody.velocity = new Vector2(Random.Range(min, max), Random.Range(-min, -max));
					break;
			}
		}

		
	}

}
