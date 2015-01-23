using UnityEngine;
using System.Collections;

namespace PlatformEngine
{	
	public class Spikes : MonoBehaviour
	{
		public float damage = 1.0f;

		void OnTriggerEnter2D(Collider2D collider)
		{
			if (collider.tag == "Player")
			{
				PlayerAnimation.UpdateDamage(true);
			}
		}

		void OnTriggerExit2D(Collider2D collider)
		{
			if (collider.tag == "Player")
			{
				PlayerAnimation.UpdateDamage(false);
			}
		}
		void OnTriggerStay2D(Collider2D collider)
		{
			if (collider.tag == "Player")
			{
				PlayerAnimation.UpdateDamage(true);
				Player player = collider.GetComponent<Player>();
				player.DoDamage(damage);
			}
		}
	}
}