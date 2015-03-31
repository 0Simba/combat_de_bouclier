using UnityEngine;
using System.Collections;

public class ProjectilesLauncher : MonoBehaviour {


    public Vector2    aim     = Vector2.up;
    public string     keyName = "a";

    public GameObject GOspearProjectile;

    private EquipmentController equipmentController;

	void Start () {
        equipmentController = transform.GetComponent<EquipmentController>();
        Debug.Log(equipmentController);
    }

	void Update () {
<<<<<<< HEAD
        if (Input.GetKeyDown(keyName) && aim != Vector2.zero) {
            throwEquipmment();
=======
        if (DeviceManager.currentDevice.LeftBumper.WasPressed && GOprojectile && aim != Vector2.zero) {
            GameObject projectile;
            projectile = Instantiate(GOprojectile, transform.position, Quaternion.identity) as GameObject;

            if (projectile) {
                Projectile script = projectile.GetComponent<Projectile>() as Projectile;
                script.MyInit(aim);
            } else {
            }
>>>>>>> 7a2a2533bcc6841791e962d44554743c1b46fad4
        }
 	}

    void throwEquipmment () {
        GameObject projectile;
        projectile = Instantiate(GOspearProjectile, transform.position, Quaternion.identity) as GameObject;
        Projectile script = projectile.GetComponent<Projectile>() as Projectile;
        script.MyInit(aim);
    }
}
