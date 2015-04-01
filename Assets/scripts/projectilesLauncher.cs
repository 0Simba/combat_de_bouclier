using UnityEngine;
using System.Collections;

public class ProjectilesLauncher : MonoBehaviour {


    public GameObject GOspearProjectile;
    public GameObject GOlegProjectile;
    public GameObject GOhelmetProjectile;
    public GameObject GOplastronProjectile;
    public GameObject GOshieldProjectile;

    private EquipmentController equipmentController;
    private Aim                 aim;

    private MainPlayer mainPlayer;
    private Mapping _gamepad;

	void Start () {
        mainPlayer = GetComponent<MainPlayer>();
        _gamepad = GetComponent<Mapping>();
        equipmentController = transform.GetComponent<EquipmentController>();
        aim                 = transform.GetComponent<Aim>();
    }


	void Update () {
/*        Debug.Log("--"+ _gamepad.shoot.WasPressed);
        if (_gamepad.shoot.WasPressed && aim.isIt)
        {
            Debug.Log("heheheh");
            ThrowEquipmment();
        }
 */	}


    public void ThrowEquipmment () {
        string objectName = equipmentController.getThrowObjectName();
        if (objectName != null) {
            GameObject projectile;
            projectile        = GetInstiateProjectileByName(objectName);
            Projectile script = projectile.GetComponent<Projectile>() as Projectile;
            script.MyInit(aim.direction, objectName, mainPlayer.playerIndex);
        }
    }


    GameObject GetInstiateProjectileByName (string name) {
        if      (name == "plastron") return Instantiate(GOplastronProjectile, transform.position, Quaternion.identity) as GameObject;
        else if (name == "helmet")   return Instantiate(GOhelmetProjectile,   transform.position, Quaternion.identity) as GameObject;
        else if (name == "shield")   return Instantiate(GOshieldProjectile,   transform.position, Quaternion.identity) as GameObject;
        else                         return Instantiate(GOspearProjectile,    transform.position, Quaternion.identity) as GameObject;
    }

}
