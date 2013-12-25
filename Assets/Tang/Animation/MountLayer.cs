/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/8/12
 * Time: 15:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Tang
{
	/// <summary>
	/// Description of MountLayer.
	/// </summary>
	public class MountLayer : CommonLayer
	{

		public const string NAME = "mount";
		
		public MountLayer() : base(NAME)
		{
		}
		
		public MountLayer(TTSprite spritePrefab) : base(NAME, spritePrefab)
		{
		}
		
	}
}
