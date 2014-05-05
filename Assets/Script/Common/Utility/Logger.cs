using UnityEngine;
using System.Text;
using System.Collections;

public enum LogColor {
	NONE,
	RED,
	BLUE,
	GREEN,
	YELLOW
}

public class Logger {
	private const bool DEBUG_MODE = true;
	
	public static void Log(string tag, string log, LogColor color = LogColor.NONE) {
		if(DEBUG_MODE) {
			switch(color) {
			case LogColor.NONE:
				break;
			case LogColor.RED:
				log = "<color=red>" + log + "</color>";
				break;
			case LogColor.BLUE:
				log = "<color=aqua>" + log + "</color>";
				break;
			case LogColor.GREEN:
				log = "<color=green>" + log + "</color>";
				break;
			case LogColor.YELLOW:
				log = "<color=yellow>" + log + "</color>";
				break;
			}
			Debug.Log ("[" + tag + "] " + log);
		}
	}

	public static void LogObject(string tag, object obj, LogColor color = LogColor.NONE) {
		Log(tag, Newtonsoft.Json.JsonConvert.SerializeObject(obj), color);
	}
}