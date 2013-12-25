using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace zyhd.TEffect{
	public class TETMono : MonoBehaviour {
		[HideInInspector]public static HashSet<TET> mCache = new HashSet<TET>();
		[HideInInspector]public static HashSet<TET> oCache = new HashSet<TET>();
//		private float timer = 0;
		void Start () {
		
		}
	
		void Update () {
			if(mCache.Count > 0){
				foreach(TET tet in mCache){
					if(tet.mTime < 0.0001f) {
						StartTEffect (tet);
						oCache.Add (tet);
					}else {
						tet.mTime -= Time.deltaTime;
					}
				}
				foreach(TET tet in oCache){
					mCache.Remove (tet);
				}
				oCache.Clear ();
			}
			
		}
		
		private void StartTEffect(TET tet){
//			Debug.Log ("@@@@@@@@@@@@");
			tet = UpdatePosition (tet);
			switch(tet.eff){
			case TEffectType.Dmg:
			case TEffectType.DmgCrit:
			case TEffectType.Hp:
			case TEffectType.HpCrit:
			case TEffectType.PetDmg:
			case TEffectType.SelfHurt:
			case TEffectType.Exp:	
				new TEffect(tet.eff,tet.dmg,tet.targetPosition + tet.offset3);
				break;
			case TEffectType.Avoid:
				new TEffect(tet.eff,tet.spriteName,tet.targetPosition + tet.offset3);
				break;
			case TEffectType.AttributeChange:
				new TEffect(tet.eff,tet.up,tet.down,tet.spriteUps,tet.spriteDwons,tet.offset3,tet.target);
				break;
			case TEffectType.NpcSelected:
				tet.teff = new TEffect(tet.eff,tet.spriteName,tet.targetPosition + tet.offset3);
				break;
			case TEffectType.NpcTalk:
				new TEffect(tet.eff,tet.spriteName,tet.targetPosition + tet.offset3);
				break;
			case TEffectType.PlayerName:
				tet.teff = new TEffect(TEffectType.PlayerName,tet.msg,tet.color,tet.fontsize,tet.offset2,tet.target);
				StartCoroutine (GetObj(tet));
//				if(tet.teff.selfGameObject == null) Debug.Log ("~~~~~~~");
//				TETContrl tc = tet.teff.selfGameObject.AddComponent<TETContrl>();
//				tc.tet = tet;
//				tc.tet.tc = tc;
				break;
			case TEffectType.PlayerHpShow:
				tet.teff = new TEffect(TEffectType.PlayerHpShow,tet.offset3,tet.target);
				StartCoroutine (GetObj(tet));
				break;
			}
		}
		//update target info in your game logic
		private TET UpdatePosition(TET tet){
			tet.target = TangScene.TS.GetActorGameObject (tet.targetId);
			tet.targetPosition = TangScene.TS.GetActorGameObject (tet.targetId).transform.position;
			
//			tet.target = transform.FindChild ("effectRoot").gameObject;
//			tet.targetPosition = transform.FindChild ("effectRoot").position;
			
			return tet;
		}
		IEnumerator GetObj(TET tet){
			yield return tet.teff.selfGameObject;
			TETContrl tc = tet.teff.selfGameObject.AddComponent<TETContrl>();
			tc.tet = tet;
			tc.tet.tc = tc;
		}
	}
}