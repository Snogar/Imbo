using UnityEngine;
using System.Collections;

public class UserUIManager : MonoBehaviour {
	private static  UserUIManager instance_   = null;
	public  static  UserUIManager instance {
		get {
			if(instance_ == null) instance_ = GameObject.Find("Manager").GetComponent<UserUIManager>();
			return instance_;
		}
	}
	
	private UISprite userSprite;



	void Start () {
		this.userSprite = GameObject.Find("UserSprite").GetComponent<UISprite>();
	}

	void Update () {
	
	}

	public void RefreshPosition() {
		this.userSprite.transform.localPosition = UserManager.instance.Position;
	}	
}
