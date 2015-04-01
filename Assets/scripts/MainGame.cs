using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainGame : MonoBehaviour {

    static int[] playersScores;
    public int[] _playersScores;

    static int respawnDuration;
    public int _respawnDuration;



    void Start () {
        playersScores   = _playersScores;
        respawnDuration = _respawnDuration;
    }
}
