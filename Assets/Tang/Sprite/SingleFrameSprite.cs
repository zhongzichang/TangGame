using UnityEngine;
using System.Collections;

namespace Tang {

	[ExecuteInEditMode]
	public class SingleFrameSprite : TTSprite {
		
		public Frame fr;
	
		// Use this for initialization
		void Start () {
			if(fr != null){
				base.Init();
				CurrentFrame = fr;
			}
		}
		
		void Update(){
			// do nothing
		}
		
	}

}