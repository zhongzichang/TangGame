using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class CameraEffect : MonoBehaviour {

	Tweener tween;

	void Start () {	
		
	}
	
	void Update () {

	}
	
	void Shake(){
		if(tween == null){ 		
			TweenParms par = new TweenParms();
			par.Prop ("localPosition",new Vector3(0f,0f,0.3f),true);
			par.AutoKill (false);
			par.Ease (EaseType.EaseInOutBounce);
//			tween = HOTween.From (gameObject.transform,0.2f,par);
			tween =HOTween.Shake(gameObject.transform,0.5f,par,10f,0.012f);
		}else{
				tween.Restart();		
		}	
	}
}
