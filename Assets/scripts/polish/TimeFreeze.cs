using UnityEngine;
using System.Collections;

public class TimeFreeze : MonoBehaviour
{
    public float freezeDuration = 0.1f;
    public static void Freeze()
    {
        TimeFreeze._instance.StartCoroutine(FreezeCoroutine(TimeFreeze._instance.freezeDuration, 0.00001f));
    }

    public float slowMoDuration = 1f;
    public float slowMoScale = 0.25f;
    public static void SlowMo(float d = 0, float t=0)
    {
        if (t == 0)
        {
            t  = _instance.slowMoScale;
        }
        if (d == 0)
        {
            d = _instance.slowMoDuration;
        }
        TimeFreeze._instance.StartCoroutine(FreezeCoroutine(d, t));
    }

    // Use this for initialization

    static IEnumerator FreezeCoroutine(float duration, float timeScale = 0.25f)
    {
        Time.timeScale = timeScale;
        Debug.Log("youhou" + duration + " " + timeScale);
        yield return new WaitForSeconds(duration * timeScale);
        Debug.Log("youhaaaaou");
        Time.timeScale = 1;
    }

    

    private static TimeFreeze _instance;
    void Start()
    {
        TimeFreeze._instance = this;
    }
}
