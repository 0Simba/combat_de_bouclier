using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainGame : MonoBehaviour {

    static public int[] playersScores;
	[HideInInspector]
	public int[] _playersScores;
	public int scoreToWin;

    static public int respawnDuration = 3;
    public int _respawnDuration;


    static public GameObject respawnPoint;
    public GameObject _respawnPoint;
	public MainPlayer[] players;
	public HudController[] playersGUI;

    void Start () {
		_playersScores = new int[4];
        playersScores   = _playersScores;
        respawnDuration = _respawnDuration;
        respawnPoint    = _respawnPoint;
		for(int i = 0; i < players.Length; i++)
		{
			if (GameDatas.playersInputIndex[i] != -1)
			{
				players[i].transform.gameObject.SetActive(true);
				playersGUI[i].transform.gameObject.SetActive(true);
			}
		}
    }

	void Update() {
		for(int i = 0; i < playersScores.Length; i++)
		{
			if (playersScores[i] >= scoreToWin)
			{
				WinGame();
			}
		}
	}

	public void WinGame()
	{
		Debug.Log ("Fini");
	}
}
