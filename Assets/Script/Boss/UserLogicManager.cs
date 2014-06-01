using UnityEngine;
using System.Collections;
using Enums;

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
		bool keyLeft = Input.GetKey(KeyCode.LeftArrow);
		bool keyRight = Input.GetKey(KeyCode.RightArrow);
		bool keyUp = Input.GetKey(KeyCode.UpArrow);
		bool keyDown = Input.GetKey(KeyCode.DownArrow);

		Direction direction = Direction.NONE;
		if(keyLeft) {
			if(keyUp) direction = Direction.LU;
			else if(keyDown) direction = Direction.LD;
			else if(keyRight) direction = Direction.NONE;
			else direction = Direction.L;
		}
		else if(keyRight) {
			if(keyUp) direction = Direction.RU;
			else if(keyDown) direction = Direction.RD;
			else direction = Direction.R;
		}
		else if(keyDown) {
			if(keyUp) direction = Direction.NONE;
			else direction = Direction.D;
		}
		else if(keyUp) direction = Direction.U;

		EventManager.instance.AddMoveEvent(direction);

		if(Input.GetKey (KeyCode.Q)) {
			Me.instance.UseSkill(0);
		}
	}
}
