using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainGame : MonoBehaviour {

    static int[] playersScores;
    public int[] _playersScores;

    static int respawnDuration;
    public int _respawnDuration;

	public MainPlayer[] players;

    void Start () {
        playersScores   = _playersScores;
        respawnDuration = _respawnDuration;

		for(int i = 0; i < players.Length; i++)
		{
			if (GameDatas.playersInputIndex[i] != -1)
			{
				players[i].transform.gameObject.SetActive(true);
			}
		}
    }
}
