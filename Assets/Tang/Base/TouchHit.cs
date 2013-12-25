/**
 * Created by emacs
 * Date: 2013/10/11
 * Author: zzc
 */
using UnityEngine;

namespace Tang
{
	public class TouchHit
	{
		public int fingerId;
		public Vector3 point;
		public object extraObject;

		public TouchHit (int fingerId, Vector3 point, object extraObject)
		{
			this.fingerId = fingerId;
			this.point = point;
			this. extraObject = extraObject;
		}

		public TouchHit (int fingerId, Vector3 point)
		{
			this.fingerId = fingerId;
			this.point = point;
		}

	}
}