using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Util {
	public static GameObject CloneGameObject(string clonePath, string parentPath) {
		GameObject gameObject = GameObject.Instantiate(Resources.Load(clonePath)) as GameObject;
		Vector3 origPosition = gameObject.transform.localPosition;
		Vector3 origScale = gameObject.transform.localScale;
		gameObject.transform.parent = GameObject.Find (parentPath).transform;
		gameObject.transform.localScale = origScale;
		gameObject.transform.localPosition = origPosition;

		return gameObject;
	}

	public static GameObject CloneGameObject(string clonePath, string parentPath, Vector3 position) {
		GameObject gameObject = CloneGameObject(clonePath, parentPath);
		gameObject.transform.localPosition = new Vector3(position.x, position.y, gameObject.transform.localPosition.z);

		return gameObject;
	}
}