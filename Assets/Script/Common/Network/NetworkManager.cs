using UnityEngine;
using System.Collections;

public class NetworkManager {
	private static  NetworkManager instance_ = new NetworkManager();
	public  static  NetworkManager instance {
		get { return instance_; }
	}

	private float lastUpdateTime;


	public void UpdateStatus (UserData data) {
		if(Socket.instance.IsConnected() && lastUpdateTime + Defines.SERVER_SEND_INTERVAL <= Time.time) {
			lastUpdateTime = Time.time;
			Socket.instance.Emit (Defines.URI_CHARACTER_MOVE, data);
		}
	}
}
