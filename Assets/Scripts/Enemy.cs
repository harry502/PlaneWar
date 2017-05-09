using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	//移动速度
	public float MoveSpeed=1.5F;
	//爆炸
	public GameObject Explosion;
	//最大生命值
	public int HP=100;


	void Update () 
	{
		//移动飞机
		transform.Translate(Vector3.forward * Time.deltaTime * MoveSpeed);
	}

	public void Hit(int Value)
	{ 
		//如血量不低于0，则敌人飞机掉血
		if(HP>0)
		{	
			HP-=Value;
		}
		if(HP<=0)
		{
			//产生爆炸效果
			Instantiate(Explosion,transform.position,transform.rotation);
			//销毁敌机
			Destroy(this.gameObject);
			//加分
			GameManager.Instance.Add(1);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag.CompareTo("Player") == 0)
		{
			//敌机爆炸
			this.Hit(100);
		}
		if (other.tag.CompareTo ("Bullet") == 0)
		{
			//扣血
			Bullet bullet = other.GetComponent<Bullet>();
			if (bullet != null)
			{
				this.Hit(bullet.Damage);
			}
		}
	}


	void OnBecameInvisible()
	{
		Destroy(this.gameObject);
	}
}
