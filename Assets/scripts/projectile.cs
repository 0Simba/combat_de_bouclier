using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    /*==========  REAL  ==========*/

    public  int         force = 5000;
    private Rigidbody2D rigidbody;


    public void MyInit (Vector2 direction) {
        rigidbody = GetComponent<Rigidbody2D>();
        transform.Translate(direction);        // TODO be more safe
        rigidbody.AddForce(direction * force);
    }

	void Start () {
	}

    void Update() {

    }
}
