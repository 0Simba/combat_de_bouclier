﻿using UnityEngine;
using System.Collections;

public class ProjectilesLauncher : MonoBehaviour {


    public GameObject GOspearProjectile;
    public GameObject GOhelmetProjectile;
    public GameObject GOplastronProjectile;
    public GameObject GOshieldProjectile;

    private EquipmentController equipmentController;
    private Aim                 aim;

    private MainPlayer mainPlayer;

	void Start () {
        mainPlayer          = GetComponent<MainPlayer>();
        equipmentController = transform.GetComponent<EquipmentController>();
        aim                 = transform.GetComponent<Aim>();
    }


	void Update () {
        if (DeviceManager.devices[mainPlayer.deviceIndex].LeftBumper.WasPressed && aim.isIt) {
            ThrowEquipmment();
        }
 	}


    void ThrowEquipmment () {
        string objectName = equipmentController.getThrowObjectName();
        if (objectName != null) {
            GameObject projectile;
            projectile        = GetInstiateProjectileByName(objectName);
            Projectile script = projectile.GetComponent<Projectile>() as Projectile;
            script.MyInit(aim.direction, objectName);
        }
    }


    GameObject GetInstiateProjectileByName (string name) {
        if      (name == "plastron") return Instantiate(GOplastronProjectile, transform.position, Quaternion.identity) as GameObject;
        else if (name == "helmet")   return Instantiate(GOhelmetProjectile,   transform.position, Quaternion.identity) as GameObject;
        else if (name == "shield")   return Instantiate(GOshieldProjectile,   transform.position, Quaternion.identity) as GameObject;
        else                         return Instantiate(GOspearProjectile,    transform.position, Quaternion.identity) as GameObject;
    }

}
