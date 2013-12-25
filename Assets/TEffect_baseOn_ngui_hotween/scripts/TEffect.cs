using UnityEngine;
using System.Collections;
using Holoville.HOTween;

namespace zyhd.TEffect{
	public class TEffect{
		
//		public enum EffectType{
//			Dmg,DmgCrit,Hp,HpCrit,Buff,Debuff,Logo
//		}
		
		public TEffectType eff;
		public int dmg;
		public long num;
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
		public GameObject selfGameObject;
		/// eff动画类型 dmg伤害 targetPosition挂载点坐标 /// 
		public TEffect(TEffectType eff,int dmg,Vector3 targetPosition){
			this.eff = eff;
			this.dmg = dmg;
			this.targetPosition = targetPosition;
			MyCache.effQueue.Enqueue (this);
			MyCache.effQueueNum++;
//			switch(eff){
//			case TEffectType.Dmg:
//			case TEffectType.DmgCrit:
//			case TEffectType.Hp:
//			case TEffectType.HpCrit:
//				MyCache.effQueue.Enqueue (this);
//				MyCache.effQueueNum++;
//				break;
//			}
			
		}
		public TEffect(TEffectType eff,long num,Vector3 targetPosition){
			this.eff = eff;
			this.num = num;
			this.targetPosition = targetPosition;
			MyCache.effQueue.Enqueue (this);
			MyCache.effQueueNum++;
		}
		/// eff动画类型 spriteName图集中的精灵名 targetPosition挂载点坐标 ///
		public TEffect(TEffectType eff,string spriteName,Vector3 targetPosition){
			this.eff = eff;
			this.spriteName = spriteName;
			this.targetPosition = targetPosition;
			MyCache.effQueue.Enqueue (this);
			MyCache.effQueueNum++;
		}
		
		public TEffect(TEffectType eff,string msg,Color color,int fontsize,Vector3 offset3, GameObject target){
			this.eff = eff;
			this.msg = msg;
			this.target = target;
			this.targetPosition = target.transform.position;
			this.color = color;
			this.fontsize = fontsize;
			this.offset3 = offset3;
			MyCache.logoQueue.Enqueue (this);
			MyCache.logoQueueNum++;
		}
		public TEffect(TEffectType eff,Vector3 offset3, GameObject target){
			this.eff = eff;
			this.target = target;
			this.targetPosition = target.transform.position;
			this.offset3 = offset3;
			MyCache.logoQueue.Enqueue (this);
			MyCache.logoQueueNum++;
		}
		
		public TEffect(TEffectType eff,string[] up,string[] down,string[] spriteUps,string[] spriteDwons,Vector2 offset,GameObject target){
			this.eff = eff;
			this.up = up;
			this.down = down;
			this.spriteUps = spriteUps;
			this.spriteDwons = spriteDwons;
			this.target = target;
			this.offset2 = offset;
			MyCache.effQueue.Enqueue (this);
			MyCache.effQueueNum++;
		}
		public void DisplayLogo(){
			TEffectLogo tl;
			if(MyCache.logos.TryGetValue(this,out tl)){
				tl.sq.Kill ();
				GameObject.Destroy (tl.go);
				MyCache.logos.Remove (this);
			}
		}
		public void Display(){
			GameObject go;
			if(MyCache.texts.TryGetValue(this,out go)){
				GameObject.Destroy (go);
				MyCache.texts.Remove (this);
			}
		}
		public void SetNumber(float num){
			if(fg != null) fg.fillAmount = Mathf.Clamp(num,0,1);
		}
		
		public TEffect(TEffectType eff,string msg,string color,int fontsize,Vector2 offset2, GameObject target){
			this.eff = eff;
			this.msg = msg;
			this.target = target;
			this.targetPosition = target.transform.position;
			this.colorStr = color;
			this.fontsize = fontsize;
			this.offset2 = offset2;
			MyCache.textQueue.Enqueue (this);
			MyCache.textQueueNum++;
		}
		public TEffect(TEffectType eff,string[] imgs,GameObject target){
			this.eff = eff;
			this.imgs = imgs;
			this.target = target;
			MyCache.logoQueue.Enqueue (this);
			MyCache.logoQueueNum++;
		}
//		public void DisplayText(){
//			GameObject go;
//			if(MyCache.texts.TryGetValue(this,out go)){
//				GameObject.Destroy (go);
//				MyCache.texts.Remove (this);
//			}
//		}
//		public void DisplayNpcSelected(){
//			GameObject go;
//			if(MyCache.texts.TryGetValue(this,out go)){
//				GameObject.Destroy (go);
//				MyCache.texts.Remove (this);
//			}
//		}
	}
}