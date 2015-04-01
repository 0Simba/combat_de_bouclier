using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public int    force         = 5000;
    public string typeName      = "spear";
    public int    launcherIndex = 0;

    private Rigidbody2D rigidbody;
    private Vector2     lastVelocity;



    void Awake () {
        rigidbody = GetComponent<Rigidbody2D>();
    }


    void Update () {
        lastVelocity = rigidbody.velocity;
    }


    public void MyInit (Vector2 direction, string name, int _launcherIndex) {
        transform.Translate(direction * 2);        // TODO be more safe
        rigidbody.AddForce(direction * force);

        typeName      = name;
        launcherIndex = _launcherIndex;
    }


    void OnCollisionEnter2D (Collision2D col) {
        string layerName = LayerMask.LayerToName(col.gameObject.layer);

        if      (layerName == "Walls")       WallsCollision();
        else if (layerName == "Players")     PlayersCollision(col);
        else if (layerName == "Projectiles") ProjectileCollision();
        else if (layerName != "Default")     Debug.Log("Pas de collision entre les projectiles et le layer : " + layerName);
    }


    void WallsCollision () {
        gameObject.layer = LayersIndex.collectibles;
        rigidbody.velocity = Vector2.zero;
    }


    void ProjectileCollision () {
        gameObject.layer = LayersIndex.collectibles;
        rigidbody.velocity = Vector2.zero;
    }


    void PlayersCollision (Collision2D col) {
        if (gameObject.layer == LayersIndex.collectibles) {
            Destroy(gameObject);
        }
        else {
            rigidbody.AddForce(lastVelocity * -10);         // TODO use var
        }
    }
}
