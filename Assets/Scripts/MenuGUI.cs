using UnityEngine;
using System.Collections;

public class MenuGUI : MonoBehaviour {

	void OnGUI()
	{
		if (GUILayout.Button("Start"))
		{
			Application.LoadLevel((Application.loadedLevel + 1) % Application.levelCount);
		}
		if (GUILayout.Button("Close"))
		{
			Application.Quit();
		}
	}
}
