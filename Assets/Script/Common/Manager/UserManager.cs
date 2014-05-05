using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class UserManager {
	private static  UserManager instance_ = new UserManager();
	public  static  UserManager instance {
		get { return instance_; }
	}
	
	private List<User> userList;

	//Getters
	public List<User> UserList {
		get { return userList; }
	}


	//Functions
	public void Initialize() {
	}
}
