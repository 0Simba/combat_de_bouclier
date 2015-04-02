using UnityEngine;
using System.Collections;

public class ProjectilesLauncher : MonoBehaviour {


    public GameObject GOspearProjectile;
    public GameObject GOlegProjectile;
    public GameObject GOhelmetProjectile;
    public GameObject GOplastronProjectile;
    public GameObject GOshieldProjectile;

    public bool       isLaunching = false;

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
        isLaunching = false;
        if (_gamepad.shoot.WasPressed)
        {
            ThrowEquipmment();
            isLaunching = true;
        }
    }


    public void ThrowEquipmment () {
        if (MainGame.ended) return;
        string objectName = equipmentController.getThrowObjectName();
        if (objectName != null) {
            GameObject projectile;
            projectile        = GetInstiateProjectileByName(objectName);
            Projectile script = projectile.GetComponent<Projectile>() as Projectile;
            script.MyInit(aim.direction, objectName, mainPlayer.playerIndex);

            Sounds.Play("throw");
        }
    }


    GameObject GetInstiateProjectileByName (string name) {
        if      (name == "plastron") return Instantiate(GOplastronProjectile, transform.position, Quaternion.identity) as GameObject;
        else if (name == "helmet")   return Instantiate(GOhelmetProjectile,   transform.position, Quaternion.identity) as GameObject;
        else if (name == "shield")   return Instantiate(GOshieldProjectile,   transform.position, Quaternion.identity) as GameObject;
        else                         return Instantiate(GOspearProjectile,    transform.position, Quaternion.identity) as GameObject;
    }

}
