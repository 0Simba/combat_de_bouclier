using UnityEngine;
using System.Collections;

public class HudControllerManager : MonoBehaviour {

    public HudController[] hudControllers;


    static private HudControllerManager instance;

	void Start () {

        instance = this;
	}

    static public void AddKill (int playerIndex) {
        int score = MainGame.playersScores[playerIndex];
        Debug.Log(playerIndex + " : " + score);
        instance.hudControllers[playerIndex].AddKill(score);
    }
}
