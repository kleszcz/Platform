using UnityEngine;
using System.Collections;

public class MenuGem : MonoBehaviour {

	public int level;
	void OnMouseEnter()
	{
		GetComponent<Animator>().SetBool("Over", true);
	}

	void OnMouseExit()
	{
		GetComponent<Animator>().SetBool("Over", false);
	}

	void OnMouseDown()
	{
		Application.LoadLevel(level);
	}
}
