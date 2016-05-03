using UnityEngine;
using System.Collections;

public class AutoMove : MonoBehaviour
{

	/// <summary>
	/// 移动的速度
	/// </summary>
	public Vector3 Speed = new Vector3(0,-150,0);
	
	/// <summary>
	/// RectTransform
	/// </summary>
	private RectTransform rt;

	void Awake()
	{
		rt = (RectTransform)transform;
	}

	void Update ()
	{
		transform.position += Speed*Time.deltaTime;
	}
}
