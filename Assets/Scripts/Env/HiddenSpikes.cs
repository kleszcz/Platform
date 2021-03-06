﻿using UnityEngine;
using System.Collections;

namespace PlatformEngine
{
	public class HiddenSpikes : MonoBehaviour
	{
		[SerializeField]
		private Animator anim;

		void Awake()
		{

			anim = transform.FindChild("spikes_sprites").GetComponent<Animator>();
		}

		void OnTriggerEnter2D(Collider2D collider)
		{
			anim.SetBool("Show", true);
		}

		void OnTriggerExit2D(Collider2D collider)
		{
			anim.SetBool("Show", false);
		}
	}
}