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
        instance.hudControllers[playerIndex].AddKill(score);

        if (score == MainGame.killForWin) {
            string color = (playerIndex == 0) ? "red"    :
                           (playerIndex == 1) ? "blue"  :
                           (playerIndex == 2) ? "green" :
                           "yellow";

            WinAnim.Launch(color);
        }

    }
}
