using UnityEngine;
using System.Collections;

public class Winzone : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider)
	{
		Debug.Log("WIN");
		Application.LoadLevel(Application.loadedLevel);
	}
}
