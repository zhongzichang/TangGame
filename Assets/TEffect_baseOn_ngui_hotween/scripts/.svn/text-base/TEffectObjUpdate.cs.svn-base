using UnityEngine;
using System.Collections;

namespace zyhd.TEffect{
	public class TEffectObjUpdate : MonoBehaviour {
	
		[HideInInspector] public GameObject go ;
		[HideInInspector] public TEffect eff ;
		int mHeight = 720;
		UIRoot root;
		void Start () {
			root = NGUITools.GetRoot(gameObject).GetComponent<UIRoot>();
		}
		
		// Update is called once per frame
		void Update () {
			if(go == null){
				if(eff != null) eff.Display ();
			} 
//			if(go && Vector3.Distance (go.transform.position,last) > 0.1){
//				transform.localPosition = GetScreenPosition (go.transform.position);
//				last = transform.localPosition;
//			}
			if(go) transform.localPosition = GetScreenPosition (go.transform.position);
		}
		
		private Vector3 GetScreenPositionOld(Vector3 targetPosition){
			Vector3 temp = Camera.main.WorldToViewportPoint(targetPosition);
			return new Vector3((temp.x-0.5f)*Screen.width ,(temp.y-0.5f)*Screen.height,0f);
		}
		
		private Vector3 GetScreenPosition(Vector3 targetPosition){
			Vector3 temp = Camera.main.WorldToViewportPoint(targetPosition);
			return new Vector3((temp.x-0.5f)*Screen.width*root.pixelSizeAdjustment ,(temp.y-0.5f)*Screen.height*root.pixelSizeAdjustment,0f);
		}
	}
}