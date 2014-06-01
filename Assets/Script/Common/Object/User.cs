using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UserData {
	//UserData that send&receive via socket
	public int hp { get; internal set; }
	public int mp { get; internal set; }
	public CVector2 position { get; internal set; }
	public float mvSpeed { get; internal set; }
	public List<Skill> skillList { get; internal set; }

	public void UpdateData(UserData userData) {
		this.hp = userData.hp;
		this.mp = userData.mp;
		this.position = userData.position;
		this.mvSpeed = userData.mvSpeed;
		if(userData.skillList != null) this.skillList = userData.skillList;
	}

	public virtual void UpdatePosition(CVector2 position) {
		this.position = position;
	}
}


public class User : UserData {
	protected UISprite sprite;


	//Functions
	public virtual void Initialize() { 
		//TO BE INITALIZED
		GameObject gameObject = Util.CloneGameObject(PathSettings.RESOURCE_USER, PathSettings.SCENE_BOSS_USER_PANEL);
		this.sprite = gameObject.GetComponent<UISprite>();
		this.sprite.gameObject.name = "User";

		//
		// TEST DATA
		//
		UserData testUserInitialData = new UserData();
		testUserInitialData.position = CVector2.zero;
		testUserInitialData.hp = 100;
		testUserInitialData.mp = 100;
		testUserInitialData.mvSpeed = 200.0f;
		testUserInitialData.skillList = new List<Skill>();
		testUserInitialData.skillList.Add (new Skill());

		this.UpdateData(testUserInitialData);
		//
		//
		//
	}

	public override void UpdatePosition(CVector2 position) {
		base.UpdatePosition(position);
		this.sprite.transform.localPosition = new Vector3(position.x, position.y, this.sprite.transform.localPosition.z);
	}

	public void UseSkill(int skillNumber) {
		Logger.Log ("DEBUG", skillNumber + "");
		Logger.Log ("DEBUG", skillList.Count + "");
		Skill usedSkill = skillList[skillNumber];
		if(usedSkill.UseSkill()) {
			Logger.Log ("DEBUG", "USED SKILL");
			EventManager.instance.AddUseSkillEvent(0);
//			GameObject gameObject = Util.CloneGameObject(PathSettings.RESOURCE_USER_SKILL, PathSettings.SCENE_BOSS_SKILL_PANEL, this.sprite.transform.localPosition);
//			IngameUIManager.instance.WaitAndDestroySpriteAnimation(gameObject.GetComponent<UISpriteAnimation>());
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
