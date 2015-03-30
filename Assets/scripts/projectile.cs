using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public  int         force    = 5000;
    private bool        pickable = false;
    private Rigidbody2D rigidbody;

    public void MyInit (Vector2 direction) {
        rigidbody = GetComponent<Rigidbody2D>();
        transform.Translate(direction * 2);        // TODO be more safe
        rigidbody.AddForce(direction * force);
    }

    void OnCollisionEnter2D (Collision2D col) {
        pickable = true;
        rigidbody.velocity = Vector2.zero;
    }

	void Start () {
	}

    void Update() {

    }
}
