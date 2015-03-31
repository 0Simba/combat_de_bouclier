using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public  int         force    = 5000;
    public  bool        pickable = false;
    public  string      typeName  = "spear";

    private Rigidbody2D rigidbody;
    private Vector2     lastVelocity;



    void Awake () {
        rigidbody = GetComponent<Rigidbody2D>();
    }


    void Update () {
        lastVelocity = rigidbody.velocity;
    }


    public void MyInit (Vector2 direction) {
        transform.Translate(direction * 2);        // TODO be more safe
        rigidbody.AddForce(direction * force);
    }


    void OnCollisionEnter2D (Collision2D col) {
        string layerName = LayerMask.LayerToName(col.gameObject.layer);

        if      (layerName == "Walls")       WallsCollision();
        else if (layerName == "Players")     PlayersCollision();
        else if (layerName == "Projectiles") ProjectileCollision();
        else if (layerName != "Default")     Debug.Log("Pas de collision entre les projectiles et le layer : " + layerName);
    }


    void WallsCollision () {
        pickable = true;
        rigidbody.velocity = Vector2.zero;
    }


    void ProjectileCollision () {
        pickable = true;
        rigidbody.velocity = Vector2.zero;
    }


    void PlayersCollision () {
        if (pickable) {
        }
        else {
            rigidbody.AddForce(lastVelocity * -10);         // TODO use var
            pickable = true;
        }
    }
}
