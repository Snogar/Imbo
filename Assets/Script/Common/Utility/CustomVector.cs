using UnityEngine;
using System.Collections;

public class CVector2 {
	public float x { get; set; }
	public float y { get; set; }

	public static CVector2 operator+ (CVector2 a, CVector2 b) {
		return new CVector2(a.x + b.x, a.y + b.y);
	}

	public static CVector2 operator* (CVector2 a, float b) {
		return new CVector2(a.x * b, a.y * b);
	}

	public static CVector2 zero = new CVector2(0, 0);
	public static CVector2 left = new CVector2(-1, 0);
	public static CVector2 right = new CVector2(1, 0);
	public static CVector2 up = new CVector2(0, 1);
	public static CVector2 down = new CVector2(0, -1);



	public CVector2(float x, float y) {
		this.x = x;
		this.y = y;
	}

	public CVector2(Vector2 vector) {
		this.x = vector.x;
		this.y = vector.y;
	}



	public Vector2 ToVector2() {
		return new Vector2(x, y);
	}
}
