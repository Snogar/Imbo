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
		Me.instance.Initialize(); //TO BE MOVED -> Login
		UserManager.instance.Initialize(); //TO BE MOVED -> Login, Currently doing nothing
	}

	void Update () {
		float moveFactor = Time.deltaTime * Me.instance.mvSpeed;
		if(Input.GetKey(KeyCode.LeftArrow)) {
			Me.instance.Move(CustomVector2.left * moveFactor);
		}
		if(Input.GetKey(KeyCode.RightArrow)) {
			Me.instance.Move(CustomVector2.right * moveFactor);
		}
		if(Input.GetKey(KeyCode.UpArrow)) {
			Me.instance.Move(CustomVector2.up * moveFactor);
		}
		if(Input.GetKey(KeyCode.DownArrow)) {
			Me.instance.Move(CustomVector2.down * moveFactor);
		}
		if(Input.GetKey (KeyCode.Q)) {
			Me.instance.UseSkill(0);
		}
		NetworkManager.instance.UpdateStatus((UserData)Me.instance);
	}
}
