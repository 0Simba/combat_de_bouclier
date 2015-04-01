using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using InControl;

public class MenuDevice : MonoBehaviour {

	public string sceneToLoad;
	public GameObject[] playersUI;
	private bool[] playersOk;
	public Image startImage;
	private bool readyToStart;
	//public int[] testData;

	// Use this for initialization
	void Start () {
		playersOk = new bool[4];
		GameDatas.playersInputIndex = new int[4] {-1, -1, -1, -1};
	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < playersUI.Length; i++)
		{
			playersOk[i] = playersUI[i].GetComponent<DeviceUI>().isOk;
		}
		for(int i = 0; i < playersOk.Length; i++)
		{
			if ((playersOk[0]? 1:0) + (playersOk[1]? 1:0) + (playersOk[2]? 1:0) + 
			    (playersOk[3]? 1:0) > 1)
			{
				readyToStart = true;
			}
			else
			{
				readyToStart = false;
			}
		}
		if (readyToStart == true)
		{
			StartGame();
			startImage.transform.gameObject.SetActive(true);
		}
		if (readyToStart == false)
		{
			startImage.transform.gameObject.SetActive(false);
		}

		//testData = GameDatas.playersInputIndex;
	}

	void StartGame() {
		for(int i = 0; i < playersOk.Length; i++)
		{
			if ((playersOk[i] == true)&&(InputManager.Devices[i].MenuWasPressed))
			{
				//Debug.Log("start!");
				WriteGameDatas();
				LoadScene();
			}
		}
	}

	void WriteGameDatas()
	{
		for(int i = 0; i < playersOk.Length; i++)
		{
			if (playersOk[i] == true)
			{
				GameDatas.playersInputIndex[i] = i;
			}	
			else if (playersOk[i] == false)
			{
				GameDatas.playersInputIndex[i] = -1;
			}
		}
	}

	void LoadScene()
	{
		Application.LoadLevel (sceneToLoad);
	}
}
