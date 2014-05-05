using UnityEngine;
using System.Collections;

public class UserManager {
	private static  UserManager instance_ = new UserManager();
	public  static  UserManager instance {
		get { return instance_; }
	}

	private int hp, mp;
	private Vector3 position;


	public Vector3 Position {
		get { return position; }
	}


	public void Initialize() {
		this.hp = 100;
		this.mp = 100;
		this.position = Vector3.zero;
	}

	public void Move(Vector3 moveVector) {
		this.position += moveVector;
	}
}
