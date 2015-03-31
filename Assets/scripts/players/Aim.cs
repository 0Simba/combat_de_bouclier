using UnityEngine;
using System.Collections;

public class Aim : MonoBehaviour {

    public Vector2    direction = Vector2.right;
    public GameObject aimSprite;

    void Start () {
    }


	void Update () {
        direction            = new Vector2(DeviceManager.currentDevice.RightStickX, DeviceManager.currentDevice.RightStickY);
        float angle          = Mathf.Atan2(direction.x, direction.y) / Mathf.PI * -180;
        Quaternion rotation  = Quaternion.identity;
        rotation.eulerAngles = new Vector3(0, 0, angle);

        aimSprite.transform.rotation = rotation;
    }
}
