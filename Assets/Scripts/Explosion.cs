using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	//动画序列索引
	private int index=0;
	//声音
	private AudioSource mAudio;

	void Start()
	{
		mAudio=GetComponent<AudioSource>();
	}

	void FixedUpdate () 
	{
		if(index<8)
		{
			this.GetComponent<Renderer>().sharedMaterial.mainTextureScale=new Vector2(1.0F/8,1);
			this.GetComponent<Renderer>().sharedMaterial.mainTextureOffset=new Vector2(index * 1.0F/8,0);
			index+=1;
		}else
		{
			mAudio.Play();
			Destroy(this.gameObject);
		}
	}
}
