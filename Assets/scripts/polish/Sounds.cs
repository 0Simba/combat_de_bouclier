using UnityEngine;
using System.Collections;

public class Sounds : MonoBehaviour {

    static public AudioSource hit;
    static public AudioSource pick;
    static public AudioSource cast;
    static public AudioSource kill;
    static public AudioSource jump;
    static public AudioSource dash;

    public AudioSource _hit;
    public AudioSource _pick;
    public AudioSource _cast;
    public AudioSource _kill;
    public AudioSource _jump;
    public AudioSource _dash;

	void Start () {
        hit  = _hit;
        pick = _pick;
        cast = _cast;
        kill = _kill;
        jump = _jump;
        dash = _dash;
	}


    static public void Play (string name) {
        if      (name == "throw") cast.Play();
        else if (name == "hit")   hit.Play();
        else if (name == "pick")  pick.Play();
        else if (name == "kill")  kill.Play();
        else if (name == "jump")  jump.Play();
        else if (name == "dash")  dash.Play();
    }
}
