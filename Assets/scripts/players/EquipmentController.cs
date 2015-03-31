using UnityEngine;
using System.Collections;
using System;

public class EquipmentController : MonoBehaviour {

    public GameObject spearRef;
    public GameObject shieldRef;
    public GameObject helmetRef;
    public GameObject plastronRef;

    public string[] itemsName   = new string[4] {"spear", "shield", "helmet", "plastron"};
    public bool[]   itemsWeared = new bool[4]   {true   , false   , false   , false};
    public int      lifes       = 3;
    public int      damageValue = 3;

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
        if      (name == "spear")    spearRef.GetComponent<Renderer>().enabled    = true;
        else if (name == "helmet")   helmetRef.GetComponent<Renderer>().enabled   = true;
        else if (name == "plastron") plastronRef.GetComponent<Renderer>().enabled = true;
        else if (name == "shield")   shieldRef.GetComponent<Renderer>().enabled   = true;
    }


    void HideItemsByName (string name) {
        if      (name == "spear")    spearRef.GetComponent<Renderer>().enabled    = false;
        else if (name == "helmet")   helmetRef.GetComponent<Renderer>().enabled   = false;
        else if (name == "plastron") plastronRef.GetComponent<Renderer>().enabled = false;
        else if (name == "shield")   shieldRef.GetComponent<Renderer>().enabled   = false;
    }


    void OnCollisionEnter2D (Collision2D col) {
        string layerName = LayerMask.LayerToName(col.gameObject.layer);

        if (layerName == "Projectiles") ProjectileCollision(col);
    }


    void ProjectileCollision (Collision2D col) {
        Projectile projectileScript = col.transform.GetComponent<Projectile>();

        if (projectileScript.pickable) {
            PickItem(projectileScript.typeName);
        }
        else {
            Damaged();
        }
    }


    void PickItem (string name) {
        int index = Array.IndexOf(itemsName, name);
        itemsWeared[index] = true;
        ShowItemByName(name);
    }


    void Damaged () {
        int damageCount = damageValue;
        for (int i = itemsWeared.Length - 1; i >= 0; i--) {
            if (itemsWeared[i]) {

                itemsWeared[i] = false;
                damageCount--;
                HideItemsByName(itemsName[i]);
                // TODO coder layer perte des items
                if (damageCount == 0) break;

            }
        }

        lifes -= damageCount;

        if (lifes <= 0) {
			gameObject.SetActive(false);
		}
    }
}
