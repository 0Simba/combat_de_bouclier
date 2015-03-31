﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuDevice : MonoBehaviour {

	public GameObject[] playersUI;
	public bool[] playersOk;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < playersUI.Length; i++)
		{
			playersOk[i] = playersUI[i].GetComponent<DeviceUI>().isOk;
		}
	}

	void StartGame() {
		for(int i = 0; i < playersOk.Length; i++)
		{

		}
	}
}
