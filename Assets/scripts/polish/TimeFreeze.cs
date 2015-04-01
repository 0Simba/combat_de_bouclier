using UnityEngine;
using System.Collections;

public class TimeFreeze : MonoBehaviour {

	public static void Freeze(float d) {
		TimeFreeze._instance.StartCoroutine(FreezeCoroutine(d));
	}

	// Use this for initialization

	static IEnumerator FreezeCoroutine(float duration) {
		Time.timeScale = 0.01f;
		yield return new WaitForSeconds (duration);
		Time.timeScale = 1;
	}

	private static TimeFreeze _instance;
	void Start() {
		TimeFreeze._instance = this;
	}
}
