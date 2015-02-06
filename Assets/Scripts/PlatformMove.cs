using UnityEngine;
using System.Collections;

namespace PlatformEngine
{
	[ExecuteInEditMode]
	public class PlatformMove : MonoBehaviour
	{

		public float speed = 1.0f;
		[SerializeField]
		private Transform end;
		private Vector3 startPosition, endPosition;
		private Vector3 dir;

		private bool isStart = false;
		private bool vertical = false;

		[SerializeField]
		private bool isEnable = true;

		public bool IsEnable
		{
			get { return isEnable; }
			set { isEnable = value; }
		}

		// Use this for initialization
		void Start()
		{			
			end = transform.Find("End");

			startPosition = transform.position;// start.position;
			endPosition = end.position;
			if (startPosition.x > endPosition.x)
			{
				Vector3 tmp = startPosition;
				startPosition = endPosition;
				endPosition = tmp;
			}
			if(Application.isPlaying)
				end.parent = transform.parent;
			dir = endPosition - startPosition;
			dir.Normalize();
			float x_diff = Mathf.Abs(startPosition.x - endPosition.x);
			float y_diff = Mathf.Abs(startPosition.y - endPosition.y);

			if (x_diff < y_diff)
				vertical = true;
		}

		// Update is called once per frame
		void Update()
		{
			if (!isEnable)
				return;
			if (isStart)
			{
				transform.Translate(dir * speed * Time.deltaTime);
				if (!vertical && transform.position.x >= endPosition.x)
					Flip();
				else if (vertical && transform.position.y >= endPosition.y)
					Flip();
				
			}
			else
			{
				transform.Translate(-dir * speed * Time.deltaTime);
				if (!vertical && transform.position.x <= startPosition.x)
					Flip();
				else if (vertical && transform.position.y <= startPosition.y)
					Flip();

				
			}
		}

		void Flip()
		{
			isStart = !isStart;
		}

		
		void OnDrawGizmos()
		{
			if (startPosition != null && endPosition != null)
			{
				Gizmos.color = Color.yellow;
				Gizmos.DrawLine(startPosition, endPosition);
			}
		}

		

	
	}
}
