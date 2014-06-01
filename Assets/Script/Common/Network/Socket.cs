using UnityEngine;
using System;
using System.Collections;
using SocketIOClient;
using Enums;

public class Socket {
	private static  Socket instance_ = new Socket();
	public  static  Socket instance {
		get { return instance_; }
	}

	private Client client;

	public void Connect() {
		this.client = new Client(Defines.SERVER_DOMAIN);

		this.client.Opened += SocketOpened;
		this.client.Message += SocketMessage;
		this.client.SocketConnectionClosed += SocketConnectionClosed;
		this.client.Error += SocketError;

		this.client.Connect (); //Maybe ConnectAsync or something?
	}

	public void OnDestroy() {
		if(this.client.IsConnected) {
			Logger.Log ("Socket", "Socket Close OnDestroy", LogColor.BLUE);
			this.client.Close();
		}
	}


	public bool IsConnected() {
		return this.client.IsConnected;
	}

	public void Emit(string uri, object data) {
		this.client.Emit (uri, data);
		Logger.Log ("Socket", "Emit", LogColor.BLUE);
		Logger.LogObject ("Socket", data, LogColor.BLUE);
	}



	private void SocketOpened (object sender, EventArgs e) {
		Logger.Log ("Socket", "Socket Opened", LogColor.BLUE);
	}

	private void SocketMessage (object sender, MessageEventArgs e) { 
		if(e != null) {
			Logger.LogObject("Socket", e.Message.Json, LogColor.YELLOW);
		}
	}

	private void SocketConnectionClosed (object sender, EventArgs e) {
		Logger.Log ("Socket", "Socket Connection Closed", LogColor.RED);
		Logger.LogObject("Socket", e, LogColor.RED);
	}

	private void SocketError (object sender, EventArgs e) {
		Logger.Log ("Socket", "Socket Error", LogColor.RED);
		Logger.LogObject("Socket", e, LogColor.RED);
	}
}
