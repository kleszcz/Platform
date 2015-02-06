using UnityEngine;
using System.Collections;

namespace PlatformEngine.Platforms
{
	public class MovingPlatformActivator : MonoBehaviour
	{

		public PlatformMove target;

		void OnTriggerEnter2D(Collider2D collider)
		{
			if(target != null && collider.tag == "Player")
			target.IsEnable = true;
		}
	}
}