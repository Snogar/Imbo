using UnityEngine;
using System;
using System.Collections;
using SocketIOClient;

public class Socket {
	private static  Socket instance_ = new Socket();
	public  static  Socket instance {
		get { return instance_; }
	}

	private Client client;

	public void Initialize() {
		this.client = new Client(Defines.SERVER_DOMAIN);

		this.client.Opened += SocketOpened;
		this.client.Message += SocketMessage;
		this.client.SocketConnectionClosed += SocketConnectionClosed;
		this.client.Error += SocketError;

		this.client.Connect (); //Maybe ConnectAsync or something?
	}

	public void Destroy() {
		this.client.Close();
	}



	private void SocketOpened (object sender, EventArgs e) {
		Logger.Log ("Socket", "SocketOpened", LogColor.RED);
		//this.client.Emit("debug/echo", sibural);
	}

	private void SocketMessage (object sender, MessageEventArgs e) { 
		if(e != null) {
			Logger.LogObject("Socket", e.Message.Json, LogColor.YELLOW);
		}
	}

	private void SocketConnectionClosed (object sender, EventArgs e) {
		Logger.Log ("Socket", "SocketConnectionClosed", LogColor.RED);
		Logger.LogObject("Socket", e, LogColor.RED);
	}

	private void SocketError (object sender, EventArgs e) {
		Logger.Log ("Socket", "SocketError", LogColor.RED);
		Logger.LogObject("Socket", e, LogColor.RED);
	}
}
