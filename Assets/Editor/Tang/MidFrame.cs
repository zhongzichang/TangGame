using UnityEngine;
using System;


namespace Tang {
	
	public class MidFrame : Frame
	{
		
		/// <summary>
		/// This frame's name
		/// </summary>
		public string name;
		/// <summary>
		/// This frame's world rotation modifier
		/// </summary>
		public float rotation;
		/// <summary>
		/// The index of the frame
		/// </summary>
		public int index;
		
		public MidFrame(){
		}
		
		public MidFrame(Vector2 size, Vector2 offset, Vector2[] uv) : base(size, offset, uv)
		{
		}
	}
}