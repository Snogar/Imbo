using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Enums;

public class NetworkManager : MonoBehaviour {
	private static  NetworkManager instance_ = null;
	public  static  NetworkManager instance {
		get { 
			if(instance_ == null) instance_ = GameObject.Find("StaticManager").GetComponent<NetworkManager>();          
			return instance_; 
		}
	}

	private float lastUpdateTime;
	private List<SendPacket> sendPacketList = new List<SendPacket>();

	private void Awake() {
		Socket.instance.Connect ();
	}

	private void OnDestroy() {
		Socket.instance.OnDestroy();
	}

	public void Update() {
		if(lastUpdateTime + Defines.SERVER_SEND_INTERVAL <= Time.time) {
			lastUpdateTime = Time.time;

			Direction moveDirection = EventManager.instance.GetMoveEvent();
			if(moveDirection != Direction.NONE) {
				AddMovePacket(moveDirection);
			}
			List<int> useSkillList = EventManager.instance.GetSkillEvent();
			for(int i = 0; i < useSkillList.Count; i++) {
				AddUseSkillPacket(useSkillList[i]);
			}

			if(sendPacketList.Count > 0) {
				Socket.instance.Emit (ServerAPI.URI_CHARACTER_MOVE, sendPacketList);
			}

			sendPacketList.Clear ();
			EventManager.instance.ClearEvents();
		}
	}
	
	public void AddMovePacket(Direction direction) {
		MoveSendPacket packet = new MoveSendPacket();
		packet.api = ServerAPI.API_MOVE;
		packet.direction = (int)direction;

		sendPacketList.Add (packet);
	}

	public void AddUseSkillPacket(int useSkillNumber) {
		UseSkillSendPacket packet = new UseSkillSendPacket();
		packet.api = ServerAPI.API_USE_SKILL;
		packet.use_skill_number = useSkillNumber;

		sendPacketList.Add (packet);
	}
}