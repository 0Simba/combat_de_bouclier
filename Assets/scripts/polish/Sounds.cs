using UnityEngine;
using System.Collections;

public class Sounds : MonoBehaviour {

    static public AudioSource hit;
    static public AudioSource pick;
    static public AudioSource cast;
    static public AudioSource kill;

    public AudioSource _hit;
    public AudioSource _pick;
    public AudioSource _cast;
    public AudioSource _kill;

	void Start () {
        hit = _hit;
        pick = _pick;
        cast = _cast;
        kill = _kill;
	}

	void Update () {
	}
}
