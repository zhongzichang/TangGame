using UnityEngine;
using System.Collections;

namespace zyhd.TEffect{
	
	public class TET {
		public TEffectType eff;
		public int dmg;
		public Vector3 targetPosition;
		public string[]  imgs;
		public string spriteName;
		public string colorStr;
		public Color color;
		public string msg;
		public int fontsize;
		public Vector2 offset2;
		public Vector3 offset3;
		public GameObject target;
		public string[]  up;
		public string[]  down;
		public string[]  spriteUps;
		public string[]  spriteDwons;
		public UISprite fg;
		
		public long targetId;
		public float mTime;
		public TEffect teff;
		public TETContrl tc;
		public TET(TEffectType eff,int dmg,Vector3 offset3,long id,float mTime){
			this.eff = eff;
			this.dmg = dmg;
			this.targetId = id;
			this.mTime = mTime;
			this.offset3 = offset3;
			TETMono.mCache.Add (this);
		}
		public TET(TEffectType eff,string spriteName,Vector3 offset3,long id,float mTime){
			this.eff = eff;
			this.spriteName = spriteName;
			this.targetId = id;
			this.mTime = mTime;
			this.offset3 = offset3;
			TETMono.mCache.Add (this);
		}
		public TET(TEffectType eff,string msg,Color color,int fontsize,Vector3 offset3, GameObject target,float mTime){
			this.eff = eff;
			this.msg = msg;
			this.target = target;
			this.targetPosition = target.transform.position;
			this.color = color;
			this.fontsize = fontsize;
			this.offset3 = offset3;
			this.mTime = mTime;
			TETMono.mCache.Add (this);
		}
		public TET(TEffectType eff,Vector3 offset3, GameObject target,float mTime){
			this.eff = eff;
			this.target = target;
			this.targetPosition = target.transform.position;
			this.offset3 = offset3;
			this.mTime = mTime;
			TETMono.mCache.Add (this);
		}
		public TET(TEffectType eff,string[] up,string[] down,string[] spriteUps,string[] spriteDwons,Vector2 offset2,long id,float mTime){
			this.eff = eff;
			this.up = up;
			this.down = down;
			this.spriteUps = spriteUps;
			this.spriteDwons = spriteDwons;
			this.targetId = id;
			this.mTime = mTime;
			this.offset2 = offset2;
			TETMono.mCache.Add (this);
		}
		
		public void ResetDestroyTime(){
			tc.ResetTime ();
		}
		public void ResetDestroyTime(float time){
			tc.ResetTime (time);
		}
		public void SetNum(float num){
			teff.SetNumber (num);
		}
	}
}