using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	//定义子弹的移动速度
	public float MoveSpeed=10F;
	//定义子弹的销毁时间
	public float DestroyTime=2.0F;
	//定义子弹对敌人的伤害值
	public int Damage=20;

	void Start()
	{
	}
	void Update () 
	{
		//移动子弹
		transform.Translate(Vector3.up * MoveSpeed * Time.deltaTime);
	}

	//碰撞事件捕捉
	void OnTriggerEnter(Collider mCollider)
	{
		if(mCollider.gameObject.tag=="Enemy")
		{
			Destroy(this.gameObject);
		}
	}

	//当离开摄像机范围时触发销毁事件
	void OnBecameInvisible()
	{
		Destroy(this.gameObject);
	}
}
