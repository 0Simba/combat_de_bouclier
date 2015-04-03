using UnityEngine;
using System.Collections;

public class LoopMap : MonoBehaviour {

    public float add = 0;

    void OnTriggerEnter2D(Collider2D col)
    {
        col.transform.position = new Vector3(col.transform.position.x ,- col.transform.position.y + add, col.transform.position.z);
    }
}
