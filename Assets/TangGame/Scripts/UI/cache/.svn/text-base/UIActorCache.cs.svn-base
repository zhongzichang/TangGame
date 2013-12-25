// yc 2013/11/18
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TangGame.Net;
using zyhd.TEffect;
using PureMVC.Interfaces;
using PureMVC.Patterns;

namespace nh.ui.cache{
	public class UIActorCache {
		public static HeroNew myHero = null;
		
		
		
		public static void ChangeHeroData(HeroPropertyPush push){
			if(myHero == null) return;
			List<KeyValuePair<short,object>> list = push.heroPropertyList;
			if(list.Count < 1) return;
			List<string> ups = new List<string>();
			List<string> dwons = new List<string>();
			List<string> spriteUps = new List<string>();
			List<string> spriteDowns = new List<string>();
			
			foreach(KeyValuePair<short,object> kv in list){
//				Debug.Log(kv.Key + ":" +kv.Value);
				int delta = 0;
				long deltaLong = 0;
				switch((HeroPropertyEnum)((int)kv.Key)){
					case HeroPropertyEnum.MONEY:
						deltaLong = (long)kv.Value - myHero.coin;
						if(deltaLong > 0){
							ups.Add("+" + deltaLong.ToString());
							spriteUps.Add("avoid");
						}else if(deltaLong < 0){
							dwons.Add(deltaLong.ToString());
							spriteDowns.Add("avoid");
						}
						myHero.coin=(long)kv.Value;
						break;
					case HeroPropertyEnum.SILVERINGOT:
						deltaLong = (long)kv.Value - myHero.silver;
						if(deltaLong > 0){
							ups.Add("+" + deltaLong.ToString());
							spriteUps.Add("avoid");
						}else if(deltaLong < 0){
							dwons.Add(deltaLong.ToString());
							spriteDowns.Add("avoid");
						}
						myHero.silver=(long)kv.Value;
						break;
					case HeroPropertyEnum.GOLDINGOT:
						deltaLong = (long)kv.Value - myHero.ingot;
						if(deltaLong > 0){
							ups.Add("+" + deltaLong.ToString());
							spriteUps.Add("avoid");
						}else if(deltaLong < 0){
							dwons.Add(deltaLong.ToString());
							spriteDowns.Add("avoid");
						}
						myHero.ingot=(long)kv.Value;
						break;
					case HeroPropertyEnum.LV:
						myHero.level=(int)kv.Value;
						break;
					case HeroPropertyEnum.EXP:
						deltaLong = (long)kv.Value - myHero.exp;
						if (deltaLong != 0)
							Facade.Instance.SendNotification (TangGame.NotificationIDs.ID_UpdateExpPanel);
						new TEffect(TEffectType.Exp,deltaLong,(TangScene.TS.GetActorGameObject(myHero.id).transform.position + new Vector3(0,0,60)));
						myHero.exp=(long)kv.Value;
						break;
					case HeroPropertyEnum.EXPMAX:
						myHero.expMax=(long)kv.Value;
						break;
					case HeroPropertyEnum.HP:
						myHero.hp=(int)kv.Value;
						break;
					case HeroPropertyEnum.HPMAX:
						delta = (int)kv.Value - myHero.hpMax;
						if(delta > 0){
							ups.Add("+" + delta.ToString());
							spriteUps.Add("u_hp");
						}else if(delta < 0){
							dwons.Add(delta.ToString());
							spriteDowns.Add("d_hp");
						}
						myHero.hpMax=(int)kv.Value;
						break;
					case HeroPropertyEnum.MP:
						myHero.mp=(int)kv.Value;
						break;
					case HeroPropertyEnum.MPMAX:
						delta = (int)kv.Value - myHero.mpMax;
						if(deltaLong > 0){
							ups.Add("+" + delta.ToString());
							spriteUps.Add("avoid");
						}else if(delta < 0){
							dwons.Add(delta.ToString());
							spriteDowns.Add("avoid");
						}
						myHero.mpMax=(int)kv.Value;
						break;
					case HeroPropertyEnum.PHYSICALATTACK:
						delta = (int)kv.Value - myHero.physicalAttack;
						if(delta > 0){
							ups.Add("+" + delta.ToString());
							spriteUps.Add("u_att");
						}else if(delta < 0){
							dwons.Add(delta.ToString());
							spriteDowns.Add("d_att");
						}
						myHero.physicalAttack=(int)kv.Value;
						break;
					case HeroPropertyEnum.PHYSICALDEFENSE:
						delta = (int)kv.Value - myHero.physicalDefense;
						if(delta > 0){
							ups.Add("+" + delta.ToString());
							spriteUps.Add("u_def");
						}else if(delta < 0){
							dwons.Add(delta.ToString());
							spriteDowns.Add("d_def");
						}
						myHero.physicalDefense=(int)kv.Value;
						break;
					case HeroPropertyEnum.MAGICATTACK:
						delta = (int)kv.Value - myHero.magicAttack;
						if(delta > 0){
							ups.Add("+" + delta.ToString());
							spriteUps.Add("avoid");
						}else if(delta < 0){
							dwons.Add(delta.ToString());
							spriteDowns.Add("avoid");
						}
						myHero.magicAttack=(int)kv.Value;
						break;
					case HeroPropertyEnum.MAGICDEFENSE:
						delta = (int)kv.Value - myHero.magicDefense;
						if(delta > 0){
							ups.Add("+" + delta.ToString());
							spriteUps.Add("avoid");
						}else if(delta < 0){
							dwons.Add(delta.ToString());
							spriteDowns.Add("avoid");
						}
						myHero.magicDefense=(int)kv.Value;
						break;
					case HeroPropertyEnum.HITRATE:
						delta = (int)kv.Value - myHero.hitrate;
						if(delta > 0){
							ups.Add("+" + delta.ToString());
							spriteUps.Add("u_rage");
						}else if(delta < 0){
							dwons.Add(delta.ToString());
							spriteDowns.Add("d_rage");
						}
						myHero.hitrate=(int)kv.Value;
						break;
					case HeroPropertyEnum.DODGE:
						delta = (int)kv.Value - myHero.dodge;
						if(delta > 0){
							ups.Add("+" + delta.ToString());
							spriteUps.Add("u_avoid");
						}else if(delta < 0){
							dwons.Add(delta.ToString());
							spriteDowns.Add("d_avoid");
						}
						myHero.dodge=(int)kv.Value;
						break;
					case HeroPropertyEnum.CRITICALSTRIKE:
						delta = (int)kv.Value - myHero.criticalStrike;
						if(deltaLong > 0){
							ups.Add("+" + delta.ToString());
							spriteUps.Add("u_crit");
						}else if(delta < 0){
							dwons.Add(delta.ToString());
							spriteDowns.Add("d_crit");
						}
						myHero.criticalStrike=(int)kv.Value;
						break;
					case HeroPropertyEnum.TENACITY:
						delta = (int)kv.Value - myHero.tenacity;
						if(delta > 0){
							ups.Add("+" + delta.ToString());
							spriteUps.Add("avoid");
						}else if(delta < 0){
							dwons.Add(delta.ToString());
							spriteDowns.Add("avoid");
						}
						myHero.tenacity=(int)kv.Value;
						break;
					case HeroPropertyEnum.REALYUAN:
						delta = (int)kv.Value - myHero.zhengYuan;
						if(delta > 0){
							ups.Add("+" + delta.ToString());
							spriteUps.Add("avoid");
						}else if(delta < 0){
							dwons.Add(delta.ToString());
							spriteDowns.Add("avoid");
						}
						myHero.zhengYuan = (int)kv.Value;
						break;
				}
			}
//			Debug.Log(myHero.hp + ":" +myHero.mp +":" + myHero.level);
			if(TangScene.TS.GetActorGameObject(myHero.id) != null)
			new TEffect(TEffectType.AttributeChange,ups.ToArray(),dwons.ToArray(),spriteUps.ToArray(),spriteDowns.ToArray(),
			            new Vector2(0,60),TangScene.TS.GetActorGameObject(myHero.id));

			PureMVC.Patterns.Facade.Instance.SendNotification(TangGame.NotificationIDs.ID_ReSetHeroPropertyNum);
		}
	}
}