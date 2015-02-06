using UnityEngine;
using System.Collections;


namespace PlatformEngine
{
	[ExecuteInEditMode]
	public class PlayerControler : MonoBehaviour
	{

		[SerializeField] 
		private float maxSpeed = 10f;
		[SerializeField] 
		private float jumpForce = 400f;
		[SerializeField] 
		private LayerMask whatIsGround;
		[SerializeField] 
		private bool airControl;
						
		private Transform groundCheck;
		[SerializeField]
		private float groundedRadius = .2f;
		[SerializeField]
		private bool grounded = false;
		private bool onMovingPlatform = false;
		private Collider2D movingPlatform = null;
		private Vector3 movingPlatformLastPosition;

		private void Awake()
		{
			groundCheck = transform.Find("GroundCheck");
		}
		
		// Update is called once per frame
		void FixedUpdate()
		{
			grounded = Physics2D.OverlapCircle(groundCheck.position, groundedRadius, whatIsGround);
			movingPlatform = Physics2D.OverlapCircle(groundCheck.position, groundedRadius, 1 << LayerMask.NameToLayer("MovingPlatform"));
			if (movingPlatform != null)
			{
				onMovingPlatform = true;
				movingPlatformLastPosition = movingPlatform.transform.position;
			}
			else
				onMovingPlatform = false;

			PlayerAnimation.UpdateGround(grounded);
			Collider2D enemy = Physics2D.OverlapCircle(groundCheck.position, groundedRadius, 1 << LayerMask.NameToLayer("Enemy"));
			if(enemy != null && enemy.tag == "Enemy")
				enemy.gameObject.SetActive(false); // todo fix it for respawn	

		}

		void LateUpdate()
		{
			if (onMovingPlatform)
			{
				Vector3 diff = movingPlatform.transform.position - movingPlatformLastPosition;
				diff.z = 0f;
				transform.position = transform.position + diff;
				movingPlatformLastPosition = movingPlatform.transform.position;
			}
		}
		
		public void Move(float moveHorizontal, bool jump)
		{
			if (grounded || airControl)
			{
				PlayerAnimation.UpdateSpeed(Mathf.Abs(moveHorizontal));
				rigidbody2D.velocity = new Vector2(maxSpeed * moveHorizontal, rigidbody2D.velocity.y);
			}
			if (grounded && jump)
			{				
				grounded = false;
				rigidbody2D.AddForce(new Vector2(0f, jumpForce));
			}
		}

		void OnDrawGizmos()
		{
			if (groundCheck != null)
			{
				Gizmos.color = Color.red;
				Gizmos.DrawWireSphere(groundCheck.position, groundedRadius);
			}
		}

	}
}