using UnityEngine;
using System.Collections;

public class JumpField : MonoBehaviour {
	public float jumpForce;

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.tag == "Player")
		{
			collision.transform.rigidbody2D.AddForce(Vector2.up * jumpForce);
		}
	}
}
