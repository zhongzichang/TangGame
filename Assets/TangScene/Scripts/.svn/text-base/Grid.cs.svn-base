using System;
using UnityEngine;
using TangUtils;

namespace TangScene
{
	/// <summary>
	/// Grid. Grid position
	/// </summary>
	[Serializable]
	public class Grid
	{
		
		public const int WIDTH = 32;
		public const int HEIGHT = 16;
		
		
		public static Point FromPosition( Vector3 position){
			
			int x = (int)(position.x / WIDTH);
			int y = -(int)(position.z / HEIGHT);
			
			return new Point(x,y);
			
		}
	}
}

