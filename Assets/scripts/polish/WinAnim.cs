using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WinAnim : MonoBehaviour {

    public AnimationCurve yPositionAnim;
    public AnimationCurve sizeAnim;
    public float          duration;
    public float          yDelta = 200;

    private float         elapsedTime = 0;
    private Text          text;
    private RectTransform textTransform;
    private float         startSize;

    static private WinAnim       instance;


	void Start () {
       text          = GetComponent<Text>();
       textTransform = GetComponent<RectTransform>();
       elapsedTime   = duration;
       startSize     = text.fontSize;
       instance      = this;
       Hide();
//       Launch("red");
    }


    static public void Launch (string winnerColor) {
        instance.elapsedTime = 0;
        instance.text.text   = "Player " + winnerColor + " win !";
        MainGame.ended       = true;
    }


    static public void Hide () {
        instance.text.text = "";
    }


	void Update () {
        if (elapsedTime < duration) {
            elapsedTime    += Time.deltaTime;
            float ratio     = elapsedTime / duration;
            float sizeRatio = sizeAnim.Evaluate(ratio);
            float yPosition = yPositionAnim.Evaluate(1 - ratio);

            text.fontSize = (int) (startSize * sizeRatio);
            textTransform.anchoredPosition = new Vector2(0, yPosition * yDelta);

        }
	}


}
