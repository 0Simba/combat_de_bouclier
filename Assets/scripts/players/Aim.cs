using UnityEngine;
using System.Collections;

public class Aim : MonoBehaviour {

    public Vector2    direction      = Vector2.right;
    public float      minVectorValue = 0.1f;
    public bool       isIt           = false;
    public GameObject aimSprite;

    private Mapping _gamepad;

    void Start () {
        _gamepad = GetComponent<Mapping>();
        aimSprite.SetActive(false);
    }


	void Update () {
        ApplyRotation();
        ApplyStateAndRender();
    }


    void ApplyRotation () {
        direction            = _gamepad.aimAxis;
        float angle          = Mathf.Atan2(direction.x, direction.y) / Mathf.PI * -180;
        Quaternion rotation  = Quaternion.identity;
        rotation.eulerAngles = new Vector3(0, 0, angle);

        aimSprite.transform.rotation = rotation;
    }


    void ApplyStateAndRender () {
        float sumXY    = Mathf.Abs(direction.x) + Mathf.Abs(direction.y);
        bool  newValue = (sumXY >= minVectorValue) ? true : false;

        if (newValue != isIt) aimSprite.SetActive(newValue);

        isIt = newValue;
    }
}
