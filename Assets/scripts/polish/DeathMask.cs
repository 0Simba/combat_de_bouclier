using UnityEngine;
using System.Collections;

public class DeathMask : MonoBehaviour {

    public float duration = 1;
    public GameObject prefab;
	// Use this for initialization

    public void CreateMask()
    {
        Object go = GameObject.Instantiate(prefab, transform.position, Quaternion.identity);
        //Debug.Log(go);
        Destroy(go, duration);
    }

}
