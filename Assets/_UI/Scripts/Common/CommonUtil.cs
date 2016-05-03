using UnityEngine;
using System;

public class CommonUtil  {

	public static string GetString(string key,string defaultValue){
		string value = PlayerPrefs.GetString ( key , defaultValue);
		return value;
	}

	public static void SetString(string key,string value){
		PlayerPrefs.SetString (key,value);
		PlayerPrefs.Save ();
	}

	public static float GetFloat(string key,float defaultValue){
		return Convert.ToSingle (GetString (key, defaultValue.ToString()));
	}

	public static void SetFloat (string key,float value){
		SetString (key, value.ToString());
	}

	public static int GetInt(string key,int defaultValue){
		return Convert.ToInt32(GetString (key, defaultValue.ToString()));
	}

	public static void SetInt (string key,int value){
		SetString (key, value.ToString());
	}

	public static bool GetBool(string key,bool defaultValue){
		string value = GetString (key, (defaultValue ? 1 : 0).ToString ());
		return Convert.ToBoolean(Convert.ToInt32(value));
	}

	public static void SetBool (string key,bool value){
		SetString (key, (value ? 1 : 0).ToString ());
	}

	public static bool HasKey(string key){
		return PlayerPrefs.HasKey (key);
	}

	public static void DeleteKey(string key){
		PlayerPrefs.DeleteKey (key);
	}
}
