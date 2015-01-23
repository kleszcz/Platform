using UnityEngine;
using System.Collections;


namespace PlatformEngine
{
	[RequireComponent(typeof(PlayerControler))]
	public class PlayerInputControler : MonoBehaviour
	{
		private PlayerControler player;
		// Use this for initialization
		void Start()
		{
			player = transform.GetComponent<PlayerControler>();
		}

		// Update is called once per frame
		void FixedUpdate()
		{
			//Input
			float h = 0f;
			float v = 0f;
			h = Input.GetAxis("Horizontal");

			if (player.Climbing)
			{
				v = Input.GetAxis("Vertical");
				if (player.ClimbTop && v > 0)
					v = 0;
			}
		
			bool jump = Input.GetButton("Jump");
			player.Move(h, v, jump);
		}
	}
}