using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Camera))]
public class Screenshake : MonoBehaviour {
	
	static public Screenshake main;

	private Vector3 _shakeDirection = Vector3.zero;
	private float _shakeSlowDown  = 0.95f;

	[Header("DashInWall")]
	public float DashInWallshakeSlowDown  = 0.95f;
	public float DashInWallshakeIntensity = 2;

	private Vector3 _origin;
	
	// Use this for initialization
	void Start () {
		main = this;
		_origin = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = _origin + _shakeDirection;
		_shakeDirection *= -_shakeSlowDown;
	}

	public void ShakeDashInWall(Vector3 dir) {
		_shakeDirection += dir.normalized * DashInWallshakeIntensity;
		_shakeSlowDown  = DashInWallshakeSlowDown;
	}
}
