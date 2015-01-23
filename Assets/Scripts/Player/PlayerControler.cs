using UnityEngine;
using System.Collections;


namespace PlatformEngine
{
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
	

		private void Awake()
		{
			groundCheck = transform.Find("GroundCheck");
		}
		
		// Update is called once per frame
		void FixedUpdate()
		{
			grounded = Physics2D.OverlapCircle(groundCheck.position, groundedRadius, whatIsGround);
			
			Debug.DrawLine(groundCheck.position, groundCheck.position - new Vector3(groundedRadius, 0, 0), Color.red);
			Debug.DrawLine(groundCheck.position, groundCheck.position + new Vector3(groundedRadius, 0, 0), Color.red);
			Debug.DrawLine(groundCheck.position, groundCheck.position - new Vector3(0, groundedRadius, 0), Color.red);
			Debug.DrawLine(groundCheck.position, groundCheck.position + new Vector3(0, groundedRadius, 0), Color.red);
			
			PlayerAnimation.UpdateGround(grounded);
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

	}
}