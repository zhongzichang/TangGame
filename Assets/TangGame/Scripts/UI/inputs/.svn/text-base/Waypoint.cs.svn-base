using UnityEngine;
using System.Collections;

namespace TangGame
{

	public class Waypoint : MonoBehaviour
	{
		public float duration = 1;

		void OnEnable()
		{
			StartCoroutine(Tick());
		}

		IEnumerator Tick()
		{
			yield return new WaitForSeconds(duration);
			
			this.Recycle();
		}
	}

}