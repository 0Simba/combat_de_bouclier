using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainGame : MonoBehaviour {

    static public int[] playersScores;
    public int[] _playersScores;

    static public int respawnDuration = 3;
    public int _respawnDuration;


    static public GameObject respawnPoint;
    public GameObject _respawnPoint;
	public MainPlayer[] players;

    void Start () {
        playersScores   = _playersScores;
        respawnDuration = _respawnDuration;
        respawnPoint    = _respawnPoint;
		for(int i = 0; i < players.Length; i++)
		{
			if (GameDatas.playersInputIndex[i] != -1)
			{
				players[i].transform.gameObject.SetActive(true);
			}
		}
    }
}
