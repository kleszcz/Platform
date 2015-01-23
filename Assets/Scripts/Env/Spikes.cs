using UnityEngine;
using System.Collections;

namespace PlatformEngine
{
	public class Spikes : MonoBehaviour
	{
		void OnTriggerEnter2D(Collider2D collider)
		{
			if (collider.tag == "Player")
			{
				Debug.LogWarning("DEAD!");
				Application.LoadLevel("Menu");
			}
		}
	}
}