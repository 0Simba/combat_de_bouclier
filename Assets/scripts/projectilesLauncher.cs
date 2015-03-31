using UnityEngine;
using System.Collections;

public class ProjectilesLauncher : MonoBehaviour {


    public Vector2    aim     = Vector2.up;
    public string     keyName = "a";
    public GameObject GOprojectile;

	void Start () {

	}

	void Update () {
        if (DeviceManager.currentDevice.LeftBumper.WasPressed && GOprojectile && aim != Vector2.zero) {
            GameObject projectile;
            projectile = Instantiate(GOprojectile, transform.position, Quaternion.identity) as GameObject;

            if (projectile) {
                Projectile script = projectile.GetComponent<Projectile>() as Projectile;
                script.MyInit(aim);
            } else {
            }
        }
 	}
}
