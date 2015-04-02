using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Credits : MonoBehaviour {

	public float speed;
	public float maxX;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponentInChildren<Text> ().transform.position -= new Vector3(speed, 0f, 0f);
		if (GetComponentInChildren<Text> ().transform.localPosition.x < -maxX)
		{
			GetComponentInChildren<Text> ().transform.localPosition = new Vector3(0, 0, 0);
		}
		if (GetComponentInChildren<Text> ().transform.localPosition.x > 0)
		{
			GetComponentInChildren<Text> ().transform.localPosition = new Vector3(0, 0, 0);
		}
	}
}
