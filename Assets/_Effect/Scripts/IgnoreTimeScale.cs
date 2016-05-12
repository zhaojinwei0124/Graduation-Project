using UnityEngine;
using System.Collections;

public class IgnoreTimeScale : MonoBehaviour {

	void Update() {
		var particleSystem = transform.GetComponent<ParticleSystem>();
		if (particleSystem) {
			particleSystem.Simulate(Time.unscaledDeltaTime, true, false);
		}
	}
}
