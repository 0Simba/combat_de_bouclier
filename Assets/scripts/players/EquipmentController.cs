using UnityEngine;
using System.Collections;

public class EquipmentController : MonoBehaviour {

    public GameObject spearRef;

    public string[] itemsName   = new string[4] {"spear", "shield", "helmet", "plastron"};
    public bool[]   itemsWeared = new bool[4]   {true   , false   , false   , false};

    public string getThrowObjectName () {
        for (int i = 0; i < itemsWeared.Length; i++) {
            if (itemsWeared[i]) {
                itemsWeared[i] = false;
                hideItemsByName(itemsName[i]);
                return itemsName[i];
            }
        }

        return null;
    }

    void hideItemsByName (string name) {
        if (name == "spear") spearRef.GetComponent<Renderer>().enabled = false;
    }

}
