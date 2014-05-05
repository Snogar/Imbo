using UnityEngine;
using System.Collections;

public class User {
	protected UISprite sprite; //contains position, scale, rotation, etc.
	protected int hp, mp;
	protected float mvSpeed;
	
	//Getters
	public float MVSpeed {
		get { return mvSpeed; }
	}


	//Functions
	public virtual void Initialize() { 
		//TO BE INITALIZED
		GameObject gameObject = GameObject.Instantiate(Resources.Load(PathSettings.RESOURCE_BOSS_USER)) as GameObject;
		gameObject.transform.parent = GameObject.Find (PathSettings.SCENE_BOSS_USER_PANEL).transform;
		gameObject.name = "User";
		this.sprite = gameObject.GetComponent<UISprite>();
		this.sprite.transform.localScale = Vector3.one;
		this.sprite.transform.localPosition = Vector3.zero;

		this.hp = 100; 
		this.mp = 100;
		this.mvSpeed = 200.0f;
	}
	
	public void Move(Vector3 moveVector) {
		this.sprite.transform.localPosition += moveVector;
	}
}


public class Me : User {
	private static  Me instance_ = new Me();
	public  static  Me instance {
		get { return instance_; }
	}

	public virtual void Initialize() {
		base.Initialize();
		this.sprite.gameObject.name = "Me";
	}
}
