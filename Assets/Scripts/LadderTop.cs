using UnityEngine;
using System.Collections;

namespace PlatformEngine
{
	public class LadderTop : MonoBehaviour
	{

		void OnTriggerEnter2D(Collider2D collider)
		{
			gameObject.layer = LayerMask.NameToLayer("Platform");
		}

		void OnTriggerExit2D(Collider2D collider)
		{
			gameObject.layer = LayerMask.NameToLayer("Ladder");
		}
	}
}