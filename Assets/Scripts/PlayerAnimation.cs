using UnityEngine;
using System.Collections;
namespace PlatformEngine
{
	[RequireComponent(typeof(Animator))]
	public class PlayerAnimation : MonoBehaviour
	{
		private static Animator anim;

		void Awake()
		{
			anim = transform.GetComponent<Animator>();
		}

		public static void UpdateSpeed(float speed)
		{
			if (anim == null)
				return;
			anim.SetFloat("Speed", speed);
		}

		public static void UpdateGround(bool ground)
		{
			if (anim == null)
				return;
			anim.SetBool("Ground", ground);
		}

		public static void UpdateLadder(bool ladder)
		{
			if (anim == null)
				return;
			anim.SetBool("Ladder", ladder);
		}

	}
}