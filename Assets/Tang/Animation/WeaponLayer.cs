/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/8/12
 * Time: 15:20
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Tang
{
	/// <summary>
	/// Description of WeaponLayer.
	/// </summary>
	public class WeaponLayer : CommonLayer
	{

		public const string NAME = "weapon";
		
		public WeaponLayer() : base( NAME )
		{
		}
		
		public WeaponLayer(TTSprite spritePrefab) : base( NAME, spritePrefab){
		}
		
	}
}
