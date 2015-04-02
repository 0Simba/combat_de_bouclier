using UnityEngine;
using System.Collections;
using System;

public class EquipmentController : MonoBehaviour {

    public GameObject spearRef;
    public GameObject shieldRef;
    public GameObject helmetRef;
    public GameObject plastronRef;
    public GameObject legRef;
    public GameObject penisRef;
    public HudController hudController;

    private string[] itemsName   = new string[4] {"shield", "helmet", "plastron", "leg"};
    public bool[]   itemsWeared = new bool[4]   {true    , true    , true      , true};
    public int      lifes       = 3;
    public int      damageValue = 3;

    private MainPlayer mainPlayer;
    private Respawn    respawn;


    void Start () {
        mainPlayer = GetComponent<MainPlayer>();
        respawn    = GetComponent<Respawn>();

        penisRef.GetComponent<Renderer>().enabled = false;
    }


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
        if      (name == "helmet")   helmetRef.GetComponent<Renderer>().enabled   = true;
        else if (name == "plastron") plastronRef.GetComponent<Renderer>().enabled = true;
        else if (name == "shield")   shieldRef.GetComponent<Renderer>().enabled   = true;
        else if (name == "leg") {
            legRef.GetComponent<Renderer>().enabled   = true;
            penisRef.GetComponent<Renderer>().enabled = false;
        }
    }


    void HideItemsByName (string name) {
        if      (name == "helmet")   helmetRef.GetComponent<Renderer>().enabled   = false;
        else if (name == "plastron") plastronRef.GetComponent<Renderer>().enabled = false;
        else if (name == "shield")   shieldRef.GetComponent<Renderer>().enabled   = false;
        else if (name == "leg") {
            legRef.GetComponent<Renderer>().enabled   = false;
            penisRef.GetComponent<Renderer>().enabled = true;
        }
    }


    void OnCollisionEnter2D (Collision2D col) {
        string layerName = LayerMask.LayerToName(col.gameObject.layer);

        if      (layerName == "Projectiles")  ProjectileCollision(col);
        else if (layerName == "Collectibles") PickItem(col);
    }


    void ProjectileCollision (Collision2D col) {
        Projectile projectile = col.transform.GetComponent<Projectile>();
        int launcherIndex     = projectile.launcherIndex;

        if (launcherIndex != mainPlayer.playerIndex) Damaged(launcherIndex);
    }


    void PickItem (Collision2D col) {
        Projectile projectileScript = col.transform.GetComponent<Projectile>();

        string name = projectileScript.typeName;
        int index = Array.IndexOf(itemsName, name);
        itemsWeared[index] = true;
        ShowItemByName(name);

        Sounds.Play("pick");
    }


    void Damaged (int launcherIndex) {
        int damageCount = damageValue;
        for (int i = 0; i < itemsWeared.Length && damageCount > 0; i++) {
            if (itemsWeared[i]) {

                itemsWeared[i] = false;
                damageCount--;
                HideItemsByName(itemsName[i]);
                // TODO coder layer perte des items
            }
        }

        lifes -= damageCount;


        if (lifes <= 0) {
            GetComponent<DeathMask>().CreateMask();
            respawn.SetDie();
			MainGame.playersScores[launcherIndex] += 1;
            Sounds.Play("kill");
            HudControllerManager.AddKill(launcherIndex);
            TimeFreeze.SlowMo();
            Debug.Log("heheheheh");
            
        }
        else {
            TimeFreeze.Freeze();
            Sounds.Play("hit");
        }
    }


    public void Reset () {
        for (int i = itemsWeared.Length - 1; i >= 0; i--) {
            itemsWeared[i] = true;
            ShowItemByName(itemsName[i]);
            lifes = 3;
        }
    }
}
