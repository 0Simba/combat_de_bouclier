using UnityEngine;
using System.Collections;

public class OneAxisMapping : Mapping {

    private ProjectilesLauncher projectileLauncher;

    void Start()
    {
        shoot = new ButtonInput();
        jump = new ButtonInput();
        dash = new ButtonInput();
        projectileLauncher = GetComponent<ProjectilesLauncher>();
    }

	// Update is called once per frame
	void Update () {
        ButtonInput _s = shoot as ButtonInput;
        _s.Update(DeviceManager.devices[deviceID].Action3);
        ButtonInput _j = jump as ButtonInput;
        _j.Update(DeviceManager.devices[deviceID].Action1);
        ButtonInput _d = dash as ButtonInput;
        _d.Update(DeviceManager.devices[deviceID].Action2);
        moveAxis = DeviceManager.devices[deviceID].LeftStick;
        aimAxis = DeviceManager.devices[deviceID].LeftStick;


        if (shoot.WasPressed) {
            projectileLauncher.ThrowEquipmment();
        }
	}
}
