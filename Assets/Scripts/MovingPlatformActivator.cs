using UnityEngine;
using System.Collections;

namespace PlatformEngine.Platforms
{
	public class MovingPlatformActivator : MonoBehaviour
	{

		public PlatformMove target;
		public string activatorTag = "Player";
		public bool permanent = true;

		void OnTriggerEnter2D(Collider2D collider)
		{
			if(target != null && collider.tag == activatorTag)
			target.IsEnable = true;
		}

		void OnTriggerExit2D(Collider2D collider)
		{
			if(!permanent && target != null && collider.tag == activatorTag)
				target.IsEnable = false;
		}
	}
}