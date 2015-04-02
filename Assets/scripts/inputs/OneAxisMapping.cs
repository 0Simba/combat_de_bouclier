using UnityEngine;
using System.Collections;

public class OneAxisMapping : Mapping {

    private ProjectilesLauncher projectileLauncher;

    private TriggerTool _jumpTrigger;
    void Start()
    {
        //_jumpTrigger = new TriggerTool();
        shoot = new ButtonInput();
        jump = new ButtonInput();
        dash = new ButtonInput();
        projectileLauncher = GetComponent<ProjectilesLauncher>();
    }

	// Update is called once per frame
	void Update () {
        ButtonInput _s = shoot as ButtonInput;
        InControl.InputControl[] shootBtn = { DeviceManager.devices[deviceID].RightTrigger, DeviceManager.devices[deviceID].Action3 };
        _s.Update(shootBtn);
        
        ButtonInput _j = jump as ButtonInput;
        _j.Update(DeviceManager.devices[deviceID].Action1);
        ButtonInput _d = dash as ButtonInput;
        InControl.InputControl[] dashBtn = { DeviceManager.devices[deviceID].Action2, DeviceManager.devices[deviceID].RightBumper };
        _d.Update(dashBtn);
        moveAxis = DeviceManager.devices[deviceID].LeftStick;
        aimAxis = DeviceManager.devices[deviceID].LeftStick;


      
	}
}
