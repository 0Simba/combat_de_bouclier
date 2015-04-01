using UnityEngine;
using System.Collections;

public class LayersIndex : MonoBehaviour {

    static public int projectiles;
    static public int collectibles;
    static public int ghosts;

	void Awake () {
        projectiles  = LayerMask.NameToLayer("Projectiles");
        collectibles = LayerMask.NameToLayer("Collectibles");
        ghosts       = LayerMask.NameToLayer("Ghosts");
    }

	void Update () {

	}
}
