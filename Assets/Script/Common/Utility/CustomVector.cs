using UnityEngine;
using System.Collections;

public class CustomVector2 {
	public float x { get; set; }
	public float y { get; set; }

	public static CustomVector2 operator+ (CustomVector2 a, CustomVector2 b) {
		return new CustomVector2(a.x + b.x, a.y + b.y);
	}

	public static CustomVector2 operator* (CustomVector2 a, float b) {
		return new CustomVector2(a.x * b, a.y * b);
	}

	public static CustomVector2 zero = new CustomVector2(0, 0);
	public static CustomVector2 left = new CustomVector2(-1, 0);
	public static CustomVector2 right = new CustomVector2(1, 0);
	public static CustomVector2 up = new CustomVector2(0, 1);
	public static CustomVector2 down = new CustomVector2(0, -1);



	public CustomVector2(float x, float y) {
		this.x = x;
		this.y = y;
	}

	public CustomVector2(Vector2 vector) {
		this.x = vector.x;
		this.y = vector.y;
	}



	public Vector2 ToVector2() {
		return new Vector2(x, y);
	}
}
