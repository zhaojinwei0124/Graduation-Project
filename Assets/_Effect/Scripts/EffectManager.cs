using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace UI {

	public enum EffectType {
		Effect_Dead_Fire,
		Effect_Dead_Water,
	}

	public class EffectManager : MonoBehaviour {
		public static EffectManager instance;
		public Dictionary<string, ShowEffect> effectDic = new Dictionary<string, ShowEffect>();

		void Awake() {
			instance = this;
		}

		void Start() {
			StartCoroutine(LoadEffect());
		}

		IEnumerator LoadEffect() {
			foreach (string pName in Enum.GetNames(typeof(EffectType))) {
				GameObject rObj = Resources.Load<GameObject>(pName);
				GameObject tObj = Instantiate(rObj) as GameObject;
				tObj.transform.SetParent(transform);
				((RectTransform)tObj.transform).localScale = new Vector3(1.0f, 1.0f, 1.0f);
				effectDic.Add(pName, tObj.GetComponent<ShowEffect>());
				yield return 0;
			}
		}

		ShowEffect LoadEffect(string pName) {
			GameObject rObj = Resources.Load<GameObject>(pName);
			GameObject tObj = Instantiate(rObj) as GameObject;
			tObj.transform.SetParent(transform);
			((RectTransform)tObj.transform).localScale = new Vector3(1.0f, 1.0f, 1.0f);
			ShowEffect effect = tObj.GetComponent<ShowEffect>();
			effectDic.Add(pName, effect);
			return effect;
		}

		public void PlayEffect(EffectType type) {
			if (effectDic.ContainsKey(type.ToString())) {
				ShowEffect tObj = effectDic[type.ToString()];
				tObj.Show(true);
			} else {
				ShowEffect effect = LoadEffect(type.ToString());
				effect.Show(true);
			}
		}

		public void PlayEffect(EffectType type, Vector2 point) {
			if (effectDic.ContainsKey(type.ToString())) {
				ShowEffect tObj = effectDic[type.ToString()];
				tObj.Show(true, point);
			} else {
				ShowEffect effect = LoadEffect(type.ToString());
				effect.Show(true);
			}
		}

	}
}
