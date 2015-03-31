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
        if (Input.GetKeyDown(keyName) && aim != Vector2.zero) {
            throwEquipmment();
        }
 	}

    void throwEquipmment () {
        GameObject projectile;
        projectile = Instantiate(GOspearProjectile, transform.position, Quaternion.identity) as GameObject;
        Projectile script = projectile.GetComponent<Projectile>() as Projectile;
        script.MyInit(aim);
    }
}
