using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	//玩家得分
	private int Grade;
	//玩家
	private GameObject Player;
	//设置GM
	static public GameManager Instance;

	void Start ()
	{
		Player = GameObject.Find("Player");
		Instance = this;
	}

	void Update () 
	{

	}

	void OnGUI()
	{
		GUI.color = Color.black;
		if (Player == null) {
			//游戏结束界面
			GUI.skin.label.fontSize = 50;
			GUI.skin.label.alignment = TextAnchor.LowerCenter;
			GUI.Label (new Rect (0, Screen.height * 0.2f, Screen.width, 60), "游戏失败");
			GUI.skin.label.fontSize = 20;
			if (GUI.Button (new Rect (Screen.width * 0.5f - 125, Screen.width * 0.5f, 250, 60), "再试一次")) {
				SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
			}
			if (GUI.Button (new Rect (Screen.width * 0.5f - 125, Screen.width * 0.6f, 250, 60), "离开游戏")) {
				Application.Quit ();
			}
		} else {
			//得分
			GUI.skin.label.fontSize = 30;
			GUI.skin.label.alignment = TextAnchor.LowerCenter;
			GUI.Label (new Rect (0, 25, Screen.width, 40), "得分：" + Grade);

			//技能冷却时间
			GUI.skin.label.alignment = TextAnchor.LowerLeft;
			GUI.Label (new Rect (0, 25, Screen.width, 40), "光盾冷却时间：" + (int)Player.GetComponent<Player> ().GuardCD);
		}
	}

	public void Add(int Value)
	{
		Grade+=Value;
	}
}
