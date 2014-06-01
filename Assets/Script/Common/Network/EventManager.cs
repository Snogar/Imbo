using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Enums;

public class EventManager {
	private static  EventManager instance_ = new EventManager();
	public  static  EventManager instance {
		get { return instance_; }
	}

	private List<MoveEvent> moveEventList = new List<MoveEvent>();
	private List<UseSkillEvent> useSkillEventList = new List<UseSkillEvent>();

	public void ClearEvents() {
		moveEventList = new List<MoveEvent>();
		useSkillEventList = new List<UseSkillEvent>();
	}

	public void AddMoveEvent(Direction direction) {
		moveEventList.Add(new MoveEvent(direction));
	}

	public void AddUseSkillEvent(int useSkillNumber) {
		useSkillEventList.Add (new UseSkillEvent(useSkillNumber));
	}

	public Direction GetMoveEvent() {
		if(moveEventList.Count == 0) return Direction.NONE;
		return moveEventList[moveEventList.Count - 1].direction;
	}

	public List<int> GetSkillEvent() {
		List<int> skillUsedList = new List<int>();
		for(int i = 0; i < useSkillEventList.Count; i++) {
			skillUsedList.Add (useSkillEventList[i].useSkillNumber);
		}
		return skillUsedList;
	}
}
