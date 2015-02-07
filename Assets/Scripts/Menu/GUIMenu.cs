﻿using UnityEngine;
using System.Collections;

public class GUIMenu : MonoBehaviour {

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
		Application.LoadLevel(0);
	}
}
