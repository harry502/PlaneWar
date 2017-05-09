using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI()
	{
		GUI.color = Color.black;

		GUI.skin.label.fontSize = 100;
		GUI.skin.label.alignment = TextAnchor.LowerCenter;
		GUI.skin.label.fontStyle = FontStyle.Italic;
		GUI.Label (new Rect (0, Screen.height * 0.2f, Screen.width, 150), "飞机大战");

		GUI.skin.button.fontSize = 50;
		if (GUI.Button (new Rect (Screen.width * 0.5f - 125, Screen.width * 0.5f, 250, 60), "开始游戏"))
		{
			SceneManager.LoadScene ("Game");
		}
	}
}
