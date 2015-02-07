using UnityEngine;
using System.Collections;

namespace platformEngine
{
	public class Win : MonoBehaviour
	{

		void OnTriggerEnter2D(Collider2D collider)
		{
			if (collider.tag == "Player")
				Application.LoadLevel((Application.loadedLevel + 1)%Application.levelCount);
		}

	}
}