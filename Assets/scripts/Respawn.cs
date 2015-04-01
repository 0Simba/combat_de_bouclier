using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {

    private float restTime   = -1;
    private bool  respawning = false;

    private EquipmentController equipmentController;


    public void SetDie () {
        equipmentController = transform.GetComponent<EquipmentController>();
        transform.position = Vector3.right * 100;
        restTime   = MainGame.respawnDuration;
        respawning = true;
    }


    void Update () {
        if (respawning == true) {
            restTime -= Time.deltaTime;

            if (restTime <= 0) {
                respawning = false;
                transform.position = MainGame.respawnPoint.transform.position;
                equipmentController.Reset();
            }
        }
    }
}
