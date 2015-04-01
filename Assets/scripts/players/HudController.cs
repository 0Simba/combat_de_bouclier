using UnityEngine;
using System.Collections;

public class HudController : MonoBehaviour {

	public EquipmentController playerEquipement;
	public int                 playerIndex;
	public GameObject[]        lifesSlot;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		//This should'nt be done every frame but i'll do it anyway. Optimise here later;
		for (int i = 0; i < playerEquipement.itemsWeared.Length; i++) {
			GameObject child = transform.GetChild(i).gameObject;
			bool status = playerEquipement.itemsWeared[i];
			if (child.activeSelf != status) {
				child.SetActive(status);
			}
		}
		for (int i = 0; i < 3; i++) {
			GameObject child = transform.GetChild(i+4).gameObject;
			bool status = playerEquipement.lifes > i;
			if (child.activeSelf != status) {
				child.SetActive(status);
			}
		}
	}

	public void AddKill(int nbKill) {
		GameObject slot = lifesSlot[nbKill - 1];

		slot.SetActive(true);
	}
}
