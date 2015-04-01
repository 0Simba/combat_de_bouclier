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
        hit  = _hit;
        pick = _pick;
        cast = _cast;
        kill = _kill;
	}


    static public void Play (string name) {
        if      (name == "throw") cast.Play();
        else if (name == "hit")   hit.Play();
        else if (name == "pick")  pick.Play();
        else if (name == "kill")  kill.Play();
    }
}
