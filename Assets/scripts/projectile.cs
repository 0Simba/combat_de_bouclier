using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public int    force         = 5000;
    public string typeName      = "spear";
    public int    launcherIndex = 0;

    private Rigidbody2D rigidbody;
    private Vector2     lastVelocity;
    private float       ghostRestTime = -1;
    private float       timeGhost     = 0.3f;

    private ParticleSystem particles;

    void Awake () {
        rigidbody        = GetComponent<Rigidbody2D>();
        GameObject child = transform.GetChild(0).gameObject; // TODO it's unsafe
        particles        = child.GetComponent<ParticleSystem>();
    }


    void Update () {
        lastVelocity = rigidbody.velocity;

        if (ghostRestTime > 0) ElapseGhost();
    }


    void ElapseGhost () {
        ghostRestTime -= Time.deltaTime;

        if (ghostRestTime <= 0) {
            BecameCollectible();
        }
    }


    void SetGhost () {
        gameObject.layer = LayersIndex.ghosts;
        ghostRestTime    = timeGhost;
    }


    public void MyInit (Vector2 direction, string name, int _launcherIndex) {
        transform.Translate(direction * 2);        // TODO be more safe
        rigidbody.AddForce(direction * force);

        typeName      = name;
        launcherIndex = _launcherIndex;
    }


    void OnCollisionEnter2D (Collision2D col) {
        string layerName = LayerMask.LayerToName(col.gameObject.layer);

        if      (layerName == "Walls")       BecameCollectible();
        else if (layerName == "Players")     PlayersCollision(col);
        else if (layerName == "Projectiles") BecameCollectible();
        else if (layerName != "Default")     Debug.Log("Pas de collision entre les projectiles et le layer : " + layerName);
    }



    void BecameCollectible () {
        gameObject.layer = LayersIndex.collectibles;
        rigidbody.velocity = Vector2.zero;
        particles.Play();
    }


    void PlayersCollision (Collision2D col) {

        if (gameObject.layer == LayersIndex.collectibles) {
            Destroy(gameObject);
        }
        else {
            rigidbody.AddForce(lastVelocity * -10);         // TODO use var
            SetGhost();
        }
    }
}
