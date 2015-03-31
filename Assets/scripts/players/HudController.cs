using UnityEngine;
using System.Collections;

public class HudController : MonoBehaviour {

	public EquipmentController playerEquipement;
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
	}
}
