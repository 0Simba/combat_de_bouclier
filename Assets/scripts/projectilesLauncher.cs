using UnityEngine;
using System.Collections;

public class projectilesLauncher : MonoBehaviour {

    public string     keyName = "a";
    public GameObject GOprojectile;

	void Start () {

	}

	void Update () {
        if (Input.GetKeyDown(keyName) && GOprojectile) {
            GameObject a = Instantiate(GOprojectile, transform.position, Quaternion.identity) as GameObject;
        }
 	}
}
