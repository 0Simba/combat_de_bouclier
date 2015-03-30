using UnityEngine;
using System.Collections;

public class projectile : MonoBehaviour {

    /*==========  TEMPS TEST  ==========*/
    private bool beInit = false;

    /*==========  REAL  ==========*/

    public  int         force = 5000;
    private Vector2     direction;
    private Rigidbody2D rigidbody;


    void MyInit (Vector2 _direction) {
        direction = _direction;
    }

	void Start () {
        rigidbody = GetComponent<Rigidbody2D>();;
	}

    void Update() {
        if (Input.GetKeyDown("space")) {
            rigidbody.AddForce(Vector2.up * force);
        }

        if (beInit) {
        }
    }
}
