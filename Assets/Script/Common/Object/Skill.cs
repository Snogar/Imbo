using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Skill {
	public float coolTime { get; internal set; }
	public float lastUsedTime { get; internal set; }
	
	public Skill() {
		this.coolTime = 1.0f;
		this.lastUsedTime = 0.0f;
	}

	public bool UseSkill() {
		if(lastUsedTime + coolTime <= Time.time) {
			lastUsedTime = Time.time;
			return true;
		}
		return false;
	}
}