using UnityEngine;
using System.Collections;

public class Aim : MonoBehaviour {

    public Vector2 direction = Vector2.right;


    void Start () {
    }


	void Update () {
        direction = new Vector2(DeviceManager.currentDevice.RightStickX, DeviceManager.currentDevice.RightStickY);
    }
}
