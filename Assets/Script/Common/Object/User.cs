using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UserData {
	//UserData that send&receive via socket
	public int hp { get; internal set; }
	public int mp { get; internal set; }
	public CustomVector2 position { get; internal set; }
	public float mvSpeed { get; internal set; }
	public List<Skill> skillList { get; internal set; }
}


public class User : UserData {
	protected UISprite sprite;


	//Functions
	public virtual void Initialize() { 
		//TO BE INITALIZED
		GameObject gameObject = Util.CloneGameObject(PathSettings.RESOURCE_USER, PathSettings.SCENE_BOSS_USER_PANEL);
		this.sprite = gameObject.GetComponent<UISprite>();
		this.sprite.gameObject.name = "User";

		this.SetPosition(CustomVector2.zero);
		this.hp = 100; 
		this.mp = 100;
		this.mvSpeed = 200.0f;
		this.skillList = new List<Skill>();
		this.skillList.Add(new Skill());
	}

	public void SetPosition(CustomVector2 position) {
		this.position = position;
		this.sprite.transform.localPosition = new Vector3(position.x, position.y, this.sprite.transform.localPosition.z);
	}

	public void Move(CustomVector2 moveVector) {
		this.SetPosition (this.position + moveVector);
	}

	public void UseSkill(int skillNumber) {
		Skill usedSkill = skillList[skillNumber];
		if(usedSkill.UseSkill()) {
			GameObject gameObject = Util.CloneGameObject(PathSettings.RESOURCE_USER_SKILL, PathSettings.SCENE_BOSS_SKILL_PANEL, this.sprite.transform.localPosition);
			IngameUIManager.instance.WaitAndDestroySpriteAnimation(gameObject.GetComponent<UISpriteAnimation>());
		}
	}
}


public class Me : User {
	private static  Me instance_ = new Me();
	public  static  Me instance {
		get { return instance_; }
	}

	public override void Initialize() {
		base.Initialize();
		this.sprite.gameObject.name = "Me";
	}
}
