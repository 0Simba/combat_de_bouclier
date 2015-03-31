using UnityEngine;
using System.Collections;
using System;

public class EquipmentController : MonoBehaviour {

    public GameObject spearRef;

    public string[] itemsName   = new string[4] {"spear", "shield", "helmet", "plastron"};
    public bool[]   itemsWeared = new bool[4]   {true   , false   , false   , false};

    public string getThrowObjectName () {
        for (int i = 0; i < itemsWeared.Length; i++) {
            if (itemsWeared[i]) {
                itemsWeared[i] = false;
                HideItemsByName(itemsName[i]);
                return itemsName[i];
            }
        }

        return null;
    }


    public void ShowItemByName (string name) {
        if (name == "spear") spearRef.GetComponent<Renderer>().enabled = true;
    }


    void HideItemsByName (string name) {
        if (name == "spear") spearRef.GetComponent<Renderer>().enabled = false;
    }


    void OnCollisionEnter2D (Collision2D col) {
        string layerName = LayerMask.LayerToName(col.gameObject.layer);

        if (layerName == "Projectiles") ProjectileCollision(col);
    }


    void ProjectileCollision (Collision2D col) {
        Projectile projectileScript = col.transform.GetComponent<Projectile>();

        if (projectileScript.pickable) {
            int index = Array.IndexOf(itemsName, projectileScript.typeName);
            itemsWeared[index] = true;
            ShowItemByName(projectileScript.typeName);
        }
        else {

        }
    }

}
