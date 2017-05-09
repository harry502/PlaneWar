using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	//飞机的移动速度
	public float MoveSpeed;
	//定义子弹对象
	public GameObject Bullet;
	//爆炸
	public GameObject Explosion;
	//子弹CD
	public double BulletCD;
	//防护罩CD
	public float GuardCD;
	//防护罩持续时间
	public float GuardTime;
	//防护罩状态
	public bool IsGuard = false;
	//防护罩
	private GameObject Guard;

	void Start() 
	{
		Guard = GameObject.Find ("Guard");
		Guard.SetActive(false);
	}

	void Update()
	{
		if(Input.GetKey(KeyCode.A))
		{
			transform.Translate(Vector3.right*Time.deltaTime* MoveSpeed);
		}
		if(Input.GetKey(KeyCode.D))
		{
			transform.Translate(Vector3.left*Time.deltaTime* MoveSpeed );
		}
		if(Input.GetKey(KeyCode.W))
		{
			transform.Translate(Vector3.back*Time.deltaTime* MoveSpeed);
		}
		if(Input.GetKey(KeyCode.S))
		{
			transform.Translate(Vector3.forward*Time.deltaTime* MoveSpeed);
		}
		//按下空格键，发射子弹
		BulletCD -= Time.deltaTime;
		if (BulletCD <= 0)
		{
			BulletCD = 0.1f;
			if (Input.GetKey (KeyCode.Space)) {
				Instantiate (Bullet, this.transform.position, Quaternion.Euler (new Vector3 (0, 0, 0)));
			}
		}
		//按下J键，开启防护罩
		if(GuardCD>0) 
			GuardCD -= Time.deltaTime;
		else if (GuardCD <= 0 && Input.GetKey (KeyCode.J))
		{
			GuardCD = 30.0f;
			IsGuard = true;
			GuardTime = 5.0f;
			Guard.SetActive (true);
		}

		if (GuardTime > 0)
			GuardTime -= Time.deltaTime;
		else
		{
			IsGuard = false;
			Guard.SetActive (false);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag.CompareTo("Enemy") == 0 && IsGuard == false)
		{
			//产生爆炸效果
			Instantiate(Explosion,transform.position,transform.rotation);
			//销毁
			Destroy(this.gameObject);
		}
	}

	public void Break()
	{
		Instantiate(Explosion,transform.position,Quaternion.Euler(new Vector3(90,180,0)));
		Destroy(this.gameObject);
	}
}
