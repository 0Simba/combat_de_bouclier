using UnityEngine;
using System.Collections;

public class LayersIndex : MonoBehaviour {

    static public int projectiles;
    static public int collectibles;


	void Awake () {
        projectiles  = LayerMask.NameToLayer("Projectiles");
        collectibles = LayerMask.NameToLayer("Collectibles");
	}

	void Update () {

	}
}
