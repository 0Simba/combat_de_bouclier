using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Credits : MonoBehaviour {

	public float speed;
	public float maxX;
	private Transform creditsText;
	private float creditsX;

	// Use this for initialization
	void Start () {
		creditsText = GetComponentInChildren<Text> ().transform;
		creditsX = creditsText.localPosition.x;
	}
	
	// Update is called once per frame
	void Update () {
		creditsText.position -= new Vector3(speed, 0f, 0f);
		if (creditsText.localPosition.x < -maxX)
		{
			creditsText.localPosition = new Vector3(creditsX + 800, 0, 0);
		}
		if (creditsText.localPosition.x > creditsX + 800)
		{
			creditsText.localPosition = new Vector3(creditsX + 800, 0, 0);
		}
	}
}
