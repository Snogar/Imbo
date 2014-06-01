using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Enums;

public class CEvent {
}

public class MoveEvent : CEvent {
	public Direction direction;

	public MoveEvent(Direction direction) {
		this.direction = direction;
	}
}

public class UseSkillEvent : CEvent {
	public int useSkillNumber;

	public UseSkillEvent(int useSkillNumber) {
		this.useSkillNumber = useSkillNumber;
	}
}