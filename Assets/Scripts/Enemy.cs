using UnityEngine;
using System.Collections;
namespace PlatformEngine
{
	public class Enemy : MonoBehaviour
	{

		public float speed = 1.0f;
		public float damage = 1.0f;
		private Transform left;
		private Transform right;
		private Vector3 leftPosition, rightPosition;

		[SerializeField]
		private bool isRight = false;

		private bool startRight = true;
		// Use this for initialization
		void Start()
		{
			left = transform.Find("Left");
			right = transform.Find("Right");

			leftPosition = left.position;
			rightPosition = right.position;
			if (leftPosition.x > rightPosition.x)
			{
				Vector3 tmp = leftPosition;
				leftPosition = rightPosition;
				rightPosition = tmp;
			}

			right.parent = left.parent = transform.parent;

		}

		// Update is called once per frame
		void Update()
		{
			if (isRight)
			{
				transform.Translate(Vector3.right * speed * Time.deltaTime);
				if (transform.position.x >= rightPosition.x)
					Flip();
			}
			else
			{
				transform.Translate(Vector3.left * speed * Time.deltaTime);
				if (transform.position.x <= leftPosition.x)
					Flip();
			}
		}

		void Flip()
		{
			isRight = !isRight;
		}

		void OnCollisionEnter2D(Collision2D collision)
		{
			if (collision.collider.tag == "Player")
			{
				PlayerAnimation.UpdateDamage(true);
				Player player = collision.collider.GetComponent<Player>();
				player.DoDamage(damage);
			}
		}

		void OnCollisionExit2D(Collision2D collision)
		{
			if (collision.collider.tag == "Player")
			{
				PlayerAnimation.UpdateDamage(false);
				Player player = collision.collider.GetComponent<Player>();
				player.DoDamage(damage);
			}
		}
	}
}