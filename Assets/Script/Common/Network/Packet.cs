using UnityEngine;
using System.Collections;

//-----------------------------

public class Packet {
	public string api;
}

//-----------------------------

public class SendPacket : Packet {
}

public class RecvPacket : Packet {
	public static RecvPacket Deserialize(string recvPacketString) {
		RecvPacket recvPacket = Newtonsoft.Json.JsonConvert.DeserializeObject<RecvPacket>(recvPacketString);

		switch(recvPacket.api) {
		case ServerAPI.API_MOVE:
			recvPacket = Newtonsoft.Json.JsonConvert.DeserializeObject<MoveRecvPacket>(recvPacketString);
			break;
		case ServerAPI.API_USE_SKILL:
			recvPacket = Newtonsoft.Json.JsonConvert.DeserializeObject<UseSkillRecvPacket>(recvPacketString);
			break;
		default:
			recvPacket = null;
			break;
		}
		return recvPacket;
	}
}


//-----------------------------

public class MoveSendPacket : SendPacket {
	public int direction;
}

public class UseSkillSendPacket : SendPacket {
	public int use_skill_number;
}

//-----------------------------

public class MoveRecvPacket : RecvPacket {
}

public class UseSkillRecvPacket : RecvPacket {
}
