using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Skill {
	public int skillNo;
	public float coolTime { get; internal set; }
	public float lastUsedTime { get; internal set; }
	
	public Skill() {
		//TODO : Initialize with server data
		this.skillNo = 0;
		this.coolTime = 1.0f;
		this.lastUsedTime = 0.0f;
	}

	public void Update(Skill skill) {
		// skillNo should be same
		this.skillNo = skill.skillNo;
		this.coolTime = skill.coolTime;
		this.lastUsedTime = skill.lastUsedTime;
	}

	public bool UseSkill() {
		if(lastUsedTime + coolTime <= Time.time) {
			lastUsedTime = Time.time;
			return true;
		}
		return false;
	}
}