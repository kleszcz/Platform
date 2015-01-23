using UnityEngine;
using System.Collections;

public class MenuGUI : MonoBehaviour {

	void OnGUI()
	{
		if (GUILayout.Button("Start"))
		{
			Application.LoadLevel("level");
		}
		if (GUILayout.Button("Close"))
		{
			Application.Quit();
		}
	}
}
