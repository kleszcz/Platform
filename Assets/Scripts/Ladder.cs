using UnityEngine;
using System.Collections;

namespace PlatformEngine
{
	public class Ladder : MonoBehaviour
	{
		public enum State { Enter, Stay, Exit }
		public State state;

		void OnTriggerEnter2D(Collider2D collider)
		{
			IClimb climb = collider.GetComponent(typeof(IClimb)) as IClimb;
			if (climb != null)
			{
				climb.StartClimb();
				state = State.Enter;
			}
		}

		void OnTriggerExit2D(Collider2D collider)
		{
			IClimb climb = collider.GetComponent(typeof(IClimb)) as IClimb;
			if (climb != null)
			{
				climb.EndClimb();
				state = State.Exit;
			}
		}

		void OnTriggerStay2D(Collider2D collider)
		{
			IClimb climb = collider.GetComponent(typeof(IClimb)) as IClimb;
			if (climb != null)
			{
				state = State.Stay;
				climb.Climb();
			}
		}
	}
}