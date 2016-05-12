using UnityEngine;

namespace Common {


	public class AutoMove : MonoBehaviour {

		/// <summary>
		/// 移动的速度
		/// </summary>
		public Vector3 Speed = new Vector3(0, -3, 0);

		void Update() {
			transform.position += Speed * Time.deltaTime;
		}
	}
}
