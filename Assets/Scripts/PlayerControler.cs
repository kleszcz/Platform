using UnityEngine;
using System.Collections;


namespace PlatformEngine
{
	public class PlayerControler : MonoBehaviour, IClimb
	{

		[SerializeField] 
		private float maxSpeed = 10f;
		[SerializeField] 
		private float jumpForce = 400f;
		[SerializeField] 
		private LayerMask whatIsGround;
		[SerializeField]
		private LayerMask whatIsLadder;
		[SerializeField] 
		private bool airControl;

		private bool climbing = false;

		public bool Climbing
		{
			get { return climbing; }
		}
		private bool climbTop = false;

		public bool ClimbTop
		{
			get { return climbTop; }
		}
		
		private Transform groundCheck;
		private float groundedRadius = .2f;
		[SerializeField]
		private bool grounded = false;

		private Transform bodyCheck;
		private float bodyRadius = .1f;
		[SerializeField]
		private Collider2D platform;
		private bool onPlatform;
		private Vector3 platformLastPos;

		private void Awake()
		{
			groundCheck = transform.Find("GroundCheck");
			bodyCheck = transform.Find("BodyCheck");
		}
		
		// Update is called once per frame
		void FixedUpdate()
		{
			grounded = Physics2D.OverlapCircle(groundCheck.position, groundedRadius, whatIsGround);
			climbTop = !Physics2D.OverlapCircle(bodyCheck.position, bodyRadius, whatIsLadder) && Physics2D.OverlapCircle(groundCheck.position, groundedRadius, whatIsLadder);
			PlayerAnimation.UpdateGround(grounded);
			platform = Physics2D.OverlapCircle(groundCheck.position, groundedRadius, 1 << LayerMask.NameToLayer("Platform"));
			if (platform)
			{
				Debug.Log("On platform");
				if (!onPlatform)
				{
					platformLastPos = platform.transform.position;
					Debug.Log("Platform pos = " + platformLastPos);
					onPlatform = true;
				}
			}
			else
			{
				onPlatform = false;
			}
		}

		void LateUpdate()
		{
			if (onPlatform)
			{				
				Debug.Log("Player pos = " + transform.position );
				Vector3 delta = platform.transform.position - platformLastPos;
				Debug.Log("Delta = " + delta);
				transform.Translate(delta);
				Debug.Log("New player pos = " + transform.position);
			}
		}

		
		public void Move(float moveHorizontal, float moveVertical, bool jump)
		{
			if (grounded || airControl || climbing)
			{
				PlayerAnimation.UpdateSpeed(Mathf.Abs(moveHorizontal));
				rigidbody2D.velocity = new Vector2(maxSpeed * moveHorizontal, climbing ? maxSpeed * moveVertical : rigidbody2D.velocity.y);
			}
			if ((grounded || climbTop) && jump)
			{
				rigidbody2D.isKinematic = false;
				grounded = false;
				rigidbody2D.AddForce(new Vector2(0f, jumpForce));
			}
		}

		// IClimb section
		public void StartClimb()
		{
			climbing = true;
			rigidbody2D.velocity = Vector2.zero;
		}

		public void Climb()
		{
			rigidbody2D.isKinematic = !grounded;
			PlayerAnimation.UpdateLadder(!grounded);
		}

		public void EndClimb()
		{
			climbing = false;
			rigidbody2D.isKinematic = false;
		//	rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0);
			PlayerAnimation.UpdateLadder(false);
		}

	}
}