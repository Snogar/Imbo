using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StaticManager : MonoBehaviour {
	private static StaticManager instance_ = null;
	public static StaticManager instance {
		get {
			if(instance_ == null) instance_ = GameObject.Find("StaticManager").GetComponent<StaticManager>();          
			return instance_;
		}
	}
	
	void Start () {
		DontDestroyOnLoad(gameObject);
	}
}
