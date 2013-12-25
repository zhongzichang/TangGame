using UnityEngine;
using System.Collections;
using zyhd.TEffect;
using Holoville.HOTween;

public class MyTest : MonoBehaviour {

	TEffect te;
	TET tet;
	void Start () {
		TweenParms parm= new TweenParms();
		parm.Prop ("position",new Vector3(0,6,6),true);
		parm.Loops (-1,LoopType.YoyoInverse);
		HOTween.To (this.gameObject.transform, 5 ,parm);
	}
	
	// Update is called once per frame  (TEffectType)(Random.Range(0,3))
	void Update () {
	
	}
	
	void OnGUI(){
		if(GUILayout.Button("OK")){
			Test();
		}
	}
	
	void Test(){
//		int len = Random.Range (5,50);
//		string tt = "";
//		for(int i = 0;i < len;i++){
//			char c = (char)(Random.Range (96,120));
//			tt += c;
//		}
//		new TEffect(TEffectType.NpcTalk,tt,transform.FindChild ("effectRoot").position);
		
//		te.SetNumber (Random.Range (0,1));
		
		tet.ResetDestroyTime (3f);
		tet.SetNum (Random.Range (0f,1f));
	}
	void OnMouseDown(){
//		Debug.Log ("~~~~~~~");
		
//		new TEffect(TEffectType.PetDmg,-Random.Range (256,1889),transform.FindChild ("effectRoot").position);		
//		new TEffect(TEffectType.Dmg,-Random.Range (256,1889),transform.FindChild ("effectRoot").position);		
//		new TEffect(TEffectType.SelfHurt,-Random.Range (256,1889),transform.FindChild ("effectRoot").position);			
//		new TEffect(TEffectType.DmgCrit,-Random.Range (256,1889),transform.FindChild ("effectRoot").position);		
//		new TEffect(TEffectType.Hp,Random.Range (256,1889),transform.FindChild ("effectRoot").position);		
//		new TEffect(TEffectType.Exp,Random.Range (256,1889),transform.FindChild ("effectRoot").position);
		
//		new TEffect(TEffectType.Avoid,"avoid",transform.FindChild ("effectRoot").position);	
	
//		new TEffect(TEffectType.AttributeChange,new string[]{"+12","+120","+888","+6666"},new string[]{"-12","-120","-555","-3333"},
//		       new string[]{"avoid","avoid","avoid","avoid"},new string[]{"avoid","avoid","avoid","avoid"},transform.FindChild ("effectRoot").position);
		
//		te = new TEffect(TEffectType.NpcSelected,"avoid",transform.FindChild ("effectRoot").position);
//		new TEffect(TEffectType.NpcTalk,"avoid",transform.FindChild ("effectRoot").position);	
		
//		te = new TEffect(TEffectType.PlayerName,"Hehe",Color.red,0,new Vector3(0f,50,0),transform.FindChild ("effectRoot").gameObject);
//		te = new TEffect(TEffectType.PlayerHpShow,new Vector3(0,30,0),transform.FindChild ("effectRoot").gameObject);
		
		
		//te = new TEffect(TEffectType.Logo,new string[]{"dmg_1","dmg_2","dmg_3","dmg_4","dmg_5"},transform.FindChild ("effectRoot").gameObject);
		//te = new TEffect(TEffectType.Text,"lite and zzc enjoy each other at nights","#8f0000",16,new Vector2(0f,20f),transform.FindChild ("effectRoot").gameObject);
//-----------------------------------------------------------------------------------------------
//		new TET(TEffectType.PetDmg,-Random.Range (256,1889),Vector3.zero,1,Random.Range (-1f,3f));
//		new TET(TEffectType.Dmg,-Random.Range (256,1889),Vector3.zero,1,Random.Range (-1f,3f));
//		new TET(TEffectType.SelfHurt,-Random.Range (256,1889),Vector3.zero,1,Random.Range (-1f,3f));
//		new TET(TEffectType.DmgCrit,-Random.Range (256,1889),Vector3.zero,1,Random.Range (-1f,3f));
//		new TET(TEffectType.Hp,-Random.Range (256,1889),Vector3.zero,1,Random.Range (-1f,3f));
//		new TET(TEffectType.Exp,Random.Range (256,1889),Vector3.zero,1,Random.Range (-1f,3f));
		
//		new TET(TEffectType.Avoid,"avoid",Vector3.zero,1,Random.Range (-1f,3f));
		
//		new TET(TEffectType.AttributeChange,new string[]{"+12","+120","+888","+6666"},new string[]{"-12","-120","-555","-3333"},
//		       new string[]{"avoid","avoid","avoid","avoid"},new string[]{"avoid","avoid","avoid","avoid"},Vector3.zero,1,Random.Range (-1f,3f));
		
//		tet = new TET(TEffectType.NpcSelected,"avoid",Vector3.zero,1,Random.Range (-1f,3f));
//		new TET(TEffectType.NpcTalk,"avoid",Vector3.zero,1,Random.Range (-1f,3f));
		
//		tet = new TET(TEffectType.PlayerName,"Hehe",Color.red,0,new Vector3(0f,50,0),transform.FindChild ("effectRoot").gameObject,Random.Range (-1f,3f));
		tet = new TET(TEffectType.PlayerHpShow,new Vector3(0,30,0),transform.FindChild ("effectRoot").gameObject,0);
	}
	
	void OnMouseUp(){
//		te.Display ();
		
//		tet.teff.Display ();
		
		
		//te.DisplayLogo (); 
		//[HideInInspector]
	}
}
