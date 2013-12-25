/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/8/12
 * Time: 16:08
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Tang
{
	/// <summary>
	/// Description of CommonLayer.
	/// </summary>
	public class CommonLayer : SpriteLayer
	{
		
		public const int FRAME_DELAY = 0;
		public const bool HIDDEN_BEFORE_BEGIN = true;
		public const bool HIDDEN_AFTER_END = true;
		
		
		public CommonLayer(string name) : base(name)
		{
			InitFields();
		}
		
		public CommonLayer(string name, TTSprite spritePrefab) : base(name){
			this.spritePrefab = spritePrefab;
			InitFields();
		}
		
		private void InitFields(){
			this.frameDelay = FRAME_DELAY;
			this.hiddenBeforeBegin = HIDDEN_BEFORE_BEGIN;
			this.hiddenAfterEnd = HIDDEN_AFTER_END;
		}
	}
}
