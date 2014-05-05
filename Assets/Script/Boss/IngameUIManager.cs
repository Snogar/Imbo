using UnityEngine;
using System.Collections;

public class IngameUIManager : MonoBehaviour {
	private static  IngameUIManager instance_   = null;
	public  static  IngameUIManager instance {
		get {
			if(instance_ == null) instance_ = GameObject.Find("Manager").GetComponent<IngameUIManager>();
			return instance_;
		}
	}
	
	void Start () {
	}
	
	void Update () {
	}

	public void WaitAndDestroySpriteAnimation(UISpriteAnimation animation) {
		StartCoroutine(WaitAndDestroySpriteAnimationCoroutine(animation));
	}

	private IEnumerator WaitAndDestroySpriteAnimationCoroutine(UISpriteAnimation animation) {
		while(animation.isPlaying) {
			yield return null;
		}

		GameObject.Destroy(animation.gameObject);
	}
}
