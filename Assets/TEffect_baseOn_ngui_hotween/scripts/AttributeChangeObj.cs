using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Holoville.HOTween;
using Holoville.HOTween.Plugins;

namespace zyhd.TEffect{
	
	public class AttributeChangeObj : MonoBehaviour {
	
		[HideInInspector] public Queue gos ;
		[HideInInspector] public static GameObject last;
		[HideInInspector] public static bool isSetLastGameObject = false;
		[HideInInspector] public Vector2 offset2;
		[HideInInspector] public GameObject target;
		private float timeStep = 0.3f;
		private float time = 2.2f;
		private UIRoot root;
		void Start () {
			root = NGUITools.GetRoot(gameObject).GetComponent<UIRoot>();
		}
		
		// Update is called once per frame
		void Update () {
			if(target) transform.localPosition = GetScreenPosition (target.transform.position ) + new Vector3(offset2.x,offset2.y,0);
			time += Time.deltaTime;
			if(time >= timeStep){
				time = 0;
				if(gos != null && gos.Count > 0){
					if(!AttributeChangeObj.isSetLastGameObject){
						AttributeChangeObj.isSetLastGameObject = true;
						last = gameObject;
					}
					GameObject go = gos.Dequeue () as GameObject;
					go.SetActive (true);
//					if(last != null && last != gameObject) DestroyImmediate (last);
					SetAttributeChangeAnimation (go);

				}
			}
			
			if(gos != null && gos.Count < 1) StartCoroutine (DestorySelf());
		}
		
		private void SetAttributeChangeAnimation(GameObject go){
//			TweenParms type1 = new TweenParms ();
//			type1.Prop ("localPosition", new Vector3 (160,1, 0),true);
//			type1.Ease (EaseType.Linear);
//			type1.OnComplete(DestroyEff,go);
//			HOTween.To (go.transform, 2f, type1);

			Vector3[] path = new Vector3[4];
			path[0] = Vector3.zero;
			Vector3 point1 = new Vector3(Random.Range (-40,40),Random.Range (30,80),0);
			path[1] = point1;
			if(point1.x > 0){
				Vector3 point2 = new Vector3(point1.x + Random.Range (20,40),point1.y + Random.Range (-30,-50),0);
				path[2] = point2;
				path[3] = new Vector3(point2.x + Random.Range (10,20),point2.y + Random.Range (-10,-20),0);
			}else{
				Vector3 point2 = new Vector3(point1.x - Random.Range (20,40),point1.y + Random.Range (-30,-50),0);
				path[2] = point2;
				path[3] = new Vector3(point2.x - Random.Range (10,20),point2.y + Random.Range (-10,-20),0);
			}
			TweenParms type1 = new TweenParms ();
			type1.Prop ("localPosition", new PlugVector3Path(path,true,PathType.Curved)); 
			type1.Ease (EaseType.EaseOutCubic); 
//			type1.TimeScale(0.5f);
			type1.OnComplete(DestroyEff,go);
			HOTween.To (go.transform, 1.25f, type1);
		}
		private void SetAttributeChangeAnimation1(GameObject go){	
//			Vector3[] path = new Vector3[5];
//			path[0] = Vector3.zero;
//			Vector3 point1 = new Vector3(Random.Range (),Random.Range (),0);
//			path[1] = point1;
//			path[2] = new Vector3(80,15,0);
//			path[3] = new Vector3(80,-15,0);
//			path[4] = new Vector3(50,-85,0);
			TweenParms type1 = new TweenParms ();
//			type1.Prop ("localPosition", new PlugVector3Path(path,true)); 
			type1.Prop ("localPosition", new Vector3(Random.Range (-80,80),Random.Range (30,80),0),true);
			type1.Ease (EaseType.EaseOutCubic); 
			type1.OnComplete(DestroyEff,go);
			HOTween.To (go.transform, 1f, type1);
		}
		
		private void DestroyEff(TweenEvent data){
			GameObject go = data.parms[0] as GameObject;
			GameObject.Destroy(go);
		}
		private IEnumerator DestorySelf(){
			yield return new WaitForSeconds(2f);
			Destroy (gameObject);
		}
		
		void OnDestroy(){
			isSetLastGameObject = false;
			last = null;
		}
		private Vector3 GetScreenPosition(Vector3 targetPosition){
			Vector3 temp = Camera.main.WorldToViewportPoint(targetPosition);
			return new Vector3((temp.x-0.5f)*Screen.width*root.pixelSizeAdjustment ,(temp.y-0.5f)*Screen.height*root.pixelSizeAdjustment,0f);
		}
		private Vector3 GetScreenPositionOld(Vector3 targetPosition){
			Vector3 temp = Camera.main.WorldToViewportPoint(targetPosition);
			return new Vector3((temp.x-0.5f)*Screen.width ,(temp.y-0.5f)*Screen.height,0f);
		}
	}
}