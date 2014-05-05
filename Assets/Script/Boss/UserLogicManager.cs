using UnityEngine;
using System.Collections;

public class UserLogicManager : MonoBehaviour {
	private static  UserLogicManager instance_   = null;
	public  static  UserLogicManager instance {
		get {
			if(instance_ == null) instance_ = GameObject.Find("Manager").GetComponent<UserLogicManager>();
			return instance_;
		}
	}

	void Start () {
		Socket.instance.Initialize(); //TO BE MOVED -> At the beginning

		UserManager.instance.Initialize(); //TO BE MOVED -> Login
		UserUIManager.instance.RefreshPosition();
	}

	void OnDestroy() {
		Socket.instance.Destroy(); //TO BE MOVED -> ..TO WHERE??
	}

	void Update () {
		float moveFactor = Time.deltaTime * Defines.MOVEMENT_SPEED;
		if(Input.GetKey(KeyCode.LeftArrow)) {
			UserManager.instance.Move(Vector3.left * moveFactor);
		}
		if(Input.GetKey(KeyCode.RightArrow)) {
			UserManager.instance.Move(Vector3.right * moveFactor);
		}
		if(Input.GetKey(KeyCode.UpArrow)) {
			UserManager.instance.Move(Vector3.up * moveFactor);
		}
		if(Input.GetKey(KeyCode.DownArrow)) {
			UserManager.instance.Move(Vector3.down * moveFactor);
		}

	}
}
