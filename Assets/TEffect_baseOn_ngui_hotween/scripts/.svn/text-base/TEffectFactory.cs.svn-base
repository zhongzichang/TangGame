using UnityEngine;
using System.Collections;
using Holoville.HOTween;
using Holoville.HOTween.Plugins;

namespace zyhd.TEffect{
	public class TEffectFactory{
		private int FONT_SIZE = 16;
		
//		private int count = 0;
		private static TEffectFactory instance;
		private TEffectFactory (){
			
		}
		public static TEffectFactory GetInstance(){
			if(instance == null){
				instance = new TEffectFactory();
			}
			return instance;
		}
		
		
		public void InitEffect(TEffect eff){
			Vector3 targetPosition = eff.targetPosition;
			TEffectType type = eff.eff;
			
			Vector3 screenPosition = this.GetScreenPosition(targetPosition);
			GameObject go = GetRoot(screenPosition);
			switch(type){
			case TEffectType.Dmg:
			case TEffectType.DmgCrit:
			case TEffectType.Hp:
			case TEffectType.HpCrit:
			case TEffectType.PetDmg:
			case TEffectType.SelfHurt:	
//				string dmg = eff.dmg.ToString ();
				ShowTEffect (go,type,(long)eff.dmg);
				break;
			case TEffectType.Exp:
				ShowTEffect (go,type,eff.num);
				break;
			case TEffectType.Avoid:
				ShowTEffect (go,eff.spriteName);
				break;
			case TEffectType.Logo:
				ShowLogoTEffect (go,eff.imgs,eff);
				break;
			case TEffectType.AttributeChange:
				AttributeChange(go,eff.up,eff.down,eff.spriteUps,eff.spriteDwons,eff.offset2,eff.target);
				break;
			case TEffectType.NpcSelected:
				NpcSelected(go,eff.spriteName,eff);
				break;
			case TEffectType.NpcTalk:
				NpcTalk(go,eff.spriteName);
				break;
			case TEffectType.PlayerName:
				PlayerName(go,eff);
				break;
			case TEffectType.PlayerHpShow:
				PlayerHpShow(go,eff);
				break;
			case TEffectType.OtherDmg:
				ShowOhterDmg(go,eff.spriteName);
				break;
			}
			
		}
		
		private Vector3 GetScreenPositionOld(Vector3 targetPosition){
			Vector3 temp = Camera.main.WorldToViewportPoint(targetPosition);
			return new Vector3((temp.x-0.5f)*Screen.width ,(temp.y-0.5f)*Screen.height,0f);
		}
		private Vector3 GetScreenPosition(Vector3 targetPosition){
			Vector3 temp = Camera.main.WorldToViewportPoint(targetPosition);
			return new Vector3((temp.x-0.5f)*Screen.width*MyCache.uiRoot.pixelSizeAdjustment ,(temp.y-0.5f)*Screen.height*MyCache.uiRoot.pixelSizeAdjustment,0f);
		}
		private GameObject GetRoot1(Vector3 screenPosition){
			GameObject go = new GameObject();
			go.transform.parent = MyCache.root.transform;
			go.layer = MyCache.root.layer;
//			go.AddComponent<UIPanel>().depth = -10;
			go.transform.localScale = Vector3.one;
			go.transform.localPosition= screenPosition;
			return go;
		}
		private GameObject GetRoot(Vector3 screenPosition){
			GameObject go = GameObject.Instantiate(MyCache.itemPrefab) as GameObject;
			go.transform.parent = MyCache.root.transform;
			go.layer = MyCache.root.layer;
			go.transform.localScale = Vector3.one;
			go.transform.localPosition= screenPosition;
			return go;
		}
		//---------------------init logic------------------------------------------
		private void ShowTEffect(GameObject go,TEffectType type,long dmgNum){
			UISprite[] startSprites;
			UISprite[] dmgSprites;
//			UISprite[] endSprites;
			string dmg = Mathf.Abs(dmgNum).ToString ();
			float count = 0;
			switch(type){
			case TEffectType.Dmg:
				startSprites = new UISprite[1];
				dmgSprites = new UISprite[dmg.Length];
				if(dmgNum >= 0){
					startSprites[0] = NGUITools.AddSprite(go,MyCache.usedAtlas,MyCache.DMG_PRE+ "+");
				}else{
					startSprites[0] = NGUITools.AddSprite(go,MyCache.usedAtlas,MyCache.DMG_PRE+ "-");
				}	
//				startSprites[0] = NGUITools.AddSprite(go,MyCache.usedAtlas,MyCache.DMG_PRE+ "-");
				startSprites[0].MakePixelPerfect();
				startSprites[0].pivot = UIWidget.Pivot.Right;
				startSprites[0].type = UISprite.Type.Sliced;
				startSprites[0].transform.parent = go.transform;
				startSprites[0].transform.localPosition = Vector3.zero;
				//count += startSprites[0].transform.localScale.x;
	//			for(int i = 0;i < dmgSprites.Length;i++){
	//				dmgSprites[i] = NGUITools.AddSprite (go,dmg_atlas,dmg[i].ToString ());
	//				dmgSprites[i].transform.parent = go.transform;
	//				dmgSprites[i].MakePixelPerfect ();
	//				dmgSprites[i].transform.localPosition = new Vector3(count,0f,0f);
	//				count += dmgSprites[i].transform.localScale.x;
	//			}
				initImgs (out dmgSprites,ref count,go,dmg,MyCache.DMG_PRE);
				this.SetHurtAnimation(go);
				break;
			case TEffectType.DmgCrit:
				startSprites = new UISprite[2];
				dmgSprites = new UISprite[dmg.Length];
				startSprites[0] = NGUITools.AddSprite(go,MyCache.usedAtlas,MyCache.CRIT_PRE+ "crit");
				startSprites[0].transform.parent = go.transform;
				startSprites[0].MakePixelPerfect();
				startSprites[0].pivot = UIWidget.Pivot.Right;
				startSprites[0].type = UISprite.Type.Sliced;
				startSprites[0].transform.localPosition = Vector3.zero;
				//count += startSprites[0].transform.localScale.x;
				if(dmgNum >= 0){
					startSprites[1] = NGUITools.AddSprite(go,MyCache.usedAtlas,MyCache.CRIT_PRE+ "+");
				}else{
					startSprites[1] = NGUITools.AddSprite(go,MyCache.usedAtlas,MyCache.CRIT_PRE+ "-");
				}	
				startSprites[1].MakePixelPerfect();
				startSprites[1].pivot = UIWidget.Pivot.Left;
				startSprites[1].type = UISprite.Type.Sliced;
				startSprites[1].transform.parent = go.transform;
				startSprites[1].transform.localPosition = new Vector3(count,0f,0f);
				count += startSprites[1].width;
				initImgs (out dmgSprites,ref count,go,dmg,MyCache.CRIT_PRE);
				
//				SetCriticalAnimation(go);
				SetScaleBigAnimation (go,1f,TEffectType.DmgCrit);
				break;
			case TEffectType.PetDmg:
				startSprites = new UISprite[1];
				dmgSprites = new UISprite[dmg.Length];
				if(dmgNum >= 0){
					startSprites[0] = NGUITools.AddSprite(go,MyCache.usedAtlas,MyCache.PET_PRE+ "+");
				}else{
					startSprites[0] = NGUITools.AddSprite(go,MyCache.usedAtlas,MyCache.PET_PRE+ "-");
				}	
//				startSprites[0] = NGUITools.AddSprite(go,MyCache.usedAtlas,MyCache.PET_PRE+ "-");
				startSprites[0].MakePixelPerfect();
				startSprites[0].pivot = UIWidget.Pivot.Right;
				startSprites[0].type = UISprite.Type.Sliced;
				startSprites[0].transform.parent = go.transform;
				startSprites[0].transform.localPosition = Vector3.zero;
				initImgs (out dmgSprites,ref count,go,dmg,MyCache.PET_PRE);
				SetPetHurtAnimation (go);
				break;
			case TEffectType.SelfHurt:
				startSprites = new UISprite[1];
				dmgSprites = new UISprite[dmg.Length];
				if(dmgNum >= 0){
					startSprites[0] = NGUITools.AddSprite(go,MyCache.usedAtlas,MyCache.SELF_PRE+ "+");
				}else{
					startSprites[0] = NGUITools.AddSprite(go,MyCache.usedAtlas,MyCache.SELF_PRE+ "-");
				}	
				startSprites[0].MakePixelPerfect();
				startSprites[0].pivot = UIWidget.Pivot.Right;
				startSprites[0].type = UISprite.Type.Sliced;
				startSprites[0].transform.parent = go.transform;
				startSprites[0].transform.localPosition = Vector3.zero;
				initImgs (out dmgSprites,ref count,go,dmg,MyCache.SELF_PRE);
				SetSelfHurtAnimation (go);
				break;
			case TEffectType.Exp:
				startSprites = new UISprite[2];
				dmgSprites = new UISprite[dmg.Length];
				if(dmgNum >= 0){
					startSprites[0] = NGUITools.AddSprite(go,MyCache.usedAtlas,MyCache.EXP_PRE+ "+");
				}else{
					startSprites[0] = NGUITools.AddSprite(go,MyCache.usedAtlas,MyCache.EXP_PRE+ "-");
				}	
				startSprites[0].MakePixelPerfect();
				startSprites[0].pivot = UIWidget.Pivot.Right;
				startSprites[0].type = UISprite.Type.Sliced;
				startSprites[0].transform.parent = go.transform;
				startSprites[0].transform.localPosition = Vector3.zero;
				initImgs (out dmgSprites,ref count,go,dmg,MyCache.EXP_PRE);
				startSprites[1] = NGUITools.AddSprite(go,MyCache.usedAtlas,MyCache.EXP_PRE+ "exp");
				startSprites[1].MakePixelPerfect();
				startSprites[1].pivot = UIWidget.Pivot.Left;
				startSprites[1].type = UISprite.Type.Sliced;
				startSprites[1].transform.parent = go.transform;
				startSprites[1].transform.localPosition = new Vector3(count,0f,0f);
				SetScaleBigAnimation (go,0.5f,TEffectType.Exp);
				break;
			case TEffectType.Hp:
			case TEffectType.HpCrit:	
				startSprites = new UISprite[1];
				dmgSprites = new UISprite[dmg.Length];
				if(dmgNum >= 0){
					startSprites[0] = NGUITools.AddSprite(go,MyCache.usedAtlas,MyCache.HP_PRE+ "+");
				}else{
					startSprites[0] = NGUITools.AddSprite(go,MyCache.usedAtlas,MyCache.HP_PRE+ "-");
				}	
				startSprites[0].MakePixelPerfect();
				startSprites[0].pivot = UIWidget.Pivot.Right;
				startSprites[0].type = UISprite.Type.Sliced;
				startSprites[0].transform.parent = go.transform;
				startSprites[0].transform.localPosition = new Vector3(count,0f,0f);
				//count += startSprites[0].transform.localScale.x;
				initImgs (out dmgSprites,ref count,go,dmg,MyCache.HP_PRE);
				this.SetHpAnimation(go);
				break;
			}
		}
		
//		private void AttributeChangeOld(GameObject go){
//			string[] ups = new string[]{"+12","+120","+888","+6666"};
//			string[] downs = new string[]{"-12","-120","-555","-3333"};
//			
//			float offsetX = 25;
//			float offsetY = 28;
//			int countNum = 5;
//			float countX = 150;
//			float countY = -(offsetY*countNum);
//			UIPanel panel = go.GetComponent<UIPanel>();
//			panel.clipping = UIDrawCall.Clipping.SoftClip;
//			panel.clipRange = new Vector4(countX + 100,0,(countX + 100)*2,offsetY*countNum);
//			UISprite[] upsp = new UISprite[ups.Length];
//			UISprite[] downsp = new UISprite[downs.Length];
//			ArrayList obs = new ArrayList();
////			int len = ups.Length + downs.Length;
//
//			GameObject item = new GameObject("AttributeItem");
//
//			for(int i = 0;i < ups.Length; i++){
//				GameObject item1 = NGUITools.AddChild (go,item);
//				item1.transform.localScale = Vector3.one;
//				item1.transform.localPosition = new Vector3(countX,countY,0);
//				float ff =0;
//				initImgs (out upsp,ref ff,item1,ups[i],MyCache.HP_PRE);
//				countX -= offsetX;
//				countY -= offsetY;
//				obs.Add(item1);
//			}
//			for(int i = 0;i < downs.Length; i++){
//				GameObject item1 = NGUITools.AddChild (go,item);
//				item1.transform.localScale = Vector3.one;
//				item1.transform.localPosition = new Vector3(countX,countY,0);
//				float ff =0;
//				initImgs (out upsp,ref ff,item1,downs[i],MyCache.SELF_PRE);
//				countX -= offsetX;
//				countY -= offsetY;
//				obs.Add(item1);
//			}
//			
//			for(int i = 0;i < obs.Count;i++){
//				SetAttributeChangeAnimation (obs[i] as GameObject,offsetY*countNum*3);
//			}
//			SetDestroyAnimation (go,2f);
//			GameObject.DestroyImmediate (item);
//		}
		
		private void AttributeChange(GameObject go,string[] up,string[] down,string[] spriteUps,string[] spriteDwons,Vector2 offset,GameObject target){
//			string[] ups = new string[]{"+12","+120","+888","+6666"};
//			string[] downs = new string[]{"-12","-120","-555","-3333"};
			UISprite[] upsp = new UISprite[up.Length];
			UISprite[] downsp = new UISprite[down.Length];
			Queue obs = new Queue();

			GameObject item = new GameObject("AttributeItem");

			for(int i = 0;i < up.Length; i++){
				GameObject item1 = NGUITools.AddChild (go,item);
				item1.transform.localScale = Vector3.one;
				item1.transform.localPosition = Vector3.zero;
				float ff =0;
				initImgs (out upsp,ref ff,item1,up[i],MyCache.HP_PRE);
				UISprite sp = NGUITools.AddSprite (item1,MyCache.usedAtlas,spriteUps[i]);
				sp.MakePixelPerfect ();
				sp.type = UISprite.Type.Sliced;
				sp.pivot = UIWidget.Pivot.Left;
				sp.transform.localPosition = new Vector3(ff,0f,0f);
				item1.SetActive (false);
				obs.Enqueue(item1);
			}
			for(int i = 0;i < down.Length; i++){
				GameObject item1 = NGUITools.AddChild (go,item);
				item1.transform.localScale = Vector3.one;
				item1.transform.localPosition = Vector3.zero;
				float ff =0;
				initImgs (out downsp,ref ff,item1,down[i],MyCache.SELF_PRE);
				UISprite sp = NGUITools.AddSprite (item1,MyCache.usedAtlas,spriteDwons[i]);
				sp.MakePixelPerfect ();
				sp.type = UISprite.Type.Sliced;
				sp.pivot = UIWidget.Pivot.Left;
				sp.transform.localPosition = new Vector3(ff,0f,0f);
				item1.SetActive (false);
				obs.Enqueue(item1);
			}
			AttributeChangeObj abo = go.AddComponent<AttributeChangeObj>();
			abo.gos = obs;
			abo.offset2 = offset;
			abo.target = target;
			GameObject.DestroyImmediate (item);
		}
		private void initImgs(out UISprite[] dmgSprites,ref float count,GameObject go,string dmg,string pre){
			dmgSprites = new UISprite[dmg.Length];
			for(int i = 0;i < dmgSprites.Length;i++){
				dmgSprites[i] = NGUITools.AddSprite (go,MyCache.usedAtlas,pre + dmg[i]);
				//dmgSprites[i].transform.parent = go.transform;
				dmgSprites[i].MakePixelPerfect ();
				dmgSprites[i].type = UISprite.Type.Sliced;
				dmgSprites[i].pivot = UIWidget.Pivot.Left;
				dmgSprites[i].transform.localPosition = new Vector3(count,0f,0f);
				dmgSprites[i].depth = 0;
//				count += dmgSprites[i].transform.localScale.x;         //ngui 2.7
				count += dmgSprites[i].width;						   //ngui 3.0	
			}
		}
		
		private void ShowTEffect(GameObject go,string spriteName){
			UISprite sp = NGUITools.AddSprite (go,MyCache.usedAtlas,spriteName);
			sp.MakePixelPerfect ();
			SetAvoidAnimation (go);
		}
		private void ShowOhterDmg(GameObject go,string spriteName){
			UISprite sp = NGUITools.AddSprite (go,MyCache.usedAtlas,spriteName);
			sp.MakePixelPerfect ();
			SetOtherDmg(go);
		}
		
		private void ShowLogoTEffect(GameObject go,string[] imgs,TEffect eff){
			if(imgs == null) return;
			GameObject target = eff.target;
			go.AddComponent<TEffectLogoUpdate>().target = target;
			Sequence sequence = new Sequence(new SequenceParms().Loops (-1));
			int len = imgs.Length;
			UISprite[] sprites = new UISprite[len];
			for(int i = 0;i < len;i++){
				sprites[i] = NGUITools.AddSprite (go,MyCache.usedAtlas,imgs[i]);
				sprites[i].MakePixelPerfect ();
				sprites[i].type = UISprite.Type.Sliced;
				sprites[i].alpha = 0f;
				sprites[i].transform.localPosition = Vector3.zero;
				sequence.Append (HOTween.To(sprites[i], 1f, new TweenParms().Prop("alpha",1f).Ease (EaseType.EaseOutCirc).OnComplete (LogoEnd,sprites[i])));
				//sequence.Append (HOTween.To(sprites[i], 1f, new TweenParms().Prop("alpha",1f).Ease (EaseType.EaseOutCirc).OnUpdate(LogoUpdate,sprites[i]).OnComplete (LogoEnd,sprites[i])));
			}
			sequence.Play ();
			MyCache.logos.Add (eff,new TEffectLogo(go,sequence));
		}

		private void LogoUpdate(TweenEvent data){
			UISprite sp = data.parms[0] as UISprite;
			//sp.enabled = true;
			sp.alpha = 1f;
		}
		private void LogoEnd(TweenEvent data){
			UISprite sp = data.parms[0] as UISprite;
			//sp.enabled = false;
			sp.alpha = 0f;

		}
		
//_~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~		
		public void ShowTextTEffect(TEffect eff){
			Vector3 temp = Camera.main.WorldToViewportPoint(eff.target.transform.position);
			GameObject textObj = GameObject.Instantiate (MyCache.root.GetComponent<TEffectController>().prefab) as GameObject;
			textObj.transform.parent = eff.target.transform;
			textObj.transform.position = temp;
			textObj.guiText.fontSize = eff.fontsize;
			textObj.guiText.text = "<color=\""+eff.color+"\">"+eff.msg+"</color>";
			textObj.guiText.pixelOffset = eff.offset2;
			MyCache.texts.Add (eff,textObj);
		}
		
		private void NpcSelected(GameObject go,string spriteName,TEffect eff){
			UISprite sp = NGUITools.AddSprite (go,MyCache.usedAtlas,spriteName);
			sp.MakePixelPerfect ();
			NpcSelectdeAnimation (go);
			MyCache.texts.Add (eff,go);
		}
		private void NpcSelectdeAnimation(GameObject go){
			TweenParms type1 = new TweenParms ();
			type1.Prop ("localPosition", new Vector3 (0, 30, 0),true); 
			type1.Ease (EaseType.EaseOutQuint);
			type1.Loops (-1,LoopType.Yoyo);
//			type1.OnComplete(DestroyEff,go);
			HOTween.To (go.transform, 0.5f, type1);
		}
		private void NpcTalk(GameObject go,string talk){
//			GameObject bg = NGUITools.AddChild (go);
//			UILabel lab = NGUITools.AddWidget<UILabel>(go);
//			lab.font = MyCache.usedFont;
//			lab.supportEncoding = true;
//			lab.gameObject.transform.localScale = new Vector3(24,24,0f);
//			lab.lineWidth = 300;
//			lab.pivot = UIWidget.Pivot.BottomLeft;
//			float len = lab.font.CalculatePrintedSize (talk, FONT_SIZE, true,UIFont.SymbolStyle.None).x * lab.gameObject.transform.localScale.y + 2;
//			int count = Mathf.CeilToInt( len/lab.lineWidth);
//			UISprite sp = NGUITools.AddSprite (go,MyCache.usedAtlas,"");
//			sp.type = UISprite.Type.Sliced;
//			sp.pivot = UIWidget.Pivot.BottomLeft;
//			sp.gameObject.transform.localPosition = Vector3.zero;
//			float x = len > lab.lineWidth?lab.lineWidth:len;
//			sp.gameObject.transform.localScale = new Vector3(x + 2,24 * count,0);
//			lab.text = talk;
//			lab.gameObject.transform.localPosition = new Vector3(-x-20,0,0);
//			sp.gameObject.transform.localPosition = new Vector3(-x-20,0,0);
//			NpcTalkAnimation(go);
		}
		private void NpcTalkAnimation(GameObject go){
			TweenParms type1 = new TweenParms ();
			type1.Prop ("localPosition", new Vector3 (0, 0, 0),true); 
//			type1.Ease (EaseType.EaseOutQuint);
			type1.OnComplete(AlphaEff,go);
			HOTween.To (go.transform, 3f, type1);
		}
		//go,eff.msg,eff.color,eff.fontsize,eff.offset3,eff.target,eff		
		private void PlayerName(GameObject go,TEffect eff){
//			UILabel lab = NGUITools.AddWidget<UILabel>(go);
//			lab.font = MyCache.usedFont;
			GameObject labobj = NGUITools.AddChild(go,MyCache.labelObj);
			UILabel lab = labobj.GetComponent<UILabel>();
			lab.supportEncoding = false;
			lab.gameObject.transform.localScale = eff.fontsize ==0 ? new Vector3(24,24,0f):new Vector3(eff.fontsize,eff.fontsize,0);
			if(eff.color != null) lab.color = eff.color;
			lab.text = eff.msg;
			lab.maxLineCount = 1;
			TEffectObjUpdate ou = go.AddComponent<TEffectObjUpdate>();
			ou.eff = eff;
			if(eff.target) ou.go = eff.target;
			if(eff.offset3 != null) lab.gameObject.transform.localPosition = Vector3.zero + eff.offset3;
			eff.selfGameObject = go;
			MyCache.texts.Add (eff,go);
//			PlayerNameAnimation(go);
		}
//		private void PlayerNameAnimation(GameObject go){
//			TweenParms type1 = new TweenParms ();
//			type1.Prop ("localPosition", new Vector3 (0, 0, 0),true); 
//			type1.Loops (-1);
//			HOTween.To (go.transform, 3f, type1);
//		}
		
		private void PlayerHpShow(GameObject go,TEffect eff){
			UISprite bg = NGUITools.AddSprite (go,MyCache.usedAtlas,"dmg_-");
			bg.MakePixelPerfect ();
			bg.type = UISprite.Type.Sliced;
			UISprite fg = NGUITools.AddSprite (go,MyCache.usedAtlas,"exp_-");
			fg.MakePixelPerfect ();
			fg.type = UISprite.Type.Filled;
			fg.fillDirection = UISprite.FillDirection.Horizontal;
			bg.gameObject.transform.localPosition = Vector3.zero;
			fg.gameObject.transform.localPosition = Vector3.zero;
			bg.depth = -1;
			fg.depth = 0;
			TEffectObjUpdate ou = go.AddComponent<TEffectObjUpdate>();
			ou.eff = eff;
			if(eff.target) ou.go = eff.target;
			if(eff.offset3 != null) {
				bg.gameObject.transform.localPosition = eff.offset3;
				fg.gameObject.transform.localPosition = eff.offset3;
			}
			eff.fg = fg;
			eff.selfGameObject = go;
			MyCache.texts.Add (eff,go);
		}
		//-------------------animation--------------------------------------------------------------------------------------------------------
		private void SetHurtAnimationOld(GameObject go){
			TweenParms type1 = new TweenParms ();
			type1.Prop ("localPosition", new Vector3 (-80, 10, 0),true); 
			type1.Ease (EaseType.EaseOutQuint);
			type1.OnComplete(DestroyEff,go);
			HOTween.To (go.transform, 1.25f, type1);
		}
		
		private void SetHurtAnimation(GameObject go){
			TweenParms type1 = new TweenParms ();
			type1.Prop ("localPosition", GetRandomVector3 (TEffectType.Dmg),true); 
			type1.Ease (EaseType.EaseOutBounce);
			type1.OnComplete(SetWaitAnimation,go);
			HOTween.To (go.transform, 0.5f, type1);
		}
		
		private void SetPetHurtAnimation(GameObject go){
			TweenParms type1 = new TweenParms ();
//			type1.Prop ("localPosition", new Vector3 (30, 30, 0),true);
			type1.Prop ("localPosition", GetRandomVector3 (TEffectType.PetDmg),true);
			type1.Ease (EaseType.EaseOutBounce);
			type1.OnComplete(SetWaitAnimation,go);
			HOTween.To (go.transform, 0.5f, type1);
		}
		
		private void SetSelfHurtAnimation(GameObject go){
			TweenParms type1 = new TweenParms ();
			type1.Prop ("localPosition", new Vector3 (-80, 50, 0),true);
			type1.Ease (EaseType.EaseOutQuint);
			type1.OnComplete(SetWaitAnimation,go);
			HOTween.To (go.transform, 0.5f, type1);
		}
		
		private void SetHpAnimation(GameObject go){
			TweenParms type1 = new TweenParms ();
			type1.Prop ("localPosition", new Vector3 (0, 50, 0),true); 
			type1.Ease (EaseType.Linear);
			type1.OnComplete(AlphaEff,go);
			HOTween.To (go.transform, 1f, type1);
		}
		
		private void SetCriticalAnimation(GameObject go){
			TweenParms type1 = new TweenParms ();
			type1.Prop ("localPosition", new Vector3 (-80, 30, 0),true); 
			type1.Prop ("localScale", new Vector3 (1.8f, 1.8f, 0)); 
			//type1.Ease (EaseType.EaseOutExpo); 
			Keyframe[] keys = new Keyframe[2];
			keys[0].time = 0f; 
			keys[0].value = 0f;
			keys[0].outTangent = 5f;
			keys[1].time = 1.25f;
			keys[1].value = 1f;
			//keys[1].inTangent = 25f;
			AnimationCurve animationCurve = new AnimationCurve(keys);
			type1.Ease (animationCurve);
			//type1.OnComplete(DestroyEff,go);
			type1.OnComplete(AlphaEff,go);
			HOTween.To (go.transform, 0.75f, type1);
		}
		private void SetOtherDmg(GameObject go){
			TweenParms type1 = new TweenParms ();
			type1.Prop ("localPosition", GetRandomVector3 (TEffectType.Dmg),true); 
			type1.Ease (EaseType.EaseOutBounce);
			type1.OnComplete(SetWaitAnimation,go);
			HOTween.To (go.transform, 0.5f, type1);
		}
		private void SetAvoidAnimation(GameObject go){
			Vector3[] path = new Vector3[4];
			path[0] = Vector3.zero;
			path[1] = new Vector3(-80,5,0);
			path[2] = new Vector3(-30,30,0);
			path[3] = new Vector3(-100,55,0);
			TweenParms type1 = new TweenParms ();
			//type1.Prop ("position", new Vector3 (30, 0, 0),true); 
			type1.Prop ("localPosition", new PlugVector3Path(path,true,PathType.Curved)); 
			type1.Ease (EaseType.EaseOutQuint); 
			//type1.TimeScale(0.5f);
			type1.OnComplete(AlphaEff,go);
			HOTween.To (go.transform, 1f, type1);
		}
		private void SetAttributeChangeAnimation(GameObject go,float y){
			TweenParms type1 = new TweenParms ();
			type1.Prop ("localPosition", new Vector3 (160, y, 0),true);
			type1.Ease (EaseType.Linear);
			type1.OnComplete(DestroyEff,go);
			HOTween.To (go.transform, 2f, type1);
		}
		private void SetShakeAnimation(TweenEvent data){
			GameObject go = data.parms[0] as GameObject;
			Vector3[] path = new Vector3[4];
			path[0] = Vector3.zero;
			path[1] = new Vector3(-5,0,0);
			path[2] = new Vector3(5,0,0);
			path[3] = new Vector3(0,0,0);
			TweenParms type1 = new TweenParms ();
			//type1.Prop ("position", new Vector3 (30, 0, 0),true); 
//			type1.Prop ("localPosition", new PlugVector3Path(path,true)); 
			type1.Ease (EaseType.EaseOutQuint); 
			//type1.TimeScale(0.5f);
			type1.OnComplete(SetWaitAnimation,go);
			HOTween.To (go.transform, 0.15f, type1);
		}
		
		private void SetScaleBigAnimation(GameObject go,float factor,TEffectType type){
			TweenParms type1 = new TweenParms ();
			type1.Prop ("localScale", new Vector3 (factor, factor, 0),true);
			switch(type){
			case TEffectType.DmgCrit:
				type1.Ease (EaseType.EaseOutBounce);
				break;
			case TEffectType.Exp:
				type1.Ease (EaseType.EaseOutBack);
				break;
			}	
			type1.OnComplete(SetScaleSmallAnimation,go);
			HOTween.To (go.transform, 0.35f, type1);
		}
		
		private void SetScaleSmallAnimation(TweenEvent data){
			GameObject go = data.parms[0] as GameObject;
			TweenParms type1 = new TweenParms ();
			type1.Prop ("localScale", new Vector3 (1f, 1f, 0)); 
			type1.Ease (EaseType.EaseOutQuint);
			type1.OnComplete(SetWaitAnimation,go);
			HOTween.To (go.transform, 0.15f, type1);
		}
		
		private void SetWaitAnimation(TweenEvent data){
			GameObject go = data.parms[0] as GameObject;
			TweenParms type1 = new TweenParms ();
			type1.Prop ("localPosition", new Vector3 (0f, 0f, 0),true); 
//			type1.Ease (EaseType.EaseOutQuint);
			type1.OnComplete(AlphaEff,go);
			HOTween.To (go.transform, 0.6f, type1);
		}
		private void SetDestroyAnimation(GameObject go,float time){
			TweenParms type1 = new TweenParms ();
			type1.Prop ("localPosition", new Vector3 (0f, 0f, 0),true); 
			type1.OnComplete(DestroyEff,go);
			HOTween.To (go.transform, time, type1);
		}
		
		private void AlphaEff(TweenEvent data){
			GameObject go = data.parms[0] as GameObject;
//			UIPanel panel = go.GetComponent <UIPanel>();
			TweenParms tp = new TweenParms();
			tp.Prop ("alpha",0f);
			tp.OnComplete (DestroyEff,go);
			foreach(Transform tr in go.transform){
				HOTween.To (tr.gameObject.GetComponent<UISprite>(),0.25f,tp);
			}
//			HOTween.To (panel,0.25f,tp);
		}
		
		private void DestroyEff(TweenEvent data){
			GameObject go = data.parms[0] as GameObject;
			GameObject.Destroy(go);
		}
		
		private Vector3 GetRandomVector3(TEffectType type){
			float len = Random.Range (100,130);
			float randomAngle = Random.Range (-Mathf.PI/9,Mathf.PI/9);
			Vector3 v = Vector3.zero;
			switch(type){
			case TEffectType.Dmg:
				v = new Vector3(len * Mathf.Sin (randomAngle),len * Mathf.Cos(randomAngle),0);
				break;
			case TEffectType.PetDmg:
				v = new Vector3(len * Mathf.Sin (Mathf.PI/4 + randomAngle),len * Mathf.Cos(Mathf.PI/4 + randomAngle),0);
				break;
			}
//			Debug.Log (v);
			return v;
		}
	}
}