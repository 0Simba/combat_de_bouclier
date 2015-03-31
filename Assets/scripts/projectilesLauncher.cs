using UnityEngine;
using System.Collections;

public class ProjectilesLauncher : MonoBehaviour {


    public string     keyName        = "a";
    public float      minVectorValue = 0.2f;
    public GameObject GOspearProjectile;

    private EquipmentController equipmentController;
    private Aim                 aim;

	void Start () {
        equipmentController = transform.GetComponent<EquipmentController>();
        aim                 = transform.GetComponent<Aim>();
    }


	void Update () {
        if (DeviceManager.currentDevice.LeftBumper.WasPressed) {
            float sumXY = Mathf.Abs(aim.direction.x) + Mathf.Abs(aim.direction.y);

            if (sumXY >= minVectorValue) {
                ThrowEquipmment();
            }
        }
 	}


    void ThrowEquipmment () {
        string objectName = equipmentController.getThrowObjectName();
        if (objectName != null) {
            GameObject projectile;
            projectile        = Instantiate(GOspearProjectile, transform.position, Quaternion.identity) as GameObject;
            Projectile script = projectile.GetComponent<Projectile>() as Projectile;
            Debug.Log(aim.direction);
            script.MyInit(aim.direction);
        }
    }


}
