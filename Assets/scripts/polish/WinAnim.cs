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

	void Start () {
       text          = GetComponent<Text>();
       textTransform = GetComponent<RectTransform>();
       elapsedTime   = duration;
       startSize     = text.fontSize;

       Launch();
    }


    void Launch () {
        elapsedTime = 0;
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
