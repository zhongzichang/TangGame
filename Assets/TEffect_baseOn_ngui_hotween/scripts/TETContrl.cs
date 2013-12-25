using UnityEngine;
using System.Collections;

namespace zyhd.TEffect{
	public class TETContrl : MonoBehaviour {
		
		[HideInInspector] public TET tet;
		private const float DELETE_TIME = 3f;
		private TEffectType type;
		private float timer = 0;
		private float mDeleteTime = -1;
		void Start () {

		}
		
		// Update is called once per frame
		void Update () {
			if(mDeleteTime > 0){
				timer += Time.deltaTime;
				if(timer >= mDeleteTime || tet.target == null){
					tet.teff.Display ();
				}
			}
			
		}
		
		public void ResetTime(){
			timer = 0;
		}
		public void ResetTime(float time){
			timer = 0;
			mDeleteTime = time;
		}
	}
}