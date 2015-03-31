using UnityEngine;
using System.Collections;

public class ProjectilesLauncher : MonoBehaviour {


    public Vector2    aim     = Vector2.up;
    public string     keyName = "a";

    public GameObject GOspearProjectile;

    private EquipmentController equipmentController;

	void Start () {
        equipmentController = transform.GetComponent<EquipmentController>();
    }

	void Update () {
        if (DeviceManager.currentDevice.LeftBumper.WasPressed && aim != Vector2.zero) {
            ThrowEquipmment();
        }
 	}

    void ThrowEquipmment () {
        string objectName = equipmentController.getThrowObjectName();

        if (objectName != null) {
            GameObject projectile;
            projectile        = Instantiate(GOspearProjectile, transform.position, Quaternion.identity) as GameObject;
            Projectile script = projectile.GetComponent<Projectile>() as Projectile;
            script.MyInit(aim);
        }
    }
}
