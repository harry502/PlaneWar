using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {

	//定义敌人速度
	public float SpawnTime=5.0f;
	//定义敌人对象数组
	public GameObject[] Enemys;
	//游戏进度
	private float GameTime = 0f;

	void Start () 
	{
		StartCoroutine("Spawn");
	}

	void Update()
	{
		GameTime += Time.deltaTime;
		if(GameTime >= 30f && SpawnTime>= 0.6f)
		{
			SpawnTime *= 0.7f;
			GameTime = 0;
		}
	}

	//通过迭代器生成敌人
	IEnumerator Spawn()
	{
		//等待
		yield return new WaitForSeconds(SpawnTime);
		//克隆对象
		Instantiate(Enemys[Random.Range(0,3)],new Vector3(Random.Range(-10F,10F),
			transform.position.y,-4),Quaternion.Euler(new Vector3(90,180,0)));  
		StartCoroutine("Spawn");
	}

}
