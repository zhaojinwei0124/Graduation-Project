using UnityEngine;
using System.Collections;

namespace Common {

	public class AutoDestroy : MonoBehaviour {

		/// <summary>
		/// 从出生到销毁的时间
		/// </summary>
		public float TimeInterval = 3;
		void Start()
		{
			StartCoroutine(DestroyThis());
		}

		/// <summary>
		/// 销毁自身
		/// </summary>
		/// <returns></returns>
		IEnumerator DestroyThis() {
			yield return new WaitForSeconds(TimeInterval);
			Destroy(gameObject);
		}
	}
}
