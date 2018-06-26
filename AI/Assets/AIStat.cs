using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AIStat {

	[Range (0f, 100f)]
	public float stat = 100f;
	public float baseDecrease = 0.1f;
	private float decreaseValue;
	[HideInInspector]
	public float timeLeftAlone;

	// Decreases the stat by x amount, the longer it's left alone the higher x is.s
	public bool Decrease () {
		float time = Time.deltaTime * Random.Range (1f, 1.1f);
		timeLeftAlone += time;
		decreaseValue = (baseDecrease * Random.Range (0.9f, 1.1f))+ (Mathf.Pow (timeLeftAlone / Random.Range (8f, 20f), 2f));
		stat = Mathf.Clamp (stat -= decreaseValue * time, 0f, 100f);
		if (stat == 0) {
			return true;
		}
		else return false;
	}

	public void Reset () {
		stat = 100f;
		decreaseValue = 0f;
		timeLeftAlone = 0f;
	}
	public void Reset (float _value) {
		stat = Mathf.Clamp (stat += _value, 0f, 100f);
		if (_value > 0) {
			timeLeftAlone = 0f;
		}
	}
}